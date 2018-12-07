using System;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;
using DataSmith.Core.Util;

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

        //保存成功事件
        public event EventHandler AfterSaved; 

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
                inputComboBox1_ChangeCommitted(inputComboBox1, null);
            }
            else if (OperateType == OperateType.Modify)
            {
                _dataSource = dsDal.GetModel(DataSourceId);
                DataProvider = _dataSource.GetDataProvider();
                inputTextBox1.Text = _dataSource.SourceName;
                inputTextBox5.Text = _dataSource.IP;
                inputComboBox1.SelectedValue = _dataSource.DBType;
                inputNumericBox1.Text = _dataSource.Port.ToString();
                inputTextBox3.Text = _dataSource.DBName;
                inputTextBox6.Text = _dataSource.UserID;
                inputTextBox2.Text = _dataSource.Password;
                inputTextBox7.Text = _dataSource.DBConnStr;
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
                if (OperateType == OperateType.New)
                {
                    GetModel();
                }

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
            if (string.IsNullOrWhiteSpace(inputTextBox1.Text))
            {
                inputTextBox1.ErrorText = "请输入数据源名称！";
                MessageBox.Show(inputTextBox1.ErrorText);
                return;
            }
            else
            {
                inputTextBox1.ErrorText = "";
            }

            GetModel();

            if (!TestConn())
                return;

            if (OperateType == OperateType.New)
            {
                dsDal.Insert(_dataSource, x => x.ID);
            }
            else
            {
                dsDal.Update(_dataSource, x => x.ID);
            }

            AfterSaved?.Invoke(this, new EventArgs());
            MessageBox.Show("保存成功！");
        }

        private void GetModel()
        {
            _dataSource.DBType = Convert.ToInt32(inputComboBox1.SelectedValue);
            _dataSource.DBTypeName = inputComboBox1.Text;
            _dataSource.SourceName = inputTextBox1.Text;
            _dataSource.IP = inputTextBox5.Text;
            _dataSource.Port = Convert.ToInt32(inputNumericBox1.Value);
            _dataSource.DBName = inputTextBox3.Text;
            _dataSource.UserID = inputTextBox6.Text;
            _dataSource.Password = inputTextBox2.Text;
            _dataSource.DBConnStr = inputTextBox7.Text;
            DataProvider = _dataSource.GetDataProvider();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            FormCmd cmd = new FormCmd { Commond = "ping", Parameter = inputTextBox5.Text, AutoExec = true };
            cmd.ShowDialog();
        }

        private void inputComboBox1_ChangeCommitted(object sender, EventArgs e)
        {
            InputComboBox inputComboBox = sender as  InputComboBox;
            DataBaseType dataBaseType = inputComboBox.SelectedItem as DataBaseType;
            if (dataBaseType != null)
            {
                inputNumericBox1.Value = dataBaseType.DefaultPort;
            }
        }
    }
}