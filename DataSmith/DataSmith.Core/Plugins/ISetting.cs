using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSmith.Core.Plugins
{
    public interface ISetting
    {
        Int64 TaskSchedulerID { get; }
        Form FormInstance { get; }
    }
}
