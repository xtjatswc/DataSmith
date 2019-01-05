using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSmith.Core.Util
{
    public class ExceptionUtil
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void SetUnhandledExceptionHandler()
        {
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            WriteExceptionLog(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteExceptionLog(e.ExceptionObject as Exception);
        }

        public static void WriteExceptionLog(Exception ex)
        {
            Log.Error("全局异常处理", ex);
            StringBuilder sb = new StringBuilder();
            JoinErrStackTrace(ex, sb);
        }

        public static void JoinErrStackTrace(Exception ex, StringBuilder sb)
        {
            if (ex.InnerException != null)
            {
                JoinErrStackTrace(ex.InnerException, sb);
                sb.AppendFormat("-".PadRight(60, '-'));
                sb.AppendLine();
            }

            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
        }
    }
}
