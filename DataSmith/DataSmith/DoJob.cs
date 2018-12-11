using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using DataSmith.Core.Plugins;
using DataSmith.Core.Util;
using Quartz;
using Quartz.Impl;

namespace DataSmith
{
    public class DoJob
    {
        public static void Execute()
        {
            JoinContext joinContext = new JoinContext();
            joinContext.Args = Host.Args;

            //根据任务ID获取任务属性
            int taskSchedulerID = Convert.ToInt32(Host.Args[0]);
            var taskSchedulerDal = Host.GetService<TaskSchedulerDal>();
            var taskScheduler = taskSchedulerDal.GetModel(taskSchedulerID);

            string InterfaceID = taskScheduler.InterfaceID;
            foreach (var ifID in InterfaceID.Split(','))
            {
                var ifObj = GetIfObj(ifID);
                joinContext.IfDict.Add(ifObj.Interfaces.ID,ifObj);
            }


            //根据插件ID获取对应的插件并调用
            var iDataTransfer = Host.GetServices<ITransferPlugin>().First(o => o.PluginID == taskScheduler.PluginID);
            iDataTransfer.DataTransfer(joinContext);

            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

        public static InterfaceObj GetIfObj(string interfaceID)
        {
            //获取视图名称
            var ifDal = Host.GetService<InterfacesDal>();
            var interfaces = ifDal.GetModel(interfaceID);

            //获取字段信息
            var fieldSetDal = Host.GetService<FieldSetDal>();
            var fields = fieldSetDal.GetModels(where: $"interfaceID={interfaceID}");

            //拼接sql
            StringBuilder sbField = new StringBuilder();
            foreach (var field in fields)
            {
                if (!string.IsNullOrWhiteSpace(field.FieldAlias))
                {
                    sbField.Append(field.FieldAlias);
                    sbField.Append(",");
                }
            }

            string fieldStr = sbField.ToString().TrimEnd(',');

            //获取数据提供程序
            var dataSource = interfaces.GetDataSource();
            var iDataProvider = dataSource.GetDataProvider();

            var targetDataSource = interfaces.GetTargetDataSource();
            var iTargetDataProvider = targetDataSource.GetDataProvider();

            var queryParameterDal = Host.GetService<QueryParameterDal>();
            var queryParameters = queryParameterDal.GetModels(where: $"interfaceID={interfaceID}");

            InterfaceObj ifObj = new InterfaceObj();
            ifObj.Interfaces = interfaces;
            ifObj.QueryFields = fieldStr;
            //让fieldSet key不区分大小写
            ifObj.FieldSets.Clear();
            foreach (var fieldSet in fields)
            {
                ifObj.FieldSets.Add(fieldSet.FieldName, fieldSet);
            }
            //ifObj.FieldSets = fields.ToDictionary(k => k.FieldName, v => v);
            ifObj.QueryParameters = queryParameters.ToDictionary(k => k.ParaName, v => v);
            ifObj.SourceDataProvider = iDataProvider;
            ifObj.TargetDataProvider = iTargetDataProvider;
            return ifObj;
        }
    }
}
