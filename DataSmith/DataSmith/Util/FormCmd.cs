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

        private BatStatus curBatSataus = BatStatus.NONE;
        private Process curProcess = new Process();

        public String Cmd { get; set; }

        public FormCmd()
        {
            InitializeComponent();
        }

        private void FormCmd_Load(object sender, EventArgs e)
        {
            txtCommand.Text = Cmd;

            InitInfo();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
                return;
            if (m.Msg == WM_NCLBUTTONDBLCLK)
                return;

            base.WndProc(ref m);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            KillProcess();
        }

        private void inputButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KillProcess()
        {
            if (curBatSataus == BatStatus.ON)
            {
                curProcess.CancelOutputRead();//取消异步操作
                curProcess.Kill();
                curBatSataus = BatStatus.OFF;
                //如果需要手动关闭，则关闭后再进行初始化
                InitInfo();
            }
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            KillProcess();

            if (string.IsNullOrEmpty(this.txtCommand.Text.Trim()))
            {
                MessageBox.Show("请输入命令");
            }
            if (curBatSataus != BatStatus.ON)
            {
                curProcess.StandardInput.WriteLine(this.txtCommand.Text.Trim());
                curBatSataus = BatStatus.ON;
            }
            else
            {
                MessageBox.Show("当前进程正在运行，请先关闭");
            }
        }

        /// <summary>
        /// 进程接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (this.txtOutPutInfo.InvokeRequired)
            {
                this.txtOutPutInfo.Invoke(new Action(() =>
                {
                    txtOutPutInfo.AppendText(e.Data + "\r\n");
                    txtOutPutInfo.SelectionStart = txtOutPutInfo.Text.Length;
                    txtOutPutInfo.SelectionLength = 0;
                    txtOutPutInfo.Focus();
                }));
            }
            else
            {
                this.txtOutPutInfo.AppendText(e.Data + "\r\n");
            }
        }

        private void InitInfo()
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

        private void inputButton3_Click(object sender, EventArgs e)
        {
            txtOutPutInfo.Clear();
        }

    }

    /// <summary>
    /// 命令状态
    /// </summary>
    public enum BatStatus
    {
        NONE = 0,
        ON = 1,
        OFF = 2
    }
}
