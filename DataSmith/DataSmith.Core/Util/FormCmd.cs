using System;
using System.Diagnostics;
using System.Windows.Forms;
using DataSmith.Core.Util;

namespace DataSmith.Core.Util
{
    public partial class FormCmd : Form
    {
        //禁止通过拖动，双击标题栏改变窗体大小。
        public const int WM_NCLBUTTONDBLCLK = 0xA3;
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 2;

        private Cmd _cmd;

        public String Commond { get; set; }
        public String Parameter { get; set; }
        public bool AutoExec { get; set; } = false;

        public FormCmd()
        {
            InitializeComponent();
        }

        private void FormCmd_Load(object sender, EventArgs e)
        {
            txtCommand.Text = Commond;
            txtParameter.Text = Parameter;
            _cmd = new Cmd();
            _cmd.OutputDataReceived += ProcessOutDataReceived;
            if (AutoExec)
                ExecCmd();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
                return;
            if (m.Msg == WM_NCLBUTTONDBLCLK)
                return;

            base.WndProc(ref m);
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            ExecCmd();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            _cmd.Abort();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutPutInfo.Clear();
        }

        /// <summary>
        /// 进程接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (txtOutPutInfo.InvokeRequired)
            {
                txtOutPutInfo.Invoke(new Action(() =>
                {
                    txtOutPutInfo.AppendText(e.Data + "\r\n");
                    //txtOutPutInfo.SelectionStart = txtOutPutInfo.Text.Length;
                    //txtOutPutInfo.SelectionLength = 0;
                    //txtOutPutInfo.Focus();
                    txtOutPutInfo.ScrollToCaret();
                }));
            }
            else
            {
                txtOutPutInfo.AppendText(e.Data + "\r\n");
            }
        }

        private void ExecCmd()
        {
            if (string.IsNullOrEmpty(txtCommand.Text.Trim()))
            {
                MessageBox.Show("请输入命令");
            }
            _cmd.Exec(txtCommand.Text, txtParameter.Text);
        }
    }
}
