using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.Config;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public class DB2Provider : BaseDataProvider
    {
        public DB2Provider()
        {

        }

        public override DBType DbType => DBType.DB2;

        public override string ConnStr
        {
            set => Db = new DbContext().ConnectionString(value, new FluentData.DB2Provider());
        }

        public override bool TestConn()
        {
            //SELECT 1 FROM sysibm.sysdummy1;
            return Db.Sql("VALUES 1").QuerySingle<Boolean>();
        }

    }
}
