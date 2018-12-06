using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Infrastructure.Model
{
    public class TaskScheduler
    {
        public Int64 ID { get; set; }
        public Int64 ClassifyID { get; set; }
        public string TaskName { get; set; }
        public string InterfaceID { get; set; }
        public decimal SortNo { get; set; }
        public Int64 IsDeleted { get; set; }

    }
}
