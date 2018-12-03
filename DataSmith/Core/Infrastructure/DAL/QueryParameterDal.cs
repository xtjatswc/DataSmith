﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Infrastructure.DAL
{
    public class QueryParameterDal : BaseDAL<QueryParameter>
    {
        public QueryParameterDal()
            : base()
        {
            Db = Host.db1;
        }

    }
}
