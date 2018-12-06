using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.JsonConfig;
using DataSmith.Core.Infrastructure.Attribute;
using Newtonsoft.Json;

namespace DataSmith.Core.Infrastructure.Base
{
    public class BaseModel
    {
        [PrimaryKey()]
        public Int64 ID { get; set; }

        public string ToJson()
        {
            if (this == null)
                return "";
            return JsonUtil.ToJson(this);
        }
    }
}
