using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Infrastructure.Base;

namespace DataSmith.Core.Infrastructure.Model
{
    public class TaskScheduler : BaseModel
    {
        public string PluginID { get; set; }
        public Int64 ClassifyID { get; set; }
        public string TaskName { get; set; }
        public string InterfaceID { get; set; }
        public decimal SortNo { get; set; }
        public Int64 IsDeleted { get; set; }

    }
}
