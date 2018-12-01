/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 10:29
 */

using System;
using System.Windows.Forms;

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
        //[STAThread]
        //private static void Main(string[] args)
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new FormMain());

        //}

        public static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            c1.Test();
        }

    }
}