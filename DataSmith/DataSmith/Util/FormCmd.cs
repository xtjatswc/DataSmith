using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DataSmith.Util
{
    public partial class FormCmd : BaseForm
    {
        //禁止通过拖动，双击标题栏改变窗体大小。
        public const int WM_NCLBUTTONDBLCLK = 0xA3;
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 2;

        private Process curProcess = new Process();

        public String Cmd { get; set; }
        public String Parameter { get; set; }

        public FormCmd()
        {
            InitializeComponent();
        }

        private void FormCmd_Load(object sender, EventArgs e)
        {
            txtCommand.Text = Cmd;
            txtParameter.Text = Parameter;

            InitProcess();
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
            if (string.IsNullOrEmpty(txtCommand.Text.Trim()))
            {
                MessageBox.Show("请输入命令");
            }
            curProcess.StandardInput.WriteLine(txtCommand.Text + " " + txtParameter.Text);
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

        private void InitProcess()
        {
            curProcess.OutputDataReceived -= new DataReceivedEventHandler(ProcessOutDataReceived);
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "cmd.exe";
            //p.Arguments = " -t 192.168.1.103";
            p.UseShellExecute = false;
            p.WindowStyle = ProcessWindowStyle.Hidden;
            p.CreateNoWindow = true;
            p.RedirectStandardError = true;
            p.RedirectStandardInput = true;
            p.RedirectStandardOutput = true;
            curProcess.StartInfo = p;
            curProcess.Start();

            curProcess.BeginOutputReadLine();
            curProcess.OutputDataReceived += new DataReceivedEventHandler(ProcessOutDataReceived);
        }

        private void KillProcess()
        {
            curProcess.CancelOutputRead();//取消异步操作
            curProcess.Kill();
        }

        private void FormCmd_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillProcess();
        }
    }
}
