﻿using DataSmith.CNIS.Plugin.AbsIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace DataSmith.CNIS.Plugin.IFace
{
	class ImpConsultation : AbsImpBase
	{
		public string zyh;

		static ImpConsultation()
		{

		}
		
		public override void Import()
		{
			string beginDate = DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd");
			string sql = "select * from V_CNIS_PatientConsultation_i where ";
			if (string.IsNullOrEmpty(zyh)) {
				sql += " (ConsultationDate between sysdate - 15 and sysdate or ApplyTime between sysdate - 15 and sysdate)";
			} else {
				sql += " ZYH = '" + zyh + "'";
			}
        	
			DataTable dt = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
			Console.WriteLine("共计：" + dt.Rows.Count + "条记录");

			foreach (DataRow row in dt.Rows) {
				Import(row);
			}
		}
		public void Import(DataRow row)
		{
			var ZYH = row["HOSPITALIZATIONNUMBER"].ToString();
			try {
				string ConsultationNo = row["ConsultationNo"].ToString();//会诊单号
				string ApplyDepartmentCode = "";//row["ApplyDepartmentCode"].ToString();//申请科室Code
				string ApplyDepartmentName = row["APPLYDEPARTMENT"].ToString();//申请科室
				string ApplyTime = row["ApplyTime"].ToString();//申请时间
				string PatientCondition = row["PatientCondition"].ToString();//患者病情
				string ConsultationReason = row["ConsultationReason"].ToString();//会诊理由
				string ApplyConsultationDoctorName = "";//row["ApplyConsultationDoctorName"].ToString();//申请会诊医师姓名
				string ConsultationDepartmentCode = "";//row["ConsultationDepartmentCode"].ToString();//会诊科室Code
				string ConsultationDepartmentName = row["CONSULTATIONDEPARTMENT"].ToString();//会诊科室
				string ConsultationDate = row["ConsultationDate"].ToString();//会诊时间
				string ConsultationComments = row["ConsultationComments"].ToString();//会诊意见
				string ConsultationDoctorName = row["ConsultationDoctorName"].ToString();//会诊医师姓名
				string ConsultationReplyStatus = row["ConsultationReplyStatus"].ToString();//会诊单处理状态

				Console.WriteLine("住院号：" + ZYH + "	" + ApplyTime);


				string PatientHospitalize_DBKey = "";
				string sql = "	select PatientHospitalize_DBKey from patienthospitalizebasicinfo where  HospitalizationNumber='" + ZYH + "';";
				PatientHospitalize_DBKey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();
				if (PatientHospitalize_DBKey == null) {
					return;
				} 

				//申请科室
				string ApplyDepartment_DBKey = "";
				sql = "	select Department_DBKey from department where DepartmentName='" + ApplyDepartmentName + "';";
				ApplyDepartment_DBKey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();

				//会诊科室
				string ConsultationDepartment_DBKey = "";
				sql = "	select Department_DBKey from department where DepartmentName='" + ConsultationDepartmentName + "';";
				ConsultationDepartment_DBKey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();

				//申请会诊医师
				string ApplyConsultationDoctor_DBKey = "";
				sql = "	select User_DBKey from `user` where UserName='" + ApplyConsultationDoctorName + "';";
				ApplyConsultationDoctor_DBKey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();

				//会诊医师姓名
				string ConsultationDoctor_DBKey = "";
				sql = "	select User_DBKey from `user` where UserName='" + ConsultationDoctorName + "';";
				ConsultationDoctor_DBKey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();

				sql = "select ConsultationNo_DBKey from patientconsultation where ConsultationNo = '" + ConsultationNo + "'";
				string ConsultationNo_DBKey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();

				if (ConsultationNo_DBKey == null) {
					//新增
					ConsultationNo_DBKey = GetSeed("ConsultationNo_DBKey");

					sql = @"INSERT INTO patientconsultation (
									ConsultationNo_DBKey,
									PatientHospitalize_DBKey,
									ConsultationNo,
									ApplyDepartment, -- 申请科室
									ApplyTime,
									PatientCondition, -- 患者病情
									ConsultationReason,	-- 会诊理由
									ApplyConsultationDoctor,-- 申请会诊医师
									ConsultationDepartment,-- 会诊科室
									ConsultationDate,-- 会诊时间
									ConsultationComments,-- 会诊意见
									ConsultationDoctor,-- 会诊医师
									ConsultationReplyStatus,-- 会诊单处理状态 0:未处理;1:已处理
									CreateBy,
									CreateTime,
									CreateProgram,
									CreateIP,
									UpdateBy,
									UpdateTime,
									UpdateProgram,
									UpdateIP,
									ConsultationCKNo
								)
								VALUES
								(
									@ConsultationNo_DBKey,
									@PatientHospitalize_DBKey,
									@ConsultationNo,
									@ApplyDepartment,
									@ApplyTime,
									@PatientCondition,
									@ConsultationReason,
									@ApplyConsultationDoctor,
									@ConsultationDepartment,
									@ConsultationDate,
									@ConsultationComments,
									null,
									@ConsultationReplyStatus,
									null,
									null,
									null,
									null,
									null,
									null,
									null,
									null,
									null
								);";
					
					int ret = ifObj.TargetDataProvider.Db.Sql(sql)
						.Parameter("ConsultationNo_DBKey", ConsultationNo_DBKey)
						.Parameter("PatientHospitalize_DBKey", PatientHospitalize_DBKey)
						.Parameter("ConsultationNo", ConsultationNo)
						.Parameter("ApplyDepartment", ApplyDepartment_DBKey)
						.Parameter("ApplyTime", ApplyTime)
						.Parameter("PatientCondition", PatientCondition)
						.Parameter("ConsultationReason", ConsultationReason)
						.Parameter("ApplyConsultationDoctor", ApplyConsultationDoctor_DBKey)
						.Parameter("ConsultationDepartment", ConsultationDepartment_DBKey)
						.Parameter("ConsultationDate", ConsultationDate)
						.Parameter("ConsultationComments", ConsultationComments)
						.Parameter("ConsultationDoctor", ConsultationDoctor_DBKey)
						.Parameter("ConsultationReplyStatus", ConsultationReplyStatus)
						.Execute();
						
				} else {

					//更新
					sql = @"update patientconsultation set 
									ConsultationDepartment=@ConsultationDepartment,-- 会诊科室
									ConsultationDate=@ConsultationDate,-- 会诊时间
									ConsultationDoctor=@ConsultationDoctor,-- 会诊医师
									ConsultationReplyStatus=@ConsultationReplyStatus-- 会诊单处理状态 0:未处理;1:已处理
									where ConsultationNo_DBKey=@ConsultationNo_DBKey
								;";
					
					int ret = ifObj.TargetDataProvider.Db.Sql(sql)
						.Parameter("ConsultationNo_DBKey", ConsultationNo_DBKey)
						.Parameter("ConsultationDate", ConsultationDate)
						.Parameter("ConsultationDepartment", ApplyDepartment_DBKey)
						.Parameter("ConsultationDoctor", ConsultationDoctor_DBKey)
						.Parameter("ConsultationReplyStatus", ConsultationReplyStatus)
						.Execute();
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				System.Threading.Thread.Sleep(10000);
			}

			//清空历史数据
			//sql = @"delete from patientconsultation where ApplyTime < '" + DateTime.Now.AddDays(-45).ToString("yyyy-MM-dd HH:mm:ss") + "'";
			//int ret2 = DbHelperMySQL.ExecuteSql(sql);
		}
	}
}
