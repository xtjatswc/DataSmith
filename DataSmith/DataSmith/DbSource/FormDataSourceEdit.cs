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

            var model = dbtDal.GetModels();
            inputComboBox1.DataSource = model;
            inputComboBox1.DisplayMember = "DBTypeName";
            inputComboBox1.ValueMember = "ID";
            this.inputComboBox1.ChangeCommitted += new System.EventHandler(this.inputComboBox1_ChangeCommitted);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void ChangeDataSource()
        {
            if (OperateType == OperateType.New)
            {
                DataSourceId = -1;
                _dataSource = new DataSource();
                c1InputPanel1.FormReset();
                inputButtonDelete.Visibility = Visibility.Hidden;
            }
            else if (OperateType == OperateType.Modify)
            {
                _dataSource = dsDal.GetModel(DataSourceId);
                DataProvider = _dataSource.GetDataProvider();
                inputTextBox1.Text = _dataSource.SourceName;
                inputTextBoxIP.Text = _dataSource.IP;
                inputTextBoxInstanceName.Text = _dataSource.InstanceName;
                inputComboBox1.SelectedValue = _dataSource.DBType;
                inputNumericBoxPort.Value = _dataSource.Port;
                inputTextBoxDBName.Text = _dataSource.DBName;
                inputTextBoxUserID.Text = _dataSource.UserID;
                inputTextBoxPassword.Text = _dataSource.Password;
                inputTextBoxConnStr.Text = _dataSource.DBConnStr;
                inputButtonDelete.Visibility = Visibility.Visible;
            }

            inputComboBox1_ChangeCommitted(inputComboBox1, null);

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

                DataProvider.Db.Data.ConnectionString = inputTextBoxConnStr.Text;
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
                _dataSource.SourceType = 1;
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
            _dataSource.IP = inputTextBoxIP.Text;
            _dataSource.InstanceName = inputTextBoxInstanceName.Text;
            _dataSource.Port = Convert.ToInt32(inputNumericBoxPort.Value);
            _dataSource.DBName = inputTextBoxDBName.Text;
            _dataSource.UserID = inputTextBoxUserID.Text;
            _dataSource.Password = inputTextBoxPassword.Text;
            _dataSource.DBConnStr = inputTextBoxConnStr.Text;
            DataProvider = _dataSource.GetDataProvider();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            FormCmd cmd = new FormCmd { Commond = "ping", Parameter = inputTextBoxIP.Text, AutoExec = true };
            cmd.ShowDialog();
        }

        private void inputComboBox1_ChangeCommitted(object sender, EventArgs e)
        {
            InputComboBox inputComboBox = sender as InputComboBox;
            DataBaseType dataBaseType = inputComboBox.SelectedItem as DataBaseType;
            if (dataBaseType != null)
            {
                //实例名 默认隐藏
                inputLabel9.Visibility = Visibility.Collapsed;
                inputTextBoxInstanceName.Visibility = Visibility.Collapsed;
                inputLabel11.Visibility = Visibility.Collapsed;

                //IP
                inputLabel6.Visibility = Visibility.Visible;
                inputTextBoxIP.Visibility = Visibility.Visible;
                btnPing.Visibility = Visibility.Visible;

                //端口
                inputLabel5.Visibility = Visibility.Visible;
                inputNumericBoxPort.Visibility = Visibility.Visible;
                inputLabel10.Visibility = Visibility.Visible;
                inputLabel10.Text = string.Format("备注：{0}的默认端口是{1}",
                    Enum.GetName(typeof(DBType), dataBaseType.ID),
                    dataBaseType.DefaultPort
                );
                if (dataBaseType.DefaultPort == 0)
                {
                    inputNumericBoxPort.Text = "";
                }
                else
                {
                    inputNumericBoxPort.Value = dataBaseType.DefaultPort;
                }

                //用户名
                inputLabel7.Visibility = Visibility.Visible;
                inputTextBoxUserID.Visibility = Visibility.Visible;

                switch ((DBType) dataBaseType.ID)
                {
                    case DBType.SqlServer:
                        //实例名
                        inputLabel9.Visibility = Visibility.Visible;
                        inputTextBoxInstanceName.Visibility = Visibility.Visible;
                        inputLabel11.Visibility = Visibility.Visible;

                        //端口
                        inputLabel10.Text = "备注：SqlServer通常是动态端口，该项一般情况下不用配置。";
                        break;
                    case DBType.Oracle:
                    case DBType.MySQL:
                        break;
                    case DBType.Sqlite:
                        //IP
                        inputLabel6.Visibility = Visibility.Collapsed;
                        inputTextBoxIP.Visibility = Visibility.Collapsed;
                        btnPing.Visibility = Visibility.Collapsed;

                        //端口
                        inputLabel5.Visibility = Visibility.Collapsed;
                        inputNumericBoxPort.Visibility = Visibility.Collapsed;
                        inputLabel10.Visibility = Visibility.Collapsed;

                        //用户名
                        inputLabel7.Visibility = Visibility.Collapsed;
                        inputTextBoxUserID.Visibility = Visibility.Collapsed;

                        break;
                }
            }

            inputTextBox5_TextChanged(null, null);
        }

        private void inputTextBox5_TextChanged(object sender, EventArgs e)
        {
            DataBaseType dataBaseType = inputComboBox1.SelectedItem as DataBaseType;
            if (dataBaseType != null)
            {

                switch ((DBType)dataBaseType.ID)
                {
                    case DBType.SqlServer:
                        inputTextBoxConnStr.Text = string.Format(dataBaseType.DefaultConnStr,
                            inputTextBoxIP.Text,
                            inputNumericBoxPort.Value == 0 ? "" : $",{inputNumericBoxPort.Text}",
                            string.IsNullOrWhiteSpace(inputTextBoxInstanceName.Text) ? "" : $"\\{inputTextBoxInstanceName.Text.Trim()}",
                            inputTextBoxDBName.Text,
                            inputTextBoxUserID.Text,
                            inputTextBoxPassword.Text
                        );
                        break;
                    case DBType.Oracle:
                    case DBType.MySQL:
                        inputTextBoxConnStr.Text = string.Format(dataBaseType.DefaultConnStr,
                            inputTextBoxIP.Text,
                            inputNumericBoxPort.Text,
                            inputTextBoxDBName.Text,
                            inputTextBoxUserID.Text,
                            inputTextBoxPassword.Text
                        );
                        break;
                    case DBType.Sqlite:
                        inputTextBoxConnStr.Text = string.Format(dataBaseType.DefaultConnStr,
                            inputTextBoxDBName.Text,
                            string.IsNullOrWhiteSpace(inputTextBoxPassword.Text) ? "" : $"Password={inputTextBoxPassword.Text};"
                        );
                        break;

                }
            }
        }

        private void inputButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("删除后不可恢复，请谨慎操作！是否删除？", "询问", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dsDal.DeleteExt(DataSourceId);
                OperateType = OperateType.New;
                ChangeDataSource();
                AfterSaved?.Invoke(this, new EventArgs());
            }
        }
    }
}