using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.Config;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class MySQLProvider : BaseDataProvider
    {
        public static IDbContext db;

        public MySQLProvider()
        {

        }

        public override DBType DbType => DBType.MySQL;

        public override string ConnStr
        {
            set
            {
                db = new DbContext().ConnectionString(value, new MySqlProvider());
            }
        }

        public override DataTable GetDataTable(string sql)
        {
            return db.Sql(sql).QuerySingle<DataTable>();
        }
    }
}
