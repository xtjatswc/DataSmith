/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 10:58
 */
using System;
using System.Data;
using System.Collections.Generic;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    /// <summary>
    /// Description of MyClass.
    /// </summary>
    public interface IDataProvider
    {
        IDbContext Db { get; set; }
        DBType DbType { get; }
        string ConnStr { set; }
        IDataProvider Clone();

        bool TestConn();
        DataTable GetDataTable(string sql);
    }

    public enum DBType
    {
        SqlServer = 0,
        Oracle = 1,
        MySQL = 2,
        Sqlite = 3,
        DB2 = 4,
        PostgreSQL = 5
    }
}