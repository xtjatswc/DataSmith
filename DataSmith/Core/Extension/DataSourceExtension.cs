using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Extension
{
    public static class DataSourceExtension
    {
        public static IDataProvider GetDataProvider(this DataSource dataSource)
        {
            return Host.DataProviderPool[(DBType)dataSource.DBType];
        }
    }
}
