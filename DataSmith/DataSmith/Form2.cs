﻿using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataSmith
{
    public partial class Form2 : Form
    {
        private readonly InterfacesDal _interfacesDal = Host.GetService<InterfacesDal>();
        private readonly ViewFieldSetDal _viewFieldSetDal = Host.GetService<ViewFieldSetDal>();
        private Interfaces _interfaces;
        private IDataProvider _dataProvider;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _interfaces = _interfacesDal.GetModel(1);
            var dataSource = _interfaces.GetDataSource();
            _dataProvider = dataSource.GetDataProvider();
            inputLabel3.Text = _interfaces.InterfaceName;
            inputTextBox1.Text = _interfaces.ViewSql;
        }

        private void inputButton1_Click(object sender, EventArgs e)
        {
            var datatable = _dataProvider.GetDataTable(inputTextBox1.Text);
            c1FlexGrid1.DataSource = datatable;
        }

        private void inputButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = c1FlexGrid1.DataSource as DataTable;

            using (var context = _viewFieldSetDal.Db.UseTransaction(true))
            {
                _viewFieldSetDal.Db.Sql("update ViewFieldSet set IsDeleted = 1 where InterFaceID = @0", _interfaces.ID).Execute();
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    ViewFieldSet viewFieldSet = new ViewFieldSet();
                    viewFieldSet.InterfaceID = _interfaces.ID;
                    viewFieldSet.FieldName = dataColumn.ColumnName;
                    viewFieldSet.IsDeleted = 0;

                    var model = _viewFieldSetDal.GetModel(viewFieldSet, x => x.InterfaceID, x => x.FieldName);
                    if (model == null)
                    {
                        _viewFieldSetDal.Insert(viewFieldSet);
                    }
                    else
                    {
                        _viewFieldSetDal.Db.Sql(
                            "update ViewFieldSet set IsDeleted = 0 where InterFaceID = @0 and FieldName = @1",
                            _interfaces.ID, viewFieldSet.FieldName).Execute();
                    }
                }
                _viewFieldSetDal.Db.Sql("delete from ViewFieldSet where IsDeleted = 1 and InterFaceID = @0 ", _interfaces.ID).Execute();

                context.Commit();
            }
        }
    }
}