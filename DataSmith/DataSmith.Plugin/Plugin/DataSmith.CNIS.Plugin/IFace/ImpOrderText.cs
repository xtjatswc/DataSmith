﻿using DataSmith.CNIS.Plugin.AbsIF;
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
	/// <summary>
	/// 批量导膳食医嘱
	/// </summary>
	public class ImpOrderText : AbsImpPatientBase
	{
		//导最近几天的膳食医嘱
		const int nearDays = 7;

		public ImpOrderText()
		{
			
		}
		
		public override void Import()
		{
			string startDate = DateTime.Now.AddDays(-nearDays).ToString("yyyy-MM-dd 00:00:01");
			string endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
			Console.WriteLine("起止时间：从" + startDate + "到" + endDate);

			string sql = @"select a.* from V_CNIS_ClinicalDietaryAdvice  a where a.StopDateTime between '{0}' and '{1}' or a.EnterDateTime between '{0}' and '{1}'  or a.StopOrderDateTime between '{0}' and '{1}'";
			sql = string.Format(sql, startDate, endDate);
			DataTable dt = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
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
			string bahm = row["BAHM"].ToString();
			string ZYH = row["ZYH"].ToString();
			Console.WriteLine(ZYH);			
			string OrderText = row["OrderText"].ToString();
			string StartDateTime = row["StartDateTime"].ToString().Trim();
			
			string StopDateTime = row["StopDateTime"].ToString().Trim();
			
			string Doctor = row["Doctor"].ToString();
			string StopDoctor = row["StopDoctor"].ToString();
			string Nurse = row["Nurse"].ToString();
			string StopNurse = row["StopNurse"].ToString();
			string EnterDateTime = row["EnterDateTime"].ToString().Trim();
		
			string StopOrderDateTime = row["StopOrderDateTime"].ToString().Trim();
			
			string OrderStatus = row["OrderStatus"].ToString();
			string RepeatIndicator = row["RepeatIndicator"].ToString();
			RepeatIndicator = (StopDateTime == "" ? "2" : "1");
			
			string sql = "insert into clinicaldietaryadvice(patient_name,bahm,order_text,start_date_time,stop_date_time,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status,repeat_indicator) values(@patient_name,@bahm,@order_text,@start_date_time,@stop_date_time,@doctor,@stop_doctor,@nurse,@stop_nurse,@enter_date_time,@stop_order_date_time,@order_status,@repeat_indicator) on duplicate key update doctor = values(doctor),stop_doctor = values(stop_doctor),nurse = values(nurse),stop_nurse = values(stop_nurse),enter_date_time = values(enter_date_time),stop_order_date_time = values(stop_order_date_time),order_status = values(order_status),repeat_indicator = values(repeat_indicator); ";
			int ret = ifObj.TargetDataProvider.Db.Sql(sql)
				.Parameter("patient_name", "")
				.Parameter("bahm", ZYH)
				.Parameter("order_text", OrderText)
				.Parameter("start_date_time", StartDateTime)
				.Parameter("stop_date_time", StopDateTime)
				.Parameter("doctor", Doctor)
				.Parameter("stop_doctor", StopDoctor)
				.Parameter("nurse", Nurse)
				.Parameter("stop_nurse", StopDoctor)
				.Parameter("enter_date_time", EnterDateTime)
				.Parameter("stop_order_date_time", StopOrderDateTime)
				.Parameter("order_status", OrderStatus)
				.Parameter("repeat_indicator", RepeatIndicator)
				.Execute();
			
			

		}
	}
}
