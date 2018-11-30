using System;
using System.Data;
using System.Windows.Forms;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Interface
{
    public partial class FormSqlPreview : Form
    {
        private readonly DataSourceDal _dataSourceDal = Host.GetService<DataSourceDal>();
        private readonly InterfacesDal _interfacesDal = Host.GetService<InterfacesDal>();
        private readonly ViewFieldSetDal _viewFieldSetDal = Host.GetService<ViewFieldSetDal>();
        private IDataProvider _dataProvider;

        public Int64 InterfaceId { get; set; }
        private Core.Infrastructure.Model.Interfaces _interfaces;

        public FormSqlPreview()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //绑定数据源下拉框
            var models = _dataSourceDal.GetModels();
            inputComboBox1.DisplayMember = "SourceName";
            inputComboBox1.ValueMember = "ID";
            inputComboBox1.DataSource = models;

        }

        public void ChangeInterface()
        {
            _interfaces = _interfacesDal.GetModel(InterfaceId);
            var dataSource = _interfaces.GetDataSource();
            _dataProvider = dataSource.GetDataProvider();
            inputLabel3.Text = _interfaces.InterfaceName;
            inputTextBox2.Text = _interfaces.ViewName;
            inputTextBox1.Text = $"select * from {_interfaces.ViewName}";
            inputComboBox1.SelectedValue = _interfaces.DataSourceID;
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            var datatable = _dataProvider.GetDataTable(inputTextBox1.Text);
            c1FlexGrid1.DataSource = datatable;
        }

        private void inputButton2_Click(object sender, EventArgs e)
        {
            var dt = c1FlexGrid1.DataSource as DataTable;

            using (var context = _viewFieldSetDal.Db.UseTransaction(true))
            {
                _viewFieldSetDal.Db.Sql("update ViewFieldSet set IsDeleted = 1 where InterFaceID = @0", _interfaces.ID)
                    .Execute();
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    var viewFieldSet = new ViewFieldSet();
                    viewFieldSet.InterfaceID = _interfaces.ID;
                    viewFieldSet.FieldName = dataColumn.ColumnName;
                    viewFieldSet.IsDeleted = 0;

                    var model = _viewFieldSetDal.GetModel(viewFieldSet, x => x.InterfaceID, x => x.FieldName);
                    if (model == null)
                        _viewFieldSetDal.Insert(viewFieldSet);
                    else
                        _viewFieldSetDal.Db.Sql(
                            "update ViewFieldSet set IsDeleted = 0 where InterFaceID = @0 and FieldName = @1",
                            _interfaces.ID, viewFieldSet.FieldName).Execute();
                }

                _viewFieldSetDal.Db.Sql("delete from ViewFieldSet where IsDeleted = 1 and InterFaceID = @0 ",
                    _interfaces.ID).Execute();

                context.Commit();
            }
        }
    }
}