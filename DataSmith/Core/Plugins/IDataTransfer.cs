using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataSmith.Core.Context;

namespace DataSmith.Core.Plugins
{
    public interface IDataTransfer
    {
        void DataTransfer(JoinContext context);
    }
}
