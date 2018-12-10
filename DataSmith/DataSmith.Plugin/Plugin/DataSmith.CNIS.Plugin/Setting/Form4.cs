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
	/// Description of Form4.
	/// </summary>
	public partial class Form4 : Form,IPluginSetting
	{
		public Int64 TaskSchedulerID { get { return 4; } }
		public Form FormInstance{ get { return this; } }

		public Form4()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void InputButton1Click(object sender, EventArgs e)
		{
			if (inputNumericBox1.Text.Trim() == "") {
				MessageBox.Show("请输入分钟数！");
				inputNumericBox1.Focus();
				return;
			}
			
			FormCmd frm = new FormCmd() {
				Commond = "\"" + Host.ExePath + "\"",
				Parameter = string.Format("{0} {1}", TaskSchedulerID, inputNumericBox1.Text),
				AutoExec = true
			};
			frm.ShowDialog();
		}
	}
}
