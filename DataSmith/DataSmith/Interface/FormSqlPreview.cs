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
            var models = _dataSourceDal.GetModels(where: "SourceType=1");
            inputComboBox1.DisplayMember = "SourceName";
            inputComboBox1.ValueMember = "ID";
            inputComboBox1.DataSource = models;

            //绑定目标数据源下拉框
            models = _dataSourceDal.GetModels(where: "SourceType=2");
            inputComboBox2.DisplayMember = "SourceName";
            inputComboBox2.ValueMember = "ID";
            inputComboBox2.DataSource = models;

        }

        public void ChangeInterface()
        {
            _interfaces = _interfacesDal.GetModel(InterfaceId);
            var dataSource = _interfaces.GetDataSource();
            _dataProvider = dataSource.GetDataProvider();
            var dataBaseType = dataSource.GetDataBaseType();
            inputLabel3.Text = _interfaces.InterfaceName;
            inputTextBox2.Text = _interfaces.ViewName;
            inputTextBox1.Text = string.Format(dataBaseType.DefaultQuerySql, _interfaces.ViewName);
            inputTextBox1.Tag = dataBaseType.DefaultQuerySql;
            inputComboBox1.SelectedValue = _interfaces.DataSourceID;
            inputComboBox2.SelectedValue = _interfaces.TargetDataSourceID;

            c1FlexGrid1.DataSource = null;
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
                //保存接口信息
                _interfaces.ViewName = inputTextBox2.Text;
                _interfaces.DataSourceID = Convert.ToInt64(inputComboBox1.SelectedValue);
                _interfaces.TargetDataSourceID = Convert.ToInt64(inputComboBox2.SelectedValue);
                _interfacesDal.Update(_interfaces, x => x.ID);

                //保存字段列表
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

            MessageBox.Show("保存成功!");
        }

        private void inputComboBox1_ChangeCommitted(object sender, EventArgs e)
        {
            if(_interfaces == null || inputComboBox1.SelectedItem == null)
                return;            

            var dataSource = _dataSourceDal.GetModel(inputComboBox1.SelectedValue);
            _dataProvider = dataSource.GetDataProvider();
            var dataBaseType = dataSource.GetDataBaseType();
            inputTextBox1.Text = string.Format(dataBaseType.DefaultQuerySql, _interfaces.ViewName);
            inputTextBox1.Tag = dataBaseType.DefaultQuerySql;
        }

        private void inputTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (inputTextBox1.Tag != null)
            {
                inputTextBox1.Text = string.Format(inputTextBox1.Tag.ToString(), inputTextBox2.Text);
            }
        }
    }
}