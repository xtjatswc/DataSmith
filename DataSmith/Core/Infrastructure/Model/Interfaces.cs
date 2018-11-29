using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Infrastructure.Attribute;
using DataSmith.Core.Infrastructure.Base;

namespace DataSmith.Core.Infrastructure.Model
{
    public class Interfaces : BaseModel
    {
        public String InterfaceName { get; set; }
        public Int64 ClassifyID { get; set; }
        public Int64 DataSourceID { get; set; }
        public String ViewSql { get; set; }
        public decimal SortNo { get; set; }
    }
}
