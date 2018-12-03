using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Infrastructure.Attribute;

namespace DataSmith.Core.Infrastructure.Model
{
    public class FieldProperties
    {
        [PrimaryKey()]
        public Int64 FieldSetID { get; set; }
        /// <summary>
        /// 类别：
        /// 1、二元选择类型，如：性别、婚否
        /// 2、日期转换类型，如从yyyyMMddHH:mm:ss到yyyy-MM-dd HH:mm:ss
        /// 3、字节流大文本
        /// 4、Oracle乱码时，查询转字节流，读取时从字节流转大文本
        /// </summary>
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
    }
}
