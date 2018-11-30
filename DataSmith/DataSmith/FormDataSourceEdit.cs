using System;
using System.Windows.Forms;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith
{
    public partial class FormDataSourceEdit : Form
    {
        private IDataProvider DataProvider;
        private readonly DataBaseTypeDal dbtDal = Host.GetService<DataBaseTypeDal>();
        private readonly DataSourceDal dsDal = Host.GetService<DataSourceDal>();

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

            var dataSource = dsDal.GetModel(4);
            DataProvider = dataSource.GetDataProvider();
            inputTextBox1.Text = dataSource.SourceName;
            inputTextBox5.Text = dataSource.IP;
            inputTextBox4.Text = dataSource.Port.ToString();
            inputTextBox3.Text = dataSource.DBName;
            inputTextBox6.Text = dataSource.UserID;
            inputTextBox2.Text = dataSource.Password;
            inputTextBox7.Text = dataSource.DBConnStr;
            inputComboBox1.SelectedValue = dataSource.DBType;
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            var success = DataProvider.TestConn();
            MessageBox.Show(success.ToString());
        }

        private void inputButton2_Click(object sender, EventArgs e)
        {
            var dataSource = new DataSource();
            dataSource.DBType = Convert.ToInt32(inputComboBox1.SelectedValue);
            dataSource.DBTypeName = inputComboBox1.Text;
            dataSource.SourceName = inputTextBox1.Text;
            dataSource.IP = inputTextBox5.Text;
            dataSource.Port = Convert.ToInt32(inputTextBox4.Text);
            dataSource.DBName = inputTextBox3.Text;
            dataSource.UserID = inputTextBox6.Text;
            dataSource.Password = inputTextBox2.Text;
            dataSource.DBConnStr = inputTextBox7.Text;

            dsDal.Insert(dataSource, x => x.ID);
        }
    }
}