using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataSmith.Core.DataProvider
{
    public class SqliteProvider : IDataProvider
    {
        public DBType DbType => DBType.Sqlite;

        public DataTable GetDataTable(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
