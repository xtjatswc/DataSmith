using System;
using System.Windows.Forms;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.DbSource
{
    public partial class FormDataSourceEdit : Form
    {
        private IDataProvider DataProvider;
        private readonly DataBaseTypeDal dbtDal = Host.GetService<DataBaseTypeDal>();
        private readonly DataSourceDal dsDal = Host.GetService<DataSourceDal>();

        public OperateType OperateType { get; set; } = OperateType.None;
        public Int64 DataSourceId { get; set; }
        private DataSource _dataSource;

        public FormDataSourceEdit()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var model = dbtDal.GetModels();
            inputComboBox1.DataSource = model;
            inputComboBox1.DisplayMember = "DBTypeName";
            inputComboBox1.ValueMember = "ID";

        }

        public void ChangeDataSource()
        {
            if (OperateType == OperateType.New)
            {
                DataSourceId = -1;
                _dataSource = new DataSource();
                c1InputPanel1.FormReset();
            }
            else if (OperateType == OperateType.Modify)
            {
                _dataSource = dsDal.GetModel(DataSourceId);
                DataProvider = _dataSource.GetDataProvider();
                inputTextBox1.Text = _dataSource.SourceName;
                inputTextBox5.Text = _dataSource.IP;
                inputNumericBox1.Text = _dataSource.Port.ToString();
                inputTextBox3.Text = _dataSource.DBName;
                inputTextBox6.Text = _dataSource.UserID;
                inputTextBox2.Text = _dataSource.Password;
                inputTextBox7.Text = _dataSource.DBConnStr;
                inputComboBox1.SelectedValue = _dataSource.DBType;
            }
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            if (TestConn())
                MessageBox.Show("连接成功！");
        }

        private bool TestConn()
        {
            try
            {
                DataProvider.Db.Data.ConnectionString = inputTextBox7.Text;
                return DataProvider.TestConn();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            return false;
        }

        private void inputButton2_Click(object sender, EventArgs e)
        {
            if (!TestConn())
                return;

            _dataSource.DBType = Convert.ToInt32(inputComboBox1.SelectedValue);
            _dataSource.DBTypeName = inputComboBox1.Text;
            _dataSource.SourceName = inputTextBox1.Text;
            _dataSource.IP = inputTextBox5.Text;
            _dataSource.Port = Convert.ToInt32(inputNumericBox1.Value);
            _dataSource.DBName = inputTextBox3.Text;
            _dataSource.UserID = inputTextBox6.Text;
            _dataSource.Password = inputTextBox2.Text;
            _dataSource.DBConnStr = inputTextBox7.Text;

            if (OperateType == OperateType.New)
            {
                dsDal.Insert(_dataSource, x => x.ID);
            }
            else
            {
                dsDal.Update(_dataSource, x => x.ID);
            }

            MessageBox.Show("保存成功！");
        }
    }
}