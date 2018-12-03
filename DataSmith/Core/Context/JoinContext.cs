using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Context
{
    public class JoinContext
    {
        //接口模型
        public Interfaces Interfaces { get; set; }

        //字段模型
        public Dictionary<string, FieldSet> FieldSets { get; set; }

        //查询字段模型
        public Dictionary<string, QueryParameter> QueryParameters { get; set; }

        //数据源提供程序
        public IDataProvider SourceDataProvider { get; set; }

        //目标数据源提供程序
        public IDataProvider TargetDataProvider { get; set; }

        //需要传输的数据
        public DataTable Data { get; set; }
    }
}
