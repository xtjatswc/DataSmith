/*
 * 用户： zxs
 * 日期: 2018/12/6
 * 时间: 10:00
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using DataSmith.Core.Plugins;
using DataSmith.Core.Util;
using DataSmith.Core.Context;

namespace DataSmith.CNIS.Plugin.Setting
{
	/// <summary>
	/// Description of Form3.
	/// </summary>
	public partial class Form3 : Form,ISetting
	{
		public Int64 TaskSchedulerID { get { return 3; } }
		public Form FormInstance{ get { return this; } }

		public Form3()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			inputDatePicker1.Value = DateTime.Now.AddDays(-3);
		}
		
		void InputButton1Click(object sender, EventArgs e)
		{			
			FormCmd frm = new FormCmd() {
				Commond = "\"" + Host.ExePath + "\"",
				Parameter = string.Format("{0} {1} {2}", TaskSchedulerID, inputDatePicker1.Text, inputDatePicker2.Text),
				AutoExec = true
			};
			frm.ShowDialog();
		}
	}
}
