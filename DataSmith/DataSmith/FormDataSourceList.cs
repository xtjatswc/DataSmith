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
using DataSmith.Core.Infrastructure.DAL;

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
                inputButton.TabStop = false;
                inputButton.CheckOnClick = true;
                inputButton.Text = model.SourceName;
                inputButton.Width = c1InputPanel1.Width - 20;
                c1InputPanel1.Items.Add(inputButton);
            }
        }
    }
}
