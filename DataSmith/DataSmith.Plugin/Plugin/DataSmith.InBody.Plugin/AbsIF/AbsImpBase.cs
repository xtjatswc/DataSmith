using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmith.Core.Context;

namespace DataSmith.InBody.Plugin.AbsIF
{
    public abstract class AbsImpBase: IImp
    {
    	public JoinContext context = Export.context;
    	public InterfaceObj ifObj = Export.context.IfDict.First().Value;

        public abstract void Import();
    }
}
