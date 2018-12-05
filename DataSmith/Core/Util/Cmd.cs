using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Util
{
    public class Cmd
    {
        private readonly Process _process = new Process();
        public DataReceivedEventHandler DataReceivedHandler { get; set; }

        public Cmd()
        {
            _process.OutputDataReceived -= new DataReceivedEventHandler(ProcessOutDataReceived);
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "cmd.exe";
            //p.Arguments = " -t 192.168.1.103";
            p.UseShellExecute = false;
            p.WindowStyle = ProcessWindowStyle.Hidden;
            p.CreateNoWindow = true;
            p.RedirectStandardError = true;
            p.RedirectStandardInput = true;
            p.RedirectStandardOutput = true;
            _process.StartInfo = p;
            _process.Start();

            _process.BeginOutputReadLine();
            _process.OutputDataReceived += new DataReceivedEventHandler(ProcessOutDataReceived);
        }

        public void Exec(string commond, string parameter = "")
        {
            _process.StandardInput.WriteLine($"{commond} {parameter}");
        }

        public void Exit()
        {
            _process.CancelOutputRead();//取消异步操作
            _process.Kill();
        }

        /// <summary>
        /// 进程接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        {
            DataReceivedHandler?.Invoke(sender, e);
        }
    }
}
