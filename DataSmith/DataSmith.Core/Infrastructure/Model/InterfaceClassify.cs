using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Infrastructure.Base;

namespace DataSmith.Core.Infrastructure.Model
{
    public class InterfaceClassify : BaseModel
    {
        public String ClassifyName { get; set; }
        public decimal SortNo { get; set; }
    }
}
