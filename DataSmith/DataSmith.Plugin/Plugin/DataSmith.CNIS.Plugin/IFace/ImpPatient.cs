using DataSmith.CNIS.Plugin.AbsIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using DataSmith.CNIS.Plugin.Util;

namespace DataSmith.CNIS.Plugin.IFace
{
	class ImpPatient : AbsImpPatientBase
	{
		//导最近几天的住院患者
		public int nearDays = 3;
		public DateTime? inBeginDate = null;
		public DateTime? inEndDate = null;

		//清空最近多少天的住院患者
		const int clearNearDays = 60;

		public ImpPatient()
		{

		}

		public override void Import()
		{
			string startDate = "";
			string endDate = "";
			string condition = "";
			
			if (inBeginDate != null && inEndDate != null) {
				startDate = inBeginDate.Value.ToString("yyyy-MM-dd 00:00:01");
				endDate = inEndDate.Value.ToString("yyyy-MM-dd 23:59:59");
				condition = " and CYPB = 0 ";
			} else {
				/*
				 * 可能的格式：
				 * "yyyyMMdd00:00:01" "yyyyMMddHH:mm:ss"
				 * 				 
				 */
				startDate = DateTime.Now.AddDays(-nearDays).ToString(ifObj.QueryParameters["BeginTime"].Formart);
				endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString(ifObj.QueryParameters["EndTime"].Formart);
			}
			Console.WriteLine("入院或者出院时间：从" + startDate + "到" + endDate);

			string sql = "select " + ifObj.QueryFields + " from " + ifObj.Interfaces.ViewName + "  where CYPB = 0   order by " + ifObj.GetFieldAlias("RYRQ") + " desc";

			sql = string.Format(sql, nearDays);

			DataTable dt = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();

			DateTime dtNow = DateTime.Now;
			Console.WriteLine("共计" + dt.Rows.Count + "位患者");
			ImpPatientSign sign = new ImpPatientSign{ ifObj = ifObj };
			foreach (DataRow patient in dt.Rows) {
				try {
					sign.Import(patient, dtNow);
				} catch (Exception ex) {
					Console.WriteLine(ExceptionUtil.getInnerException(ex) + ex.StackTrace);
					Thread.Sleep(10000);
				}
	
			}
			
			//更新出院状态
			sql = "update patienthospitalizebasicinfo set TherapyStatus = 9 where UpdateTime <> @0";
			ifObj.TargetDataProvider.Db.Sql(sql, dtNow).Execute();

			//DeletePatientInfo(clearNearDays);

		}
	}
}
