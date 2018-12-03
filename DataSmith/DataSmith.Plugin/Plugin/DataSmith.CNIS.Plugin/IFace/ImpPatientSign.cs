using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmith.CNIS.Plugin.AbsIF;
using System.Data;
using DataSmith.Core.Util;
using DataSmith.Core.Extension;
using DataSmith.Core.Context;

namespace DataSmith.CNIS.Plugin.IFace
{
	/// <summary>
	/// 导住院患者信息
	/// </summary>
	class ImpPatientSign : AbsImpPatientBase
	{
		string zyh;
		
		private string _male;
		
		private JoinContext _context;
		public new JoinContext context { 
			get {
				return _context; 
			}
			set {
				_context = value;
				
				//获取代表男性的字符串
				_male = context.GetTrue("BRXB");
			}
		}


		/// <summary>
		/// 批量循环导患者时调用
		/// </summary>
		/// <param name="his"></param>
		public ImpPatientSign()
		{

		}

		public ImpPatientSign(string zyh)
		{
			this.zyh = zyh;
		}


		public override void Import()
		{
			string sql = "select * from V_CNIS_ZYBRXX where ZYH = '" + zyh + "'";
			DataTable dt = context.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();

			Import(dt.Rows[0]);
		}

		public void Import(DataRow row)
		{
			string BRXM = row.GetString(context.GetFieldAlias("BRXM"));//患者姓名
			string ZYH = row.GetString(context.GetFieldAlias("ZYH"));//住院号
			string YGBH = row.GetString(context.GetFieldAlias("YGBH"));//临床医生工号
			string YGXM = row.GetString(context.GetFieldAlias("YGXM"));//临床医生姓名
			string lcysxmsx = PinYin.GetFirstLetter(YGXM);//临床医生姓名拼音缩写
			string BRKS = row.GetString(context.GetFieldAlias("BRKS"));//科室编码
			string KSMC = row.GetString(context.GetFieldAlias("KSMC"));//科室名称
			string BRCH = row.GetString(context.GetFieldAlias("BRCH"));//床位编号
			string DiseaseCode = row.GetString(context.GetFieldAlias("DiseaseCode"));//疾病编码
			string DiseaseName = row.GetString(context.GetFieldAlias("DiseaseName"));//疾病名称
			string CYPB = row.GetString(context.GetFieldAlias("CYPB"));//出院判别：0在院，8出院，1门诊
			string BAHM = row.GetString(context.GetFieldAlias("BAHM"));//病案号（同一患者多次入院时，该号不变）
			string patientnamefirstletter = PinYin.GetFirstLetter(BRXM);//患者姓名拼音首字母
			
			string gender = (row.GetString(context.GetFieldAlias("BRXB")).Trim() == _male ? "M" : "F"); //M男、F女
			string pbirth = DateTime.ParseExact(row["CSNY"].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");//InPatients.CSNY;
			int age = DateTime.Now.Year - DateTime.Parse(pbirth).Year;
			string HYZK = (row["MaritalStatus"].ToString() == "已婚" ? "1" : "0");
			string RYRQ = "";
			try {
				RYRQ = DateTime.ParseExact(row["RYRQ"].ToString().Trim(), "yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");//InPatients.CSNY;         
			} catch (Exception ex) {
            	
				//throw;
			}
			string ClinicalTreatment = "";// row["ClinicalTreatment"].ToString(); // InPatients.ClinicalTreatment;
			string TELPHONE = row["TELPHONE"].ToString();
			;// row["TELPHONE"].ToString();
			string HOMEADDRESS = row["HOMEADDRESS"].ToString();
			string UrgentContactName = row["UrgentContactName"].ToString();//紧急联系人							
			string UrgentContactTelPhone = row["UrgentContactTelPhone"].ToString();
			string OutHospitalData = "";
			if (row["OutHospitalDate"].ToString().Trim() != "") {
				OutHospitalData = DateTime.ParseExact(row["OutHospitalDate"].ToString().Trim(), "yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");//InPatients.CSNY;
			}
			string Height = row["Height"].ToString();
			string Weight = row["Weight"].ToString();

			//CYPB = "0";			
			Console.WriteLine(BRXM + "	" + RYRQ);

			string sql = "";
			object obj = null;

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
					obj = context.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
					if (obj == null) {
						PATIENT_DBKEY = GetSeed("PATIENT_DBKEY");

						sql = "insert into PatientBasicInfo(PATIENT_DBKEY,patientno,patientname,patientnamefirstletter,gender,age,dateofbirth,maritalstatus,updatetime,telphone,homeaddress,UrgentContactName,UrgentContactTelPhone) 			values(@patientdbkey,@pno,@pname,@pin,@psex,@page,@pbirth,@pmarriage,@CURDATE,@telphone,@homeaddress,@UrgentContactName,@UrgentContactTelPhone);";
						int ret = context.TargetDataProvider.Db.Sql(sql)
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
							.Execute();
					} else {
						PATIENT_DBKEY = obj.ToString();
					}
				}

				#endregion

				#region 住院号是否存在
				string pdhosdbkey = "";
				if (PATIENT_DBKEY.Length > 0 && ZYH.Length > 0) {
					sql = "	select PatientHospitalize_DBKey from patienthospitalizebasicinfo where PATIENT_DBKEY='" + PATIENT_DBKEY + "' and HospitalizationNumber='" + ZYH + "';";
					obj = context.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
					if (obj == null) {
						pdhosdbkey = GetSeed("PatientHospitalize_DBKey");

						sql = "insert into PatientHospitalizeBasicInfo(patienthospitalize_dbkey,patient_dbkey,Disease_DBKEY,department_dbkey,bednumber_dbkey,HospitalizationNumber,inhospitalData,Clinicist_DBKey,TherapyStatus,PhysicalActivityLevel,PregnantCondition,ClinicalTreatment,OutHospitalData,Height,Weight) values(@pdhosdbkey,@patientdbkey,@diseasecode_DBKey,@departdbkey,@beddbkey,@hopno,@intime,@doctorydbkey,0,0,0,@ClinicalTreatment,@OutHospitalData,@Height,@Weight);";
						int ret = context.TargetDataProvider.Db.Sql(sql)
							.Parameter("pdhosdbkey", pdhosdbkey)
							.Parameter("patientdbkey", PATIENT_DBKEY)
							.Parameter("diseasecode_DBKey", Disease_DBKEY)
							.Parameter("departdbkey", Department_DBKey)
							.Parameter("beddbkey", beddbkey)
							.Parameter("hopno", ZYH)
							.Parameter("intime", RYRQ)
							.Parameter("doctorydbkey", doctorydbkey)
							.Parameter("ClinicalTreatment", ClinicalTreatment)
							.Parameter("OutHospitalData", OutHospitalData)
							.Parameter("Height", Height)
							.Parameter("Weight", Weight)
							.Execute();
						
						
						
					} else {
						pdhosdbkey = obj.ToString();
						sql = "update PatientHospitalizeBasicInfo set department_dbkey=@departdbkey,bednumber_dbkey=@beddbkey,Clinicist_DBKey=@doctorydbkey, Height=@height,Weight=@Weight where patienthospitalize_dbkey=@pdhosdbkey;update patientbasicinfo set PatientName = @PatientName where PATIENT_DBKEY = @PATIENT_DBKEY;";
						int ret = context.TargetDataProvider.Db.Sql(sql)
							.Parameter("departdbkey", Department_DBKey)
							.Parameter("beddbkey", beddbkey)
							.Parameter("doctorydbkey", doctorydbkey)
							.Parameter("pdhosdbkey", pdhosdbkey)
							.Parameter("Height", Height)
							.Parameter("Weight", Weight)
							.Parameter("PatientName", BRXM)
							.Parameter("PATIENT_DBKEY", PATIENT_DBKEY)
							.Execute();
					}
				}
				#endregion

			} else if (CYPB == "8") {
				#region 出院
				string pdhosdbkey = "";
				if (ZYH.Length > 0) {
					sql = "	select PatientHospitalize_DBKey from patienthospitalizebasicinfo where HospitalizationNumber='" + ZYH + "';";
					obj = context.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
					if (obj != null) {
						pdhosdbkey = obj.ToString();
						sql = "update PatientHospitalizeBasicInfo set TherapyStatus=9,department_dbkey=@departdbkey,bednumber_dbkey=@beddbkey,Clinicist_DBKey=@doctorydbkey,OutHospitalData=@OutHospitalData,Height=@height,Weight=@Weight  where patienthospitalize_dbkey=@pdhosdbkey;";
						int ret = context.TargetDataProvider.Db.Sql(sql)
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