using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Autofac;
using DataSmith.Core.Context;
using FluentData;

namespace DataSmith.Core.DataProvider
{
    public abstract class BaseDataProvider : IDataProvider
    {
        public IDbContext Db { get; set; }
        public abstract DBType DbType { get; }
        public abstract string ConnStr { set; }

        public IDataProvider Clone()
        {
            return (IDataProvider) Host.iContainer.Resolve(this.GetType());
        }

        public virtual bool TestConn()
        {
            return Db.Sql("select 1").QuerySingle<Boolean>();
        }

        public virtual DataTable GetDataTable(string sql)
        {
            return Db.Sql(sql).QuerySingle<DataTable>();
        }
    }
}
