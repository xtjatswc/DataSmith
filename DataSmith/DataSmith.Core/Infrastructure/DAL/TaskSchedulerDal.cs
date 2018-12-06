using DataSmith.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Infrastructure.DAL
{
    public class TaskSchedulerDal : BaseDAL<TaskScheduler>
    {
        public TaskSchedulerDal()
            : base()
        {
            Db = Host.db1;
        }
    }
}
