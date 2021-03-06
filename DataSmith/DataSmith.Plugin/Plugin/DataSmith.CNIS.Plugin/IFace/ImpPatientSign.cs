﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmith.CNIS.Plugin.AbsIF;
using System.Data;
using DataSmith.Core.Util;
using DataSmith.Core.Extension;
using DataSmith.Core.Context;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.CNIS.Plugin.IFace
{
	/// <summary>
	/// 导住院患者信息
	/// </summary>
	class ImpPatientSign : AbsImpPatientBase
	{
		string _zyh;
		
		//男性
		private readonly string _male;
		//已婚
		private readonly string _married;
		private readonly FieldProperties _CSNY_Properties;
		private readonly FieldProperties _RYRQ_Properties;
		private readonly FieldProperties _OutHospitalDate_Properties;
	
		/// <summary>
		/// 批量循环导患者时调用
		/// </summary>
		/// <param name="his"></param>
		public ImpPatientSign()
		{
			_male = ifObj.GetTrue("BRXB");
			_married = ifObj.GetTrue("MaritalStatus");
			_CSNY_Properties = ifObj.FieldSets["CSNY"].GetFieldProperties();
			_RYRQ_Properties = ifObj.FieldSets["RYRQ"].GetFieldProperties();
			_OutHospitalDate_Properties = ifObj.FieldSets["OutHospitalDate"].GetFieldProperties();
		}

		public ImpPatientSign(string zyh)
			: this()
		{
			this._zyh = zyh;
		}


		public override void Import()
		{
			string sql = "select * from V_CNIS_ZYBRXX where ZYH = '" + _zyh + "'";
			DataTable dt = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
			if(dt.Rows.Count == 0){
				Console.WriteLine("未能查询到住院号为 “" + _zyh + "” 的患者！");
				return;
			}
			Import(dt.Rows[0], DateTime.Now);
		}

		public void Import(DataRow row, DateTime dtNow)
		{
			string BRXM = row.GetString(ifObj.GetFieldAlias("BRXM"));//患者姓名
			string ZYH = row.GetString(ifObj.GetFieldAlias("ZYH"));//住院号
			string YGBH = row.GetString(ifObj.GetFieldAlias("YGBH"));//临床医生工号
			string YGXM = row.GetString(ifObj.GetFieldAlias("YGXM"));//临床医生姓名
			string lcysxmsx = PinYin.GetFirstLetter(YGXM);//临床医生姓名拼音缩写
			string BRKS = row.GetString(ifObj.GetFieldAlias("BRKS"));//科室编码
			string KSMC = row.GetString(ifObj.GetFieldAlias("KSMC"));//科室名称
			string BRCH = row.GetString(ifObj.GetFieldAlias("BRCH"));//床位编号
			string DiseaseCode = row.GetString(ifObj.GetFieldAlias("DiseaseCode"));//疾病编码
			string DiseaseName = row.GetString(ifObj.GetFieldAlias("DiseaseName"));//疾病名称
			string CYPB = row.GetString(ifObj.GetFieldAlias("CYPB"));//出院判别：0在院，8出院，1门诊
			string BAHM = row.GetString(ifObj.GetFieldAlias("BAHM"));//病案号（同一患者多次入院时，该号不变）
			string patientnamefirstletter = PinYin.GetFirstLetter(BRXM);//患者姓名拼音首字母			
			string gender = (row.GetString(ifObj.GetFieldAlias("BRXB")).Trim() == _male ? "M" : "F"); //M男、F女
			string IDNumber = row.GetString(ifObj.GetFieldAlias("IDNumber"));//身份证号

			//出生日期
			DateTime? pbirth = null;
			if (_CSNY_Properties == null) {
				pbirth = row.GetDateTime(ifObj.GetFieldAlias("CSNY"));
			} else {
				pbirth = DateTime.ParseExact(row.GetString(ifObj.GetFieldAlias("CSNY")).Trim(), _CSNY_Properties.Property2, System.Globalization.CultureInfo.CurrentCulture);
			}
						
			int? age = null;
			if (pbirth != null) {
				age = DateTime.Now.Year - pbirth.Value.Year;
			}
			
			string HYZK = (row.GetString(ifObj.GetFieldAlias("MaritalStatus")).Trim() == _married ? "1" : "0");
			
			DateTime? RYRQ = null;
			if (_RYRQ_Properties == null) {
				RYRQ = row.GetDateTime(ifObj.GetFieldAlias("RYRQ"));
			} else {
				RYRQ = DateTime.ParseExact(row.GetString(ifObj.GetFieldAlias("RYRQ")).Trim(), _RYRQ_Properties.Property2, System.Globalization.CultureInfo.CurrentCulture);   
			}

			string TELPHONE = row.GetString(ifObj.GetFieldAlias("TelPhone"));//联系电话
			string HOMEADDRESS = row.GetString(ifObj.GetFieldAlias("HomeAddress"));//家庭住址
			string UrgentContactName = row.GetString(ifObj.GetFieldAlias("UrgentContactName"));//紧急联系人					
			string UrgentContactTelPhone = row.GetString(ifObj.GetFieldAlias("UrgentContactTelPhone"));//紧急联系电话
			//出院日期
			DateTime? OutHospitalData = null;
			if (_OutHospitalDate_Properties == null) {
				OutHospitalData = row.GetDateTime(ifObj.GetFieldAlias("OutHospitalDate"));
			} else {
				OutHospitalData = DateTime.ParseExact(row.GetString(ifObj.GetFieldAlias("OutHospitalDate")).Trim(), _OutHospitalDate_Properties.Property2, System.Globalization.CultureInfo.CurrentCulture);   
			}
			string Height = row.GetString(ifObj.GetFieldAlias("Height"));
			string Weight = row.GetString(ifObj.GetFieldAlias("Weight"));

			Console.WriteLine(string.Format("{0,-25}住院号：{1,-25}入院日期：{2,-25}  出院日期：{3,-25}", BRXM, ZYH, RYRQ, OutHospitalData));

			string sql = "";

			#region 用户信息
			string doctorydbkey = "";
			ImportUserLimit(YGBH, YGXM, lcysxmsx, out doctorydbkey);
			#endregion

			#region 科室信息
			string Department_DBKey = ImportDepartment(BRKS, KSMC);
			#endregion

			#region 床位信息
			string beddbkey = ImportBedNumber(BRCH, Department_DBKey);
			#endregion

			#region 疾病
			string Disease_DBKEY = ImportDisease(DiseaseCode, DiseaseName);
			#endregion


			if (CYPB == "0") {
				#region 患者基本信息是否存在
				string PATIENT_DBKEY = "";
				if (BAHM.Length > 0) {
					sql = "	select PATIENT_DBKEY from PatientBasicInfo where patientno='" + BAHM + "';";
					PATIENT_DBKEY = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();
					if (PATIENT_DBKEY == null) {
						PATIENT_DBKEY = GetSeed("PATIENT_DBKEY");

						sql = "insert into PatientBasicInfo(PATIENT_DBKEY,patientno,patientname,patientnamefirstletter,gender,age,dateofbirth,maritalstatus,updatetime,telphone,homeaddress,UrgentContactName,UrgentContactTelPhone,IDNumber) 			values(@patientdbkey,@pno,@pname,@pin,@psex,@page,@pbirth,@pmarriage,@CURDATE,@telphone,@homeaddress,@UrgentContactName,@UrgentContactTelPhone,@IDNumber);";
						int ret = ifObj.TargetDataProvider.Db.Sql(sql)
							.Parameter("patientdbkey", PATIENT_DBKEY)
							.Parameter("pno", BAHM)
							.Parameter("pname", BRXM)
							.Parameter("pin", patientnamefirstletter)
							.Parameter("psex", gender)
							.Parameter("page", age)
							.Parameter("pbirth", pbirth)
							.Parameter("pmarriage", HYZK)
							.Parameter("CURDATE", DateTime.Now)
							.Parameter("telphone", TELPHONE)
							.Parameter("homeaddress", HOMEADDRESS)
							.Parameter("UrgentContactName", UrgentContactName)
							.Parameter("UrgentContactTelPhone", UrgentContactTelPhone)
							.Parameter("IDNumber", IDNumber)
							.Execute();
					}
				}

				#endregion

				#region 住院号是否存在
				string pdhosdbkey = "";
				if (PATIENT_DBKEY.Length > 0 && ZYH.Length > 0) {
					sql = "	select PatientHospitalize_DBKey from patienthospitalizebasicinfo where PATIENT_DBKEY='" + PATIENT_DBKEY + "' and HospitalizationNumber='" + ZYH + "';";
					pdhosdbkey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();
					if (pdhosdbkey == null) {
						pdhosdbkey = GetSeed("PatientHospitalize_DBKey");

						sql = "insert into PatientHospitalizeBasicInfo(patienthospitalize_dbkey,patient_dbkey,Disease_DBKEY,department_dbkey,bednumber_dbkey,HospitalizationNumber,inhospitalData,Clinicist_DBKey,TherapyStatus,PhysicalActivityLevel,PregnantCondition,OutHospitalData,Height,Weight,UpdateTime) values(@pdhosdbkey,@patientdbkey,@diseasecode_DBKey,@departdbkey,@beddbkey,@hopno,@intime,@doctorydbkey,0,0,0,@OutHospitalData,@Height,@Weight,@UpdateTime);";
						int ret = ifObj.TargetDataProvider.Db.Sql(sql)
							.Parameter("pdhosdbkey", pdhosdbkey)
							.Parameter("patientdbkey", PATIENT_DBKEY)
							.Parameter("diseasecode_DBKey", Disease_DBKEY)
							.Parameter("departdbkey", Department_DBKey)
							.Parameter("beddbkey", beddbkey)
							.Parameter("hopno", ZYH)
							.Parameter("intime", RYRQ)
							.Parameter("doctorydbkey", doctorydbkey)
							.Parameter("OutHospitalData", OutHospitalData)
							.Parameter("Height", Height)
							.Parameter("Weight", Weight)
							.Parameter("UpdateTime", dtNow)
							.Execute();
						
						
						
					} else {
						sql = "update PatientHospitalizeBasicInfo set department_dbkey=@departdbkey,bednumber_dbkey=@beddbkey,Clinicist_DBKey=@doctorydbkey, Height=@height,Weight=@Weight,UpdateTime=@UpdateTime where patienthospitalize_dbkey=@pdhosdbkey;update patientbasicinfo set PatientName = @PatientName where PATIENT_DBKEY = @PATIENT_DBKEY;";
						int ret = ifObj.TargetDataProvider.Db.Sql(sql)
							.Parameter("departdbkey", Department_DBKey)
							.Parameter("beddbkey", beddbkey)
							.Parameter("doctorydbkey", doctorydbkey)
							.Parameter("pdhosdbkey", pdhosdbkey)
							.Parameter("Height", Height)
							.Parameter("Weight", Weight)
							.Parameter("PatientName", BRXM)
							.Parameter("PATIENT_DBKEY", PATIENT_DBKEY)
							.Parameter("UpdateTime", dtNow)
							.Execute();
					}
				}
				#endregion

			} else if (CYPB == "8") {
				#region 出院
				string pdhosdbkey = "";
				if (ZYH.Length > 0) {
					sql = "	select PatientHospitalize_DBKey from patienthospitalizebasicinfo where HospitalizationNumber='" + ZYH + "';";
					pdhosdbkey = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();
					if (pdhosdbkey != null) {
						sql = "update PatientHospitalizeBasicInfo set TherapyStatus=9,department_dbkey=@departdbkey,bednumber_dbkey=@beddbkey,Clinicist_DBKey=@doctorydbkey,OutHospitalData=@OutHospitalData,Height=@height,Weight=@Weight  where patienthospitalize_dbkey=@pdhosdbkey;";
						int ret = ifObj.TargetDataProvider.Db.Sql(sql)
							.Parameter("departdbkey", Department_DBKey)
							.Parameter("beddbkey", beddbkey)
							.Parameter("doctorydbkey", doctorydbkey)
							.Parameter("pdhosdbkey", pdhosdbkey)
							.Parameter("OutHospitalData", OutHospitalData)
							.Parameter("Height", Height)
							.Parameter("Weight", Weight)
							.Execute();
					}
				}
				#endregion
			}
		}
	}
}