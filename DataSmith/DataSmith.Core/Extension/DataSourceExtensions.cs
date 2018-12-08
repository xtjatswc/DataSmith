using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Extension
{
    public static class DataSourceExtensions
    {
        public static IDataProvider GetDataProvider(this DataSource dataSource)
        {
            var provider = Host.DataProviderPool[(DBType)dataSource.DBType].Clone();
            provider.ConnStr = dataSource.DBConnStr;
            return provider;
        }

        public static DataBaseType GetDataBaseType(this DataSource dataSource)
        {
            var dal = Host.GetService<DataBaseTypeDal>();
            return dal.GetModel(dataSource.DBType);
        }
    }
}
