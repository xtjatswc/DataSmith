﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.Context;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.DAL;
using Quartz;
using Quartz.Impl;

namespace DataSmith
{
    public class Class1
    {
        public void Test()
        {


            // construct a scheduler factory 
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            // get a scheduler 
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();
            // define the job and tie it to our HelloJob class 
            IJobDetail job = JobBuilder.Create<InterfaceJob>()
                .WithIdentity("myJob", "group1")
                .UsingJobData("InterfaceID", "1")
                .Build();
            // Trigger the job to run now, and then every 40 seconds 
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(400)
                    .RepeatForever())
                .Build();
            sched.ScheduleJob(job, trigger);
        }
    }

    /// <summary>
    /// 作业
    /// </summary>
    public class InterfaceJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            int InterfaceID = dataMap.GetIntValue("InterfaceID");

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
            string sql = $"select {fieldStr} from {interfaces.ViewName}";

            //在数据源中执行sql，获取DataTable
            var dataSource = interfaces.GetDataSource();
            var iDataProvider = dataSource.GetDataProvider();
            var datatable = iDataProvider.GetDataTable(sql);

            //往目标数据库中插入数据
            var targetDataSource = interfaces.GetTargetDataSource();
            var targetDataProvider = targetDataSource.GetDataProvider();
            foreach (DataRow row in datatable.Rows)
            {
                
            }
            
            Console.WriteLine("作业执行，jobSays:" + sql);
        }
    }
}
