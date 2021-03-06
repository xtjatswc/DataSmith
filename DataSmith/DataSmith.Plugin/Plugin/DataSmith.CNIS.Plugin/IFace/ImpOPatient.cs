﻿using DataSmith.CNIS.Plugin.AbsIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataSmith.Core.Util;

namespace DataSmith.CNIS.Plugin.IFace
{

    /// <summary>
    /// 导门诊患者信息 计划任务5分钟一次，每次导前5分钟和后5分钟的患者
    /// </summary>
    class ImpOPatient : AbsImpPatientBase
    {
        //清空最近多少天的门诊患者
        const int clearNearDays = 3;
        
        public ImpOPatient() 
        {

        }

        public override void Import()
        {
            string startDate = DateTime.Now.AddDays(-5).ToString("yyyyMMddHH:mm:ss");
            string endDate = DateTime.Now.AddMinutes(5).ToString("yyyyMMddHH:mm:ss");
            Console.WriteLine("门诊起止时间：从" + startDate + "到" + endDate);

            string sql = "select * from V_CNIS_MZBRXX where RYRQ between '"+ startDate +"' and '"+ endDate +"'";
            DataTable dt = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
            Console.WriteLine("共计" + dt.Rows.Count + "位患者");
            foreach (DataRow oPatient in dt.Rows)
            {
                Import(oPatient);
            }

            //DeleteOPatientInfo(clearNearDays);

        }

        public void Import(DataRow InPatients)
        {
        	string BRXM = InPatients["BRXM"].ToString();
            string ZYH = InPatients["MZH"].ToString();
            string YGBH = InPatients["YGBH"].ToString();
            string YGXM = InPatients["YGXM"].ToString();
            string BRKS = InPatients["BRKS"].ToString();
            string lcysxmsx = PinYin.GetFirstLetter(YGXM);
            string KSMC = InPatients["KSMC"].ToString();
            string CYPB = "1";
            string BRCH = "";
            string BAHM = InPatients["MZH"].ToString();
            string patientnamefirstletter = PinYin.GetFirstLetter(BRXM);
            string gender = (InPatients["BRXB"].ToString().Trim()== "1" ? "M" : "F"); //1男、2女
            string pbirth = DateTime.ParseExact(InPatients["CSNY"].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");//
            int age = 0;
            try
            {
                age = DateTime.Now.Year - DateTime.Parse(pbirth).Year;
                //Int32.Parse( row["CS"].ToString().Replace("岁",""));   //
            }
            catch { }
            string HYZK = "1";// InPatients.HYZK;
            string RYRQ = "";
            try{
	            RYRQ = DateTime.ParseExact(InPatients["RYRQ"].ToString().Trim(), "yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");//
            }
            catch{
	            RYRQ = DateTime.ParseExact(InPatients["RYRQ"].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");//
            }
            string diseasecode = "";
            string DiseaseName = "";
            string TELPHONE="",HOMEADDRESS="",UrgentContactName="",UrgentContactTelPhone="";
            string ClinicalDiagnosis="",ClinicalTreatment="", OutHospitalData="";
            string Height="", Weight="";
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
            string Disease_DBKEY = ImportDisease(diseasecode, DiseaseName);
            #endregion


            if (CYPB == "1")
            {
                #region 患者基本信息是否存在
                string PATIENT_DBKEY = "";
                if (BAHM.Length > 0)
                {
                    sql = "	select PATIENT_DBKEY from PatientBasicInfo where patientno='" + BAHM + "';";
                    obj = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
                    if (obj == null)
                    {
                        PATIENT_DBKEY = GetSeed("PATIENT_DBKEY");

                        sql = "insert into PatientBasicInfo(PATIENT_DBKEY,patientno,patientname,patientnamefirstletter,gender,age,dateofbirth,maritalstatus,updatetime,telphone,homeaddress,UrgentContactName,UrgentContactTelPhone) 			values(@patientdbkey,@pno,@pname,@pin,@psex,@page,@pbirth,@pmarriage,@CURDATE,@telphone,@homeaddress,@UrgentContactName,@UrgentContactTelPhone);";
                        int ret = ifObj.TargetDataProvider.Db.Sql(sql)
                        	.Parameter("patientdbkey", PATIENT_DBKEY)
                        	.Parameter("pno",  BAHM)
                        	.Parameter("pname",  BRXM)
                        	.Parameter("pin",  patientnamefirstletter)
                        	.Parameter("psex",  gender)
                        	.Parameter("page",  age)
                        	.Parameter("pbirth",  pbirth)
                        	.Parameter("pmarriage",  HYZK)
                        	.Parameter("CURDATE",  DateTime.Now)
                        	.Parameter("telphone",  TELPHONE)
                        	.Parameter("homeaddress",  HOMEADDRESS)
                        	.Parameter("UrgentContactName",  UrgentContactName)
                        	.Parameter("UrgentContactTelPhone",  UrgentContactTelPhone)
                        	.Execute();
                    }
                    else
                    {
                        PATIENT_DBKEY = obj.ToString();
                    }
                }

                #endregion
               
                #region 住院号是否存在
                string pdhosdbkey = "";
                if (PATIENT_DBKEY.Length > 0 && ZYH.Length > 0)
                {
                    sql = "	select PatientHospitalize_DBKey from patienthospitalizebasicinfo where PATIENT_DBKEY='" + PATIENT_DBKEY + "' and HospitalizationNumber='" + ZYH + "';";
                    obj = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
                    if (obj == null)
                    {
                        pdhosdbkey = GetSeed("PatientHospitalize_DBKey");

                        sql = "insert into PatientHospitalizeBasicInfo(patienthospitalize_dbkey,patient_dbkey,Disease_DBKEY,department_dbkey,bednumber_dbkey,HospitalizationNumber,inhospitalData,Clinicist_DBKey,TherapyStatus,PhysicalActivityLevel,PregnantCondition,ClinicalDiagnosis,ClinicalTreatment,OutHospitalData,VisitingTime) values(@pdhosdbkey,@patientdbkey,@diseasecode_DBKey,@departdbkey,@beddbkey,@hopno,@intime,@doctorydbkey,@TherapyStatus,0,0,@ClinicalDiagnosis,@ClinicalTreatment,@OutHospitalData,@VisitingTime);";
                        int ret = ifObj.TargetDataProvider.Db.Sql(sql)
                        	.Parameter("pdhosdbkey", pdhosdbkey)
                        	.Parameter("patientdbkey",  PATIENT_DBKEY)
                        	.Parameter("diseasecode_DBKey",  Disease_DBKEY)
                        	.Parameter("departdbkey",  Department_DBKey)
                        	.Parameter("beddbkey",  beddbkey)
                        	.Parameter("hopno",  ZYH)
                        	.Parameter("intime",  RYRQ)
                        	.Parameter("doctorydbkey",  doctorydbkey)
                        	.Parameter("ClinicalDiagnosis", ClinicalDiagnosis)
                        	.Parameter("ClinicalTreatment", ClinicalTreatment)
                        	.Parameter("OutHospitalData",  OutHospitalData)
                        	.Parameter("TherapyStatus",  "9")
                        	.Parameter("VisitingTime",  RYRQ)
                        	.Execute();
                    }
                    else
                    {
                        pdhosdbkey = obj.ToString();
                        sql = "update PatientHospitalizeBasicInfo set department_dbkey=@departdbkey,bednumber_dbkey=@beddbkey,Clinicist_DBKey=@doctorydbkey where patienthospitalize_dbkey=@pdhosdbkey;";
                        int ret = ifObj.TargetDataProvider.Db.Sql(sql)
                        	.Parameter("departdbkey", Department_DBKey)
                        	.Parameter("beddbkey",  beddbkey)
                        	.Parameter("doctorydbkey",  doctorydbkey)
                        	.Parameter("pdhosdbkey",  pdhosdbkey)
                        	.Execute();
                    }
                }
                #endregion
                
            }
            else if (CYPB == "8")
            {
                #region 出院
                string pdhosdbkey = "";
                if (ZYH.Length > 0)
                {
                    sql = "	select PatientHospitalize_DBKey from patienthospitalizebasicinfo where HospitalizationNumber='" + ZYH + "';";
                    obj = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<object>();
                    if (obj != null)
                    {
                        pdhosdbkey = obj.ToString();
                        sql = "update PatientHospitalizeBasicInfo set TherapyStatus=9,department_dbkey=@departdbkey,bednumber_dbkey=@beddbkey,Clinicist_DBKey=@doctorydbkey,OutHospitalData=@OutHospitalData, Height=@Height,Weight=@Weight  where patienthospitalize_dbkey=@pdhosdbkey;";
                        int ret = ifObj.TargetDataProvider.Db.Sql(sql)
                        	.Parameter("departdbkey", Department_DBKey)
                        	.Parameter("beddbkey",  beddbkey)
                        	.Parameter("doctorydbkey",  doctorydbkey)
                        	.Parameter("pdhosdbkey",  pdhosdbkey)
                        	.Parameter("OutHospitalData",  OutHospitalData)
                        	.Parameter("Height",  Height)
                        	.Parameter("Weight",  Weight)
                        	.Execute();
                    }
                }
                #endregion
            }
        }
    }
}
