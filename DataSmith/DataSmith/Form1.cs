using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;

namespace DataSmith
{
    public partial class Form1 : Form
    {
        private IDataProvider DataProvider;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dbtDal = Host.GetService<DataBaseTypeDal>();
            var dsDal = Host.GetService<DataSourceDal>();

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
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            bool success = DataProvider.TestConn();
            MessageBox.Show(success.ToString());
        }
    }
}
