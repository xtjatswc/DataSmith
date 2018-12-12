using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.DAL;

namespace DataSmith.Log
{
    public partial class FormLog4net : Form
    {
        private readonly LogDal _logDal = Host.GetService<LogDal>();
        private List<Core.Infrastructure.Model.Log> _models;
        private int _pageIndex = 1;
        private int _pageSize = 25;

        public FormLog4net()
        {
            InitializeComponent();
        }

        private void FormLog4net_Load(object sender, EventArgs e)
        {
            GetData(_pageIndex, _pageSize);
        }

        private void c1FlexGrid1_SelChange(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel < 0)
                return;

            var model = _models[c1FlexGrid1.RowSel - 1];
            c1InputPanel1.DataSource = model;
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            if(_pageIndex == 1)
                return;

            _pageIndex--;
            GetData(_pageIndex, _pageSize);
        }

        private void inputButton2_Click(object sender, EventArgs e)
        {
            _pageIndex++;
            int count = GetData(_pageIndex, _pageSize);
            if (count == 0)
            {
                inputButton1_Click(null, null);
                MessageBox.Show("已经是最后一页了！");
            }
        }

        private int GetData(int currentPage, int itemsPerPage)
        {
            inputLabel1.Text = string.Format("第{0}页", _pageIndex);
            _models = _logDal.GetModels(currentPage: currentPage, itemsPerPage: itemsPerPage, orderBy: "Date desc");
            c1FlexGrid1.DataSource = _models;
            return _models.Count;
        }
    }
}
