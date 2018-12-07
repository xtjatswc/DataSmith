using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Infrastructure.Base;

namespace DataSmith.Core.Infrastructure.Model
{
    public class DataBaseType : BaseModel
    {
        public String DBTypeName { get; set; }
        public Int64 DefaultPort { get; set; }
        public String DefaultConnStr { get; set; }

    }
}
