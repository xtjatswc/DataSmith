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

namespace DataSmith.CNIS.Plugin.Setting
{
	/// <summary>
	/// Description of Form2.
	/// </summary>
	public partial class Form2 : Form,ISetting
	{
		public Form2()
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
			if (inputTextBox1.Text.Trim() == "") {
				MessageBox.Show("请输入住院号！");
				inputTextBox1.Focus();
				return;
			}
			
			string cmd = Application.StartupPath + @"\DataSmith.exe";
			FormCmd frm = new FormCmd() {
				Commond = cmd,
				Parameter = string.Format("{0} {1}", 1, inputTextBox1.Text),
				AutoExec = true
			};
			frm.ShowDialog();
		}
	}
}
