using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmith.Core.Util;

namespace DataSmith.CNIS.Plugin.AbsIF
{
	public abstract class AbsImpPatientBase : AbsImpBase
	{

		/// <summary>
		/// 导入用户、角色、权限
		/// </summary>
		/// <param name="YGBH"></param>
		/// <param name="YGXM"></param>
		/// <param name="lcysxmsx"></param>
		/// <param name="doctorydbkey"></param>
		public void ImportUserLimit(string YGBH, string YGXM, string lcysxmsx, out string doctorydbkey)
		{
			string sql = "	select User_DBKey from `user` where userloginid='" + YGBH + "';";
			object obj = context.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
			doctorydbkey = "";
			if (obj == null) {
				//新建用户
				doctorydbkey = GetSeed("User_DBKey");

				sql = "INSERT INTO `user` VALUES (@doctorydbkey,2,@doctorno,@doctorname,  @lcysxmsx , 'c6f057b86584942e415435ffb1fa93d4', '0', '临床医师', null, null, '临床医师', null, '','', '', '', '', '', '0', '1', '', '', '', '', '', '', '', '','1');";

				int ret = context.TargetDataProvider.Db.Sql(sql)
					.Parameter("doctorydbkey", doctorydbkey)
					.Parameter("doctorno", YGBH)
					.Parameter("doctorname", YGXM)
					.Parameter("lcysxmsx", lcysxmsx)
					.Execute();

				#region 用户首页基本设置
				StringBuilder sbSql = new StringBuilder();
				string UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'001','NutritionScreening',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'002','NutritionAdvice',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'003','NutritionAssessment',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'004','WarRoundWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'005','ConsultWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'006','PreparationWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'007','ScreeningWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'008','AssenmentWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'009','AssenmentEndWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'010','PreparationOutWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'011','PreparationFoodWarn',1,0);");
				UserConfig_DBKey = GetSeed("UserConfig_DBKey");
				sbSql.AppendLine("insert into userconfig(userconfig_dbkey,user_dbkey,configcode,configvalue,configstatus,configtype) values(" + UserConfig_DBKey + "," + doctorydbkey + ",'012','AddPatientUser',1,0);");

				ret = context.TargetDataProvider.Db.Sql(sbSql.ToString()).Execute();

				#endregion



				//新建角色
				sql = "update seed set CurrentMaxValue = CurrentMaxValue + 1  where seedname  = 'UserRoleRelation_DBKey'; select CurrentMaxValue from seed where seedname  = 'UserRoleRelation_DBKey'";
				string usrroleid = context.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();

				sql = "	INSERT INTO `userrolerelation` VALUES (@usrroleid,@doctorydbkey, '2', null, null, null, null, null, null, null, null);";
				ret = context.TargetDataProvider.Db.Sql(sql)
					.Parameter("usrroleid", usrroleid)
					.Parameter("doctorydbkey", doctorydbkey)
					.Execute();

				//登陆系统权限
				sql = "update seed set CurrentMaxValue = CurrentMaxValue + 1  where seedname  = 'UserDataAccess_DBKEY'; select CurrentMaxValue from seed where seedname  = 'UserDataAccess_DBKEY'";
				string usraccessid = context.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();

				sql = "	INSERT INTO `userdataaccess` VALUES (@usraccessid,@doctorydbkey, '2', '1', null, null, null, null, null, null, null, null);";
				ret = context.TargetDataProvider.Db.Sql(sql)
					.Parameter("usraccessid", usraccessid)
					.Parameter("doctorydbkey", doctorydbkey)
					.Execute();
			} else {
				doctorydbkey = obj.ToString();
			}
		}

		/// <summary>
		/// 导入科室
		/// </summary>
		/// <param name="BRKS"></param>
		/// <param name="KSMC"></param>
		/// <returns></returns>
		public string ImportDepartment(string BRKS, string KSMC)
		{
			string Department_DBKey = "";
			if (BRKS.Length > 0) {
				string sql = "	select Department_DBKey from department where DepartmentCode='" + BRKS + "';";
				object obj = context.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
				int ret = 0;
				if (obj == null) {
					Department_DBKey = GetSeed("Department_DBKey");

					sql = "	insert into department(department_dbkey,DepartmentCode,DepartmentName,isactive,DepartmentNameFirstLetter)values(@departdbkey,@departno,@departname,1,@DepartmentNameFirstLetter);";
					ret = context.TargetDataProvider.Db.Sql(sql)
						.Parameter("departdbkey", Department_DBKey)
						.Parameter("departno", BRKS)
						.Parameter("departname", KSMC)
						.Parameter("DepartmentNameFirstLetter", PinYin.GetFirstLetter(KSMC))
						.Execute();
				} else {
					Department_DBKey = obj.ToString();
					sql = "	update department set DepartmentName=@DepartmentName where department_dbkey = @department_dbkey;";
					ret = context.TargetDataProvider.Db.Sql(sql)
						.Parameter("department_dbkey", Department_DBKey)
						.Parameter("DepartmentName", KSMC)
						.Execute();

				}
			}

			return Department_DBKey;
		}

		/// <summary>
		/// 导入床号
		/// </summary>
		/// <param name="BRCH"></param>
		/// <param name="Department_DBKey"></param>
		/// <returns></returns>
		public string ImportBedNumber(string BRCH, string Department_DBKey)
		{
			string beddbkey = "";
			if (BRCH.Length > 0 && Department_DBKey.Length > 0) {
				string sql = "	select max(BedNumber_DBKey) from bednumber  where BedCode='" + BRCH + "' and Department_DBKey='" + Department_DBKey + "';";
				object obj = context.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
				if (obj == null) {
					beddbkey = GetSeed("BedNumber_DBKey");

					sql = "	insert into bednumber(BedNumber_DBKey,Department_dbkey,bedcode,bed,isactive) values(@beddbkey,@departdbkey,@bedno,@bedno,1);";
					int ret = context.TargetDataProvider.Db.Sql(sql)
						.Parameter("beddbkey", beddbkey)
						.Parameter("departdbkey", Department_DBKey)
						.Parameter("bedno", BRCH)
						.Execute();
				} else {
					beddbkey = obj.ToString();
				}
			}

			return beddbkey;
		}

		/// <summary>
		/// 导入疾病
		/// </summary>
		/// <param name="diseasecode"></param>
		/// <param name="DiseaseName"></param>
		/// <returns></returns>
		public string ImportDisease(string diseasecode, string DiseaseName)
		{
			string Disease_DBKEY = "";
			if (diseasecode.Length > 0) {
				string sql = "	select Disease_DBKEY from diseaseicd10 where DiseaseClassificationCode='" + diseasecode + "';";
				object obj = context.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
				if (obj == null) {
					Disease_DBKEY = GetSeed("Disease_DBKEY");

					sql = "insert into diseaseicd10(Disease_DBKEY,DiseaseClassificationCode,DiseaseName,IsPrimary)values(@diseasecode_DBKey,@diseasecode,@diseasename,0);";
					int ret = context.TargetDataProvider.Db.Sql(sql)
						.Parameter("diseasecode_DBKey", Disease_DBKEY)
						.Parameter("diseasecode", diseasecode)
						.Parameter("diseasename", DiseaseName)
						.Execute();
				} else {
					Disease_DBKEY = obj.ToString();
				}
			}

			return Disease_DBKEY;
		}

		/// <summary>
		/// 清除在院患者历史数据
		/// </summary>
		/// <param name="day"></param>
		public void DeletePatientInfo(int day = 60)
		{
			//清空历史数据            
			string sql = @"DELETE 
FROM patienthospitalizebasicinfo 
WHERE
	InHospitalData <= date_add(CURRENT_DATE(), interval -" + day + @" day)
AND 
(
	TherapyStatus = 0
	or
	(
		TherapyStatus = 9 and PatientHospitalize_DBKey not in 
		(
			select DISTINCT PatientHospitalize_DBKey from nutrientadvicesummary where PatientHospitalize_DBKey  is not null
		)
	)
);


delete from patientbasicinfo where patient_dbkey not in 
(
	select distinct patient_dbkey from patienthospitalizebasicinfo where patient_dbkey is not null
);

update patienthospitalizebasicinfo a 
left join 
(
select max(a.PatientHospitalize_DBKey) PatientHospitalize_DBKey from patienthospitalizebasicinfo a 
where a.TherapyStatus <> 9 and BedNumber_DBKey <>''
group by a.Department_DBKey,a.BedNumber_DBKey 
) b on a.PatientHospitalize_DBKey = b.PatientHospitalize_DBKey
set a.TherapyStatus = 9
where b.PatientHospitalize_DBKey is null and  TherapyStatus <> 9 and BedNumber_DBKey <>'';

";

			int ret = context.TargetDataProvider.Db.Sql(sql).Execute();
		}

		/// <summary>
		/// 清除门诊患者历史数据
		/// </summary>
		/// <param name="day"></param>
		public void DeleteOPatientInfo(int day = 3)
		{
			//清空历史数据            
			string sql = @"DELETE 
FROM patienthospitalizebasicinfo 
WHERE
	InHospitalData <= date_add(CURRENT_DATE(), interval -" + day + @" day)
AND 
(
	TherapyStatus = 0
	or
	(
		TherapyStatus = 9 and PatientHospitalize_DBKey not in 
		(
			select DISTINCT PatientHospitalize_DBKey from nutrientadvicesummary where PatientHospitalize_DBKey  is not null
		)
	)
) and VisitingTime is not null;


delete from patientbasicinfo where patient_dbkey not in 
(
	select distinct patient_dbkey from patienthospitalizebasicinfo where patient_dbkey is not null
);
";

			int ret = context.TargetDataProvider.Db.Sql(sql).Execute();
		}

		/// <summary>
		/// 清除病历及筛查信息
		/// </summary>
		/// <param name="day"></param>
		public void DeleteEMR(int day = 30)
		{
           
			//清除历史记录
			string sql = @"delete from ai_caseinformation where InHospitalData <= date_add(CURRENT_DATE(), interval -" + day + @" day)";
			int ret = context.TargetDataProvider.Db.Sql(sql).Execute();
				
			sql = @"delete from ai_intelligentscreening where InHospitalData <= date_add(CURRENT_DATE(), interval -" + day + @" day)";
			ret = context.TargetDataProvider.Db.Sql(sql).Execute();
		}
        


	}
}
