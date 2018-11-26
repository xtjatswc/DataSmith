using FluentData;
using DataSmith.Core.Config;
using Autofac;

namespace DataSmith.Core.Context
{
	public class Host
	{
		public static IContainer iContainer;
		
		public IDbContext db = new DbContext().ConnectionString(LessConfig.db1, new MySqlProvider());
		public IDbContext db1 = new DbContext().ConnectionString(LessConfig.db2, new SqliteProvider());
	}
}
