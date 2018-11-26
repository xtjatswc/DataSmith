/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 13:57
 */
using System;
using DataSmith.Core.Infrastructure.Base;

namespace DataSmith.Core.Infrastructure.Model
{
    /// <summary>
    /// 数据源
    /// </summary>
    public class DataSource : BaseModel
    {

        public Int64 DBType { get; set; }
        public String DBTypeName { get; set; }
        public String SourceName { get; set; }
        public String IP { get; set; }
        public Int64 Port { get; set; }
        public String DBName { get; set; }
        public String UserID { get; set; }
        public String Password { get; set; }
        public String DBPath { get; set; }
        public String DBConnStr { get; set; }

    }
}
