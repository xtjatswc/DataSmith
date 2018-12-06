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
        public MySQLProvider()
        {

        }

        public override DBType DbType => DBType.MySQL;

        public override string ConnStr
        {
            set
            {
                Db = new DbContext().ConnectionString(value, new MySqlProvider());
            }
        }
    }
}
