using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.Config;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class MySQLProvider : IDataProvider
    {
        public static IDbContext db = new DbContext().ConnectionString(LessConfig.db1, new MySqlProvider());

        public MySQLProvider()
        {

        }

        public DBType DbType => DBType.MySQL;

        public DataTable GetDataTable(string sql)
        {
            return db.Sql(sql).QuerySingle<DataTable>();
        }
    }
}
