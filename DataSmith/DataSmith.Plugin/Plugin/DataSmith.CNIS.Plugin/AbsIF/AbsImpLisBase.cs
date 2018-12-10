using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataSmith.CNIS.Plugin.AbsIF
{
	/// <summary>
	/// Description of AbsImpLisBase.
	/// </summary>
	public abstract class AbsImpLisBase : AbsImpBase
	{
		public AbsImpLisBase()
		{
			
		}
		
		public void DeleteLis(int day = 90)
		{
			//同步完成之后清除历史数据
			string sql = @"DELETE a.*, b.*
FROM
	laboratoryindex a 
INNER JOIN testresult b on a.LaboratoryIndex_DBKey = b.LaboratoryIndex_DBKey
WHERE a.TestTime2 < date_add(CURRENT_DATE(), interval -90 day);";
			int ret = ifObj.TargetDataProvider.Db.Sql(sql).Execute();
		}
	}
}
