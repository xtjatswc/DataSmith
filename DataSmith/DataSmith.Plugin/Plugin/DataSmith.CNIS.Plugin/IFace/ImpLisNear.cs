using DataSmith.CNIS.Plugin.AbsIF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataSmith.CNIS.Plugin.IFace
{
	/// <summary>
	/// 增量导最近的检验数据 
	/// </summary>
	public class ImpLisNear : AbsImpLisBase
	{
		public ImpLisNear()
		{
           
		}
		
		public override void Import()
		{
			string sql = "";
			DataTable dt = null;
			//所有在院患者
			//sql = @"select a.HospitalizationNumber ZYH from  patienthospitalizebasicinfo a where a.TherapyStatus <> 9";
			//dt = DbHelperSQL.Query(sql).Tables[0];

			//取最近一次检验报告的时间
			sql = "select senttime from laboratoryindex order by senttime desc limit 0, 1";
			string nearTime = context.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();
			
			//增量取最新的未导入检验的患者住院号
			sql = "select  DISTINCT BAHM ZYH from  V_CNIS_TestResult_i where SamTime >= '" + nearTime + "'";
			dt = DbHelperSQL.Query(sql).Tables[0];
			Console.WriteLine(" count >>>  " + dt.Rows.Count);
			ImpLis impLis = new ImpLis();
			foreach (DataRow row in dt.Rows) {
				try {
					string zyh = row["ZYH"].ToString();
					impLis.Import(zyh);
				} catch (Exception ex) {
					Console.WriteLine(ExceptionUtil.getInnerException(ex));
					Thread.Sleep(10000);
				}

			}  

			//DeleteLis();
			sql = @"delete from laboratoryindex where PatientHospitalize_DBKey not in (select PatientHospitalize_DBKey from patienthospitalizebasicinfo);";
			int ret = DbHelperMySQL.ExecuteSql(sql);
		}
		        
	}
}
