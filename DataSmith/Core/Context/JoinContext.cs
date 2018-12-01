using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.DataProvider;

namespace DataSmith.Core.Context
{
    public class JoinContext
    {
        //数据源提供程序
        public IDataProvider SourceDataProvider { get; set; }

        //目标数据源提供程序
        public IDataProvider TargetDataProvider { get; set; }

        //需要传输的数据
        public DataTable Data { get; set; }
    }
}
