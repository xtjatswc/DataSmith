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
			AutofacConfig.Register();

		    string abc = LessConfig.db2;

            using (var scope = Host.iContainer.BeginLifetimeScope())
            {
            	var dal = scope.Resolve<DataSourceDal>();
                var models = dal.GetModels();
            }
		}
	}
}
