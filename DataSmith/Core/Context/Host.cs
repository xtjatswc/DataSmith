using FluentData;
using DataSmith.Core.Config;

namespace DataSmith.Core.Context
{
    public class Host
    {
        public IDbContext db = new DbContext().ConnectionString(LessConfig.db1, new MySqlProvider());
    }
}
