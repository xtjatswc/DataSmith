using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Infrastructure.Model
{
    public class QueryParameter
    {
        public Int64 InterfaceID { get; set; }
        public String ParaName { get; set; }
        public String Formart { get; set; }
        public String Remark { get; set; }
    }
}
