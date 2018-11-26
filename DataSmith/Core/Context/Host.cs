using System.Collections.Generic;
using System.Linq;
using FluentData;
using DataSmith.Core.Config;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;

namespace DataSmith.Core.Context
{
    public class Host
    {
        public static IContainer iContainer;

        public static IDbContext db = new DbContext().ConnectionString(LessConfig.db1, new MySqlProvider());
        public static IDbContext db1 = new DbContext().ConnectionString(LessConfig.db2, new SqliteProvider());

        public static TService GetService<TService>()
        {
            return iContainer.Resolve<TService>();
        }

        public static IEnumerable<TService> GetServices<TService>()
        {
            var types = iContainer.ComponentRegistry
                .RegistrationsFor(new TypedService(typeof(TService)))
                .Select(x => x.Activator)
                .OfType<ReflectionActivator>()
                .Select(x => x.LimitType);

            return types.Select(t => (TService)iContainer.Resolve(t));
        }
    }
}
