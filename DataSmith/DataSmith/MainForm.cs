/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 10:29
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataSmith.Core.Config;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.DAL;
using Autofac;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
            //
            var ifDal = Host.GetService<InterfacesDal>();
		    var dal = Host.GetService<DataSourceDal>();
		    var vfsDal = Host.GetService<ViewFieldSetDal>();

            var ifs = ifDal.GetModels();
		    foreach (var theIf in ifs)
		    {
		        var datasource = dal.GetModel(theIf.DataSourceID);
		        IDataProvider iDataProvider = datasource.GetDataProvider();
		        string sql = theIf.ViewSql;
		        var table = iDataProvider.GetDataTable(sql);

		        foreach (DataColumn column in table.Columns)
		        {
		            ViewFieldSet vfs = new ViewFieldSet();
		            vfs.InterfaceID = theIf.ID;
		            vfs.FieldName = column.ColumnName;
		            vfs.FieldAlias = column.ColumnName;
		            vfsDal.Insert(vfs, x => x.ID);
		        }

            }
		    
        }
    }
}
