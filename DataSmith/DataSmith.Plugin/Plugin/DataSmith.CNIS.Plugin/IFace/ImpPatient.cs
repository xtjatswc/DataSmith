using DataSmith.CNIS.Plugin.AbsIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;

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
				startDate = DateTime.Now.AddDays(-nearDays).ToString("yyyyMMdd00:00:01");
				endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString("yyyyMMddHH:mm:ss");
			}
			Console.WriteLine("入院起止时间：从" + startDate + "到" + endDate);

			string sql = "select * from V_CNIS_ZYBRXX where (RYRQ between '{0}' and '{1}' or OutHospitalDate between '{0}' and '{1}') {2} order by RYRQ asc";
			//string sql = "select top 1000 * from V_CNIS_ZYBRXX  where CYPB<> 8";
			//string sql = "select * from V_CNIS_ZYBRXX where RYRQ between '2018011400:00:01' and '2018031323:59:59' or OutHospitalDate between '2018011400:00:01' and '2018031323:59:59' order by RYRQ asc";

			sql = string.Format(sql, startDate, endDate, condition);

			DataTable dt = DbHelperSQL.Query(sql).Tables[0];

			Console.WriteLine("共计" + dt.Rows.Count + "位患者");
			ImpPatientSign sign = new ImpPatientSign();
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
