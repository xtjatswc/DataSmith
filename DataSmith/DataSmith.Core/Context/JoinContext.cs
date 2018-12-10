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
        //命令行参数
        public string[] Args { get; set; }

        public Dictionary<Int64, InterfaceObj> IfDict { get; set; } = new Dictionary<Int64, InterfaceObj>(); 
    }
}
