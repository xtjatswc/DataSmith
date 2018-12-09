using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class SqlServerCompact : BaseDataProvider
    {
        public override DBType DbType => DBType.SqlServerCompact;
        public override string ConnStr
        {
            set
            {
                Db = new DbContext().ConnectionString(value, new FluentData.SqlServerCompactProvider());
            }
        }
    }
}
