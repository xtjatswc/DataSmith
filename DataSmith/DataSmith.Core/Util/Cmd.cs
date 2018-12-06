using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Quartz.Util;

namespace DataSmith.Core.Util
{
    public class Cmd
    {
        private Process _process;

        /// <summary>
        ///   每次应用程序向其重定向 <see cref="P:System.Diagnostics.Process.StandardOutput" /> 流中写入行时发生。
        /// </summary>
        [Browsable(true)]
        [MonitoringDescription("ProcessAssociated")]
        public event DataReceivedEventHandler OutputDataReceived;

        public Cmd()
        {
            Init();
        }

        ~Cmd()
        {
            Abort();
        }

        private void Init()
        {
            if (_process != null)
                return;

            _process = new Process();
            _process.OutputDataReceived -= new DataReceivedEventHandler(ProcessOutDataReceived);
            ProcessStartInfo p = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                //p.Arguments = " -t 192.168.1.103";
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            _process.StartInfo = p;
            _process.Start();

            _process.BeginOutputReadLine();
            _process.OutputDataReceived += new DataReceivedEventHandler(ProcessOutDataReceived);
        }

        public void Exec(string commond, string parameter = "")
        {
            if (_process == null)
                Init();

            _process.StandardInput.WriteLine($"{commond} {parameter}");
        }

        public void Abort()
        {
            if (_process != null)
            {
                _process.CancelOutputRead();//取消异步操作
                _process.Kill();
                _process = null;
            }
        }

        /// <summary>
        /// 进程接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutputDataReceived?.Invoke(sender, e);
        }

        ///// <summary>
        ///// 进程接受事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public void ProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        //{
        //    if (txtOutPutInfo.InvokeRequired)
        //    {
        //        txtOutPutInfo.Invoke(new Action(() =>
        //        {
        //            txtOutPutInfo.AppendText(e.Data + "\r\n");
        //            //txtOutPutInfo.SelectionStart = txtOutPutInfo.Text.Length;
        //            //txtOutPutInfo.SelectionLength = 0;
        //            //txtOutPutInfo.Focus();
        //            txtOutPutInfo.ScrollToCaret();
        //        }));
        //    }
        //    else
        //    {
        //        txtOutPutInfo.AppendText(e.Data + "\r\n");
        //    }
        //}

    }
}
