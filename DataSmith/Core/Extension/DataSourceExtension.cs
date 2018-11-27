using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Extension
{
    public static class DataSourceExtension
    {
        public static IDataProvider GetDataProvider(this DataSource dataSource)
        {
            var provider = Host.DataProviderPool[(DBType)dataSource.DBType].Clone();
            provider.ConnStr = dataSource.DBConnStr;
            return provider;
        }
    }
}
