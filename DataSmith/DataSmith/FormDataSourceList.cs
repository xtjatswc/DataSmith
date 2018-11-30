using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith
{
    public partial class FormDataSourceList : Form
    {
        private readonly DataSourceDal _dataSourceDal = Host.GetService<DataSourceDal>();

        public FormDataSourceList()
        {
            InitializeComponent();
        }

        private void FormDataSourceList_Load(object sender, EventArgs e)
        {
            var models = _dataSourceDal.GetModels();
            c1InputPanel1.Items.Clear();
            foreach (var model in models)
            {
                InputButton inputButton = new InputButton();
                inputButton.Text = model.SourceName;
                inputButton.Width = c1InputPanel1.Width - 20;
                inputButton.Click += InputButton_Click;
                inputButton.Tag = model;
                c1InputPanel1.Items.Add(inputButton);
            }

            c1InputPanel1.SetSwitchToggle();
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            FormDataSourceEdit frm = Host.GetService<FormDataSourceEdit>();
            frm.ChangeDataSource(((sender as InputButton).Tag as DataSource).ID);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            panel1.Controls.Add(frm);
        }
    }
}
