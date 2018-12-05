using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.JsonConfig;

namespace DataSmith.Core.Extension
{
    public static class ObjectExtensions
    {
        public static string ToJson<T>(this T obj) where T : class
        {
            return JsonUtil.ToJson(obj);
        }

    }
}
