using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class SqlServerProvider : BaseDataProvider
    {
        public override DBType DbType => DBType.SqlServer;

        public override string ConnStr
        {
            set => Db = new DbContext().ConnectionString(value, new FluentData.SqlServerProvider());
        }

    }
}
