using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmith.Core.Context;

namespace DataSmith.CNIS.Plugin.AbsIF
{
    public abstract class AbsImpBase: IImp
    {
    	public JoinContext context = Export.context;
    	public InterfaceObj ifObj = Export.context.IfDict.First().Value;

        public string GetSeed(string seedName)
        {
            string sql = "update seed set CurrentMaxValue = CurrentMaxValue + 1  where seedname  = '" + seedName + "'; select CurrentMaxValue from seed where seedname  = '" + seedName + "'";
            return ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();
        }

        public abstract void Import();
    }
}
