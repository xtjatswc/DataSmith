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
	/// <summary>
	/// 导病历信息
	/// </summary>
	public class ImpEMR : AbsImpPatientBase
	{
		//导最近几天的住院患者病历
		const int nearDays = 3;

		public ImpEMR()
		{

		}
		
		public override void Import()
		{
			string sql = @"select a.PATIENT_DBKEY,b.PatientNo,b.PatientName,a.InHospitalData,a.HospitalizationNumber,b.gender,b.DateOfBirth,a.Height,a.Weight  from patienthospitalizebasicinfo a inner join patientbasicinfo b on a.PATIENT_DBKEY = b.PATIENT_DBKEY
 where a.InHospitalData > '" + DateTime.Now.AddDays(-nearDays).ToString("yyyy-MM-dd") + @"'
order by a.InHospitalData desc";
			DataTable dt = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
			Console.WriteLine(" count >>>  " + dt.Rows.Count);
			foreach (DataRow patient in dt.Rows) {
				try {
					Import(patient);
				} catch (Exception ex) {
					Console.WriteLine(ExceptionUtil.getInnerException(ex));
					Thread.Sleep(10000);
				}

			}
			
			//DeleteEMR();

		}
		
		public void Import(DataRow patient)
		{
			string sql = "";
			
			string patientDBKey = patient["PATIENT_DBKEY"].ToString();
			string PatientNo = patient["PatientNo"].ToString();
			string PatientName = patient["PatientName"].ToString();
			string InHospitalData = patient["InHospitalData"].ToString();
			string HospitalizationNumber = patient["HospitalizationNumber"].ToString();
			Console.WriteLine(PatientName + "   " + InHospitalData);
	                    
	                    
			//取主诉、现病史
			string information1 = "";
			string information2 = "";
			string pastMedicalHistory = "";
	
			sql = "select SB ChiefComplaint, DSB medicalhistory from  V_CNIS_SCREENING_BASIC where 住院号 = '" + HospitalizationNumber + "'";
			DataTable zsTable = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
			
			if (zsTable.Rows.Count > 0) {
				information1 = zsTable.Rows[0]["ChiefComplaint"].ToString();// Encoding.UTF8.GetString((byte[])zsTable.Rows[0]["ChiefComplaint"]);
				information2 = zsTable.Rows[0]["medicalhistory"].ToString();//Encoding.UTF8.GetString((byte[])zsTable.Rows[0]["medicalhistory"]);
				//pastMedicalHistory = zsTable.Rows[0]["PastMedicalHistory"].ToString();
	                    	
			}
	
	
			//取诊断记录
			StringBuilder diagnoseBuilder = new StringBuilder();
			string diagnose = "";
			string diagnose1 = "";
			string diagnose2 = "";
			string diagnose3 = "";
			string createtime1 = "";
			try {
				sql = "select * from  V_CNIS_SCREENING_DIAGNOSE where zyh = '" + HospitalizationNumber + "'";
				DataTable zdTable =ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
				
				foreach (DataRow zdRow in zdTable.Rows) {
					//入院诊断
					diagnose1 = zdRow["diagnose1"].ToString();
					//初步诊断
					diagnose2 = zdRow["diagnose2"].ToString();
					//最后诊断
					diagnose3 = zdRow["diagnose3"].ToString();
		
					string createtime = zdRow["createtime1"].ToString().Trim();
		                        
					diagnoseBuilder.AppendLine("【入院诊断】(" + createtime1 + ")" + diagnose1 + "\r\n"
					+ "【初步诊断】(" + createtime1 + ")" + diagnose2 + "\r\n"
					+ "【最后诊断】(" + createtime1 + ")" + diagnose3 + "\r\n");	                        
				}
				diagnose = diagnoseBuilder.ToString();
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				System.Threading.Thread.Sleep(10000);
			}
	
	
			//体格检查 
			StringBuilder physiqueBuilder = new StringBuilder();
			string physique = "";
			string height = "";
			string weight = "";
			sql = "select * from  V_CNIS_SCREENING_CHECKING where ZYH = '" + HospitalizationNumber + "'";
			DataTable tgTable = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();

			for (int i = 0; i < tgTable.Rows.Count; i++) {
				height = patient["Height"].ToString();// tgTable.Rows[i]["Height"].ToString();
				weight = patient["Weight"].ToString();// tgTable.Rows[i]["Weight"].ToString();

				physiqueBuilder.AppendLine("住院号：" + tgTable.Rows[i]["ZYH"].ToString());
//				physiqueBuilder.AppendLine("体温：" + tgTable.Rows[i]["Temperature"].ToString());
//				physiqueBuilder.AppendLine("心率：" + tgTable.Rows[i]["HeartRate"].ToString());
//				physiqueBuilder.AppendLine("呼吸频率：" + tgTable.Rows[i]["BreathingRate"].ToString());
				physiqueBuilder.AppendLine("身高：" + height);
				physiqueBuilder.AppendLine("体重：" + weight);
//				physiqueBuilder.AppendLine("体表面积：" + tgTable.Rows[i]["BodySurfaceArea"].ToString());
//				physiqueBuilder.AppendLine("卡氏评分：" + tgTable.Rows[i]["KSScore"].ToString());
				physiqueBuilder.AppendLine("查房记录：" + tgTable.Rows[i]["CheckingRecord"].ToString());
				physiqueBuilder.AppendLine("创建时间：" + tgTable.Rows[i]["CreateTime"].ToString());
	
			}
			physique = physiqueBuilder.ToString();
	
			//病程记录
			StringBuilder information4Builder = new StringBuilder();
			sql = "select  * from V_CNIS_SCREENING_PROGRESSNOTE where ZYH = '" + HospitalizationNumber + "'";
			DataTable bcTable = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();

			for (int i = 0; i < bcTable.Rows.Count; i++) {
				information4Builder.AppendLine("患者编号：" + bcTable.Rows[i]["BAHM"].ToString());
				information4Builder.AppendLine("住院号：" + bcTable.Rows[i]["ZYH"].ToString());
				information4Builder.AppendLine("病程记录：" + bcTable.Rows[i]["ProgressNote"].ToString()); //Encoding.UTF8.GetString((byte[])bcTable.Rows[i]["ProgressNote"])
				information4Builder.AppendLine("创建时间：" + bcTable.Rows[i]["CreateTime"].ToString());
	
			}
			string information4 = information4Builder.ToString();
	
	
			//存入患者基本信息表
			sql = "update patienthospitalizebasicinfo set ChiefComplaint=@ChiefComplaint, MedicalHistory=@MedicalHistory,PastMedicalHistory=@pastMedicalHistory,ClinicalDiagnosis=@ClinicalDiagnosis where HospitalizationNumber=@HospitalizationNumber";
			int ret = ifObj.TargetDataProvider.Db.Sql(sql)
				.Parameter("ChiefComplaint", information1)
				.Parameter("MedicalHistory", information2)
				.Parameter("PastMedicalHistory", pastMedicalHistory)
				.Parameter("ClinicalDiagnosis", diagnose)
				.Parameter("HospitalizationNumber", HospitalizationNumber)
				.Execute();
	
			//存入筛查表
			sql = "select count(*) rt from ai_caseinformation where HospitalizationNumber = '" + HospitalizationNumber + "'";
			int count = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<int>();
	
			if (count == 0) {
				//存入数据库
				sql = "INSERT INTO `ai_caseinformation` (`PatientNo`, `HospitalizationNumber`, `InHospitalData`, `PatientName`, `Gender`, `DateOfBirth`, `information1`, `information2`, `information3`, `information4`, `information5`, `information6`, `information7`, `isRun`) VALUES (@PatientNo, @HospitalizationNumber, @InHospitalData, @PatientName, @Gender, @DateOfBirth, @information1, @information2, @information3, @information4, @information5, @information6, @information7, @isRun);";
	
				ret = ifObj.TargetDataProvider.Db.Sql(sql)
					.Parameter("PatientNo", PatientNo)
					.Parameter("HospitalizationNumber", HospitalizationNumber)
					.Parameter("InHospitalData", patient["InHospitalData"])
					.Parameter("PatientName", patient["PatientName"])
					.Parameter("Gender", patient["Gender"])
					.Parameter("DateOfBirth", patient["DateOfBirth"])
					.Parameter("information1", information1)//主诉
					.Parameter("information2", information2)//现病史
					.Parameter("information3", physique)//体格检查
					.Parameter("information4", information4.ToString())//病程记录
					.Parameter("information5", physique)//查房记录
					.Parameter("information6", diagnose)//预留 诊断信息
					.Parameter("information7", "")//预留
					.Parameter("isRun", "0")
					.Execute();
			} else {
				//执行修改
				sql = "update ai_caseinformation set PatientNo=@PatientNo, HospitalizationNumber=@HospitalizationNumber, InHospitalData=@InHospitalData, PatientName=@PatientName, Gender=@Gender, DateOfBirth=@DateOfBirth, information1=@information1, information2=@information2, information3=@information3, information4=@information4, information5=@information5, information6=@information6, information7=@information7  where PatientNo=" + PatientNo;
				ret = ifObj.TargetDataProvider.Db.Sql(sql)
					.Parameter("PatientNo", PatientNo)
					.Parameter("HospitalizationNumber", patient["HospitalizationNumber"])
					.Parameter("InHospitalData", patient["InHospitalData"])
					.Parameter("PatientName", patient["PatientName"])
					.Parameter("Gender", patient["Gender"])
					.Parameter("DateOfBirth", patient["DateOfBirth"])
					.Parameter("information1", information1)//主诉
					.Parameter("information2", information2)//现病史
					.Parameter("information3", physique)//体格检查
					.Parameter("information4", information4.ToString())//病程记录
					.Parameter("information5", physique)//查房记录
					.Parameter("information6", diagnose)//预留 诊断信息
					.Parameter("information7", "")//预留
					.Execute();
	
			}
		}
	}
}
