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
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.CNIS.Plugin.Setting
{
	/// <summary>
	/// Description of Form0.
	/// </summary>
	internal partial class Form0 : Form,IPluginSetting
	{
		//缺省设置
		public Int64 TaskSchedulerID { get { return 0; } }
		public Form FormInstance{ get { return this; } }
		TaskScheduler _taskScheduler;
			
		public Form0()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void SetTaskScheduler(TaskScheduler taskScheduler)
		{
			_taskScheduler = taskScheduler;
			inputGroupHeader1.Text = _taskScheduler.TaskName;
		}
		
		void InputButton1Click(object sender, EventArgs e)
		{			
			FormCmd frm = new FormCmd() {
				Commond = "\"" + Host.ExePath + "\"",
				Parameter = string.Format("{0}", _taskScheduler.ID),
				AutoExec = true
			};
			frm.ShowDialog();
		}
	}
}
