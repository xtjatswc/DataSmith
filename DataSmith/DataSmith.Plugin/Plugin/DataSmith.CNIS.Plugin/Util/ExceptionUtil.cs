using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSmith.CNIS.Plugin.Util
{
    public static class ExceptionUtil
    {
        public static string getInnerException(Exception ex)
        {
            if (ex.InnerException == null)
            {
                return ex.Message;
            }
            else
            {
                return getInnerException(ex.InnerException) + "\r\n" + ex.Message;
            }
        }

    }
}
