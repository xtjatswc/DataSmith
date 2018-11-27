using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class OracleProvider : BaseDataProvider
    {
        public static IDbContext db;

        public override DBType DbType => DBType.Oracle;

        public override string ConnStr
        {
            set => db = new DbContext().ConnectionString(value, new FluentData.OracleProvider());
        }

        public override DataTable GetDataTable(string sql)
        {
            return db.Sql(sql).QuerySingle<DataTable>();
        }
    }
}
