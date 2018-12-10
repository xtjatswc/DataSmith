using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Plugins
{
    public interface IPluginSetting
    {
        Int64 TaskSchedulerID { get; }
        void SetTaskScheduler(TaskScheduler taskScheduler);
        Form FormInstance { get; }
    }
}
