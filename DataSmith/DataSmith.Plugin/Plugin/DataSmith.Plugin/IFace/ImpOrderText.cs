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
	/// <summary>
	/// 批量导膳食医嘱
	/// </summary>
	public class ImpOrderText : AbsImpPatientBase
	{
		//导最近几天的膳食医嘱
		const int nearDays = 7;

		public ImpOrderText()
		{
			DbHelperMySQL.connectionString = PubConstant.GetConnectionString("MysqlConnStr");
			DbHelperSQL.connectionString = PubConstant.GetConnectionString("HisConnStr");

		}
		
		public override void Import()
		{
			string startDate = DateTime.Now.AddDays(-nearDays).ToString("yyyyMMdd00:00:01");
			string endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString("yyyyMMddHH:mm:ss");
			Console.WriteLine("入院起止时间：从" + startDate + "到" + endDate);

			string sql = @"select a.*, b.BRXM from V_CNIS_ClinicalDietaryAdvice  a inner join V_CNIS_ZYBRXX b on a.ZYH  = b.ZYH  where a.StopDateTime between '{0}' and '{1}' or a.EnterDateTime between '{0}' and '{1}'  or a.StopOrderDateTime between '{0}' and '{1}'";
			sql = string.Format(sql, startDate, endDate);
			DataTable dt = DbHelperSQL.Query(sql).Tables[0];
			Console.WriteLine(" count >>>  " + dt.Rows.Count);
			foreach (DataRow row in dt.Rows) {
				try {
					Import(row);
				} catch (Exception ex) {
					Console.WriteLine(ExceptionUtil.getInnerException(ex));
					Thread.Sleep(10000);
				}

			}
			
		}
		
		public void Import(DataRow row)
		{
			string BRXM = row["BRXM"].ToString();
			string bahm = row["BAHM"].ToString();
			string ZYH = row["ZYH"].ToString();
			Console.WriteLine(ZYH);			
			string OrderText = row["OrderText"].ToString();
			string StartDateTime = row["StartDateTime"].ToString().Trim();
			if (StartDateTime != "")
				StartDateTime = DateTime.ParseExact(StartDateTime, "yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");
			
			string StopDateTime = row["StopDateTime"].ToString().Trim();
			if (StopDateTime != "")
				StopDateTime = DateTime.ParseExact(StopDateTime, "yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");
			
			string Doctor = row["Doctor"].ToString();
			string StopDoctor = row["StopDoctor"].ToString();
			string Nurse = row["Nurse"].ToString();
			string StopNurse = row["StopNurse"].ToString();
			string EnterDateTime = row["EnterDateTime"].ToString().Trim();
			if (EnterDateTime != "")
				EnterDateTime = DateTime.ParseExact(EnterDateTime, "yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");
		
			string StopOrderDateTime = row["StopOrderDateTime"].ToString().Trim();
			if (StopOrderDateTime != "")
				StopOrderDateTime = DateTime.ParseExact(StopOrderDateTime, "yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");
			
			string OrderStatus = row["OrderStatus"].ToString();
			string RepeatIndicator = row["RepeatIndicator"].ToString();
			RepeatIndicator = (StopDateTime == "" ? "2" : "1");
			
			string sql = "insert into clinicaldietaryadvice(patient_name,bahm,order_text,start_date_time,stop_date_time,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status,repeat_indicator) values(@patient_name,@bahm,@order_text,@start_date_time,@stop_date_time,@doctor,@stop_doctor,@nurse,@stop_nurse,@enter_date_time,@stop_order_date_time,@order_status,@repeat_indicator) on duplicate key update doctor = values(doctor),stop_doctor = values(stop_doctor),nurse = values(nurse),stop_nurse = values(stop_nurse),enter_date_time = values(enter_date_time),stop_order_date_time = values(stop_order_date_time),order_status = values(order_status),repeat_indicator = values(repeat_indicator); ";
			MySqlParameter[] paras = new MySqlParameter[] {
				new MySqlParameter("patient_name", BRXM),
				new MySqlParameter("bahm", ZYH),
				new MySqlParameter("order_text", OrderText),
				new MySqlParameter("start_date_time", StartDateTime),
				new MySqlParameter("stop_date_time", StopDateTime),
				new MySqlParameter("doctor", Doctor),
				new MySqlParameter("stop_doctor", StopDoctor),
				new MySqlParameter("nurse", Nurse),
				new MySqlParameter("stop_nurse", StopDoctor),
				new MySqlParameter("enter_date_time", EnterDateTime),
				new MySqlParameter("stop_order_date_time", StopOrderDateTime),
				new MySqlParameter("order_status", OrderStatus),
				new MySqlParameter("repeat_indicator", RepeatIndicator),
			};
			int ret = DbHelperMySQL.ExecuteSql(sql, paras);
			
			

		}
	}
}
