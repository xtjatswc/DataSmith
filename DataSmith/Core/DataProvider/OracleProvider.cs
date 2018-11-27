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
        public override DBType DbType => DBType.Oracle;

        public override string ConnStr
        {
            set => Db = new DbContext().ConnectionString(value, new FluentData.OracleProvider());
        }

        public override bool TestConn()
        {
            return Db.Sql("select 1 from dual").QuerySingle<Boolean>();
        }

    }
}
