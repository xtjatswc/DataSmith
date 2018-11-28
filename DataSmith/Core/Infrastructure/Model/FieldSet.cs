using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Infrastructure.Attribute;
using DataSmith.Core.Infrastructure.Base;

namespace DataSmith.Core.Infrastructure.Model
{
    public class FieldSet : BaseModel
    {
        public Int64 InterfaceID { get; set; }
        public String FieldName { get; set; }
        public String FieldDescribe { get; set; }
        public Int64 Required { get; set; }
        public String Remark { get; set; }
        public Double SortNo { get; set; }
    }
}
