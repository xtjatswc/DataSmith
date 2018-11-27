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
        public static IDbContext db;

        public MySQLProvider()
        {

        }

        public DBType DbType => DBType.MySQL;

        public string ConnStr
        {
            set
            {
                db = new DbContext().ConnectionString(value, new MySqlProvider());
            }
        }

        public DataTable GetDataTable(string sql)
        {
            return db.Sql(sql).QuerySingle<DataTable>();
        }
    }
}
