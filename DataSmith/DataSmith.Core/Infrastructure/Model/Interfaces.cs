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
        //源数据库ID
        public Int64 DataSourceID { get; set; }
        //目标数据库ID
        public Int64 TargetDataSourceID { get; set; }
        public String ViewName { get; set; }
        public decimal SortNo { get; set; }
        public Int64 IsDeleted { get; set; }
        public Int64 ViewPassed { get; set; }
        public Int64 FieldPassed { get; set; }

    }
}
