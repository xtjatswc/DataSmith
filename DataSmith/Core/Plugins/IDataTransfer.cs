using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Plugins
{
    public interface IDataTransfer
    {
        void DataTransfer(DataTable dt);
    }
}
