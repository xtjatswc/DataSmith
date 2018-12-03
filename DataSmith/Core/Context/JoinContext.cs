using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.DataProvider;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Context
{
    public class JoinContext
    {
        //接口模型
        public Interfaces Interfaces { get; set; }

        //查询字段拼接，select ... from 中间的部分
        public string QueryFields { get; set; }

        //字段模型
        public Dictionary<string, FieldSet> FieldSets { get; set; }

        //查询字段模型
        public Dictionary<string, QueryParameter> QueryParameters { get; set; }

        //数据源提供程序
        public IDataProvider SourceDataProvider { get; set; }

        //目标数据源提供程序
        public IDataProvider TargetDataProvider { get; set; }

        //根据接口字段名得到视图别名
        public string GetFieldAlias(string fieldName)
        {
            if(FieldSets.ContainsKey(fieldName))
                return FieldSets[fieldName].FieldAlias;

            return "";
        }

        //得到代表true的字符串标识，如参数传入性别字段，返回“男”或“M”
        public string GetTrue(string fieldName)
        {
            return FieldSets[fieldName].GetFieldProperties().Property2;
        }
    }
}
