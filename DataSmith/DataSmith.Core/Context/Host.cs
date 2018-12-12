using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentData;
using DataSmith.Core.Config;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;
using DataSmith.Core.DataProvider;
using SqliteProvider = FluentData.SqliteProvider;

namespace DataSmith.Core.Context
{
    public class Host
    {
        public static string[] Args;
        public static string Version;
        public static string ExePath;
        public static IContainer iContainer;
        public static Dictionary<DBType, IDataProvider> DataProviderPool;

        public static log4net.ILog log;

        static Host()
        {
            Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ExePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            iContainer = AutofacConfig.Register();

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo($"{LessConfig.ExecutionPath}Log4net.config"));
            log =
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            DataProviderPool = GetServices<IDataProvider>().ToDictionary(k => k.DbType, v => v);
        }

        public static IDbContext db = new DbContext().ConnectionString(LessConfig.db1, new MySqlProvider());
        public static IDbContext db1 = new DbContext().ConnectionString(LessConfig.db2, new SqliteProvider());
        public static IDbContext db2 = new DbContext().ConnectionString(LessConfig.db3, new SqliteProvider());

        public static TService GetService<TService>()
        {
            return iContainer.Resolve<TService>();
        }

        public static IEnumerable<TService> GetServices<TService>()
        {
            var types = iContainer.ComponentRegistry.Registrations.Where(r => typeof(TService).IsAssignableFrom(r.Activator.LimitType)).Select(r => r.Activator.LimitType);
            return types.Select(t => (TService)iContainer.Resolve(t));
        }
    }
}
