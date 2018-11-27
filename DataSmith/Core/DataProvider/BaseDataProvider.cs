using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Autofac;
using DataSmith.Core.Context;

namespace DataSmith.Core.DataProvider
{
    public abstract class BaseDataProvider : IDataProvider
    {
        public abstract DBType DbType { get; }
        public abstract string ConnStr { set; }

        public IDataProvider Clone()
        {
            return (IDataProvider) Host.iContainer.Resolve(this.GetType());
        }

        public abstract DataTable GetDataTable(string sql);
    }
}
