﻿using System;
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
            int InterfaceID = 1;

            //获取视图名称
            var ifDal = Host.GetService<InterfacesDal>();
            var interfaces = ifDal.GetModel(InterfaceID);

            //获取字段信息
            var fieldSetDal = Host.GetService<FieldSetDal>();
            var fields = fieldSetDal.GetModels(where: $"InterfaceID={InterfaceID}");

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
            var queryParameters = queryParameterDal.GetModels(where: $"InterfaceID={InterfaceID}");

            JoinContext joinContext = new JoinContext();
            joinContext.Args = new[] { "2" };
            joinContext.Interfaces = interfaces;
            joinContext.QueryFields = fieldStr;
            joinContext.FieldSets = fields.ToDictionary(k => k.FieldName, v => v);
            joinContext.QueryParameters = queryParameters.ToDictionary(k => k.ParaName, v => v);
            joinContext.SourceDataProvider = iDataProvider;
            joinContext.TargetDataProvider = iTargetDataProvider;

            var iDataTransfer = Host.GetServices<IDataTransfer>().ToList();
            iDataTransfer[0].DataTransfer(joinContext);

            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }
    }
}