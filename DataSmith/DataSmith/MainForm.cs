/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 10:29
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataSmith.Core.Config;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.DAL;
using Autofac;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.Base;

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

		    var dal = Host.GetService<DataSourceDal>();
		    var models = dal.GetModels();

		    IDataProvider iDataProvider = models[0].GetDataProvider();

            string sql = "select * from bednumber";
		    var table = iDataProvider.GetDataTable(sql);
		}
    }
}
