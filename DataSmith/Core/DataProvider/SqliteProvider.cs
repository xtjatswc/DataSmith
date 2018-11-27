using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class SqliteProvider : IDataProvider
    {
        public static IDbContext db;

        public DBType DbType => DBType.Sqlite;
        public string ConnStr
        {
            set
            {
                db = new DbContext().ConnectionString(value, new FluentData.SqliteProvider());
            }
        }

        public DataTable GetDataTable(string sql)
        {
            return db.Sql(sql).QuerySingle<DataTable>();
        }
    }
}
