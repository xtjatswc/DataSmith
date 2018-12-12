using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Infrastructure.Model
{
    public class Log
    {
        public String Date { get; set; }
        public String Thread { get; set; }
        public String Level { get; set; }
        public String Logger { get; set; }
        public String Message { get; set; }
        public String Exception { get; set; }

    }
}
