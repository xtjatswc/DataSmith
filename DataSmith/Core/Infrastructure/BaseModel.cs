using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.JsonConfig;
using DataSmith.Core.Infrastructure.Attribute;
using Newtonsoft.Json;

namespace DataSmith.Core.Infrastructure
{
    public class BaseModel
    {
        [PrimaryKey()]
        public string ID { get; set; }
        public Int64 IsDeleted { get; set; }

        public string ToJson()
        {
            if (this == null)
                return "";
            return JsonUtil.ToJson(this);
        }
    }
}
