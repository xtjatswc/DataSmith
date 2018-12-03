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
            ExecQuery();
        }

        private bool ExecQuery()
        {
            try
            {
                var datatable = _dataProvider.GetDataTable(inputTextBox1.Text);
                c1FlexGrid1.DataSource = datatable;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;

            }

            return true;
        }

        private void inputButton2_Click(object sender, EventArgs e)
        {
            if(!ExecQuery())
                return;

            var dt = c1FlexGrid1.DataSource as DataTable;

            using (var context = _viewFieldSetDal.Db.UseTransaction(true))
            {
                _viewFieldSetDal.Db.Sql("delete from ViewFieldSet where InterFaceID = @0 ",
                    _interfaces.ID).Execute();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    var dataColumn = dt.Columns[i];
                    var viewFieldSet = new ViewFieldSet();
                    viewFieldSet.InterfaceID = _interfaces.ID;
                    viewFieldSet.FieldName = dataColumn.ColumnName;
                    viewFieldSet.SortNo = i;
                    _viewFieldSetDal.Insert(viewFieldSet);
                }

                context.Commit();
            }
        }
    }
}