using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.Config;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class PostgreSQLProvider : BaseDataProvider
    {
        public PostgreSQLProvider()
        {

        }

        public override DBType DbType => DBType.PostgreSQL;

        public override string ConnStr
        {
            set => Db = new DbContext().ConnectionString(value, new PostgreSqlProvider());
        }
    }
}
