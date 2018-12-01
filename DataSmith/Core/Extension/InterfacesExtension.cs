using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Extension
{
    public static class InterfacesExtension
    {
        public static DataSource GetDataSource(this Interfaces interfaces)
        {
            var dataSourceDal = Host.GetService<DataSourceDal>();
            var dataSource = dataSourceDal.GetModel(interfaces.DataSourceID);
            return dataSource;
        }

        public static DataSource GetTargetDataSource(this Interfaces interfaces)
        {
            var dataSourceDal = Host.GetService<DataSourceDal>();
            var dataSource = dataSourceDal.GetModel(interfaces.TargetDataSourceID);
            return dataSource;
        }
    }
}
