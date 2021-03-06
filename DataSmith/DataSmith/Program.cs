﻿/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 10:29
 */

using System;
using System.Text;
using System.Windows.Forms;
using DataSmith.Core.Context;
using DataSmith.Core.Util;

namespace DataSmith
{
    /// <summary>
    ///     Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        ///     Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            ExceptionUtil.SetUnhandledExceptionHandler();

            if (args.Length > 0)
            {
                Host.Args = args;
                DoJob.Execute();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }

        }

    }
}