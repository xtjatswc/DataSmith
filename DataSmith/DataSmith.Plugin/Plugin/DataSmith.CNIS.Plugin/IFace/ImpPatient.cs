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
		const int nearDays = 3;
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
				startDate = inBeginDate.Value.ToString("yyyyMMdd00:00:01");
				endDate = inEndDate.Value.ToString("yyyyMMdd23:59:59");
				condition = " and CYPB = 0 ";
			} else {
				/*
				 * 可能的格式：
				 * "yyyyMMdd00:00:01" "yyyyMMddHH:mm:ss"
				 * 				 
				 */
				startDate = DateTime.Now.AddDays(-nearDays).ToString(context.QueryParameters["BeginTime"].Formart);
				endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString(context.QueryParameters["EndTime"].Formart);
			}
			Console.WriteLine("入院起止时间：从" + startDate + "到" + endDate);

			string sql = "select " + context.QueryFields + " from " + context.Interfaces.ViewName + " where (" + context.GetFieldAlias("RYRQ") + " between '{0}' and '{1}' or " + context.GetFieldAlias("OutHospitalDate") + " between '{0}' and '{1}') {2} order by " + context.GetFieldAlias("RYRQ") + " asc";

			sql = string.Format(sql, startDate, endDate, condition);

			DataTable dt = context.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();

			Console.WriteLine("共计" + dt.Rows.Count + "位患者");
			ImpPatientSign sign = new ImpPatientSign{context = context};
			foreach (DataRow patient in dt.Rows) {
				try {
					sign.Import(patient);
				} catch (Exception ex) {
					Console.WriteLine(ExceptionUtil.getInnerException(ex) + ex.StackTrace);
					Thread.Sleep(10000);
				}
	
			}

			//DeletePatientInfo(clearNearDays);

		}
	}
}
