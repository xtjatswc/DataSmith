using DataSmith.CNIS.Plugin.AbsIF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataSmith.CNIS.Plugin.IFace
{
	/// <summary>
	/// 导入检验数据
	/// </summary>
	class ImpLis : AbsImpLisBase
	{
		string bahm;
		
		public ImpLis()
		{
			
		}
		
		public ImpLis(string bahm)
		{
			this.bahm = bahm;           
		}

		public override void Import()
		{
			Import(bahm);
			//DeleteLis();

		}
		
		public void Import(string zyh)
		{
			int ret = 0;
			string sql;

			Console.WriteLine("正在导入检验数据，病案号：" + zyh);

			//从Lis取检验数据
			sql = "select *, ZYH LaboratoryIndexResultNo from V_CNIS_TestResult_i where bahm = '" + zyh + "'";
			DataTable dtLis = context.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();

			if (dtLis.Rows.Count == 0)
				return;

			//获取检验项字典
			SortedDictionary<string, string> testItemDict = new SortedDictionary<string, string>();
			sql = "select TestItemCode, TestItemDetail_DBKey from testitemdetail";
			Console.WriteLine("query testitemdetail");
			DataTable dt = context.TargetDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
			foreach (DataRow row in dt.Rows) {
				if (testItemDict.ContainsKey(row["TestItemCode"].ToString()))
					continue;

				testItemDict.Add(row["TestItemCode"].ToString(), row["TestItemDetail_DBKey"].ToString());
			}

			string sqlGetDBKey = "select b.PatientHospitalize_DBKey from patientbasicinfo a inner join patienthospitalizebasicinfo b on a.patient_dbkey = b.patient_dbkey where b.HospitalizationNumber = '{0}' order by InHospitalData desc limit 0,1";

			string bahm = "";
			string LaboratoryIndexResultNo = "";
			string PatientHospitalize_DBKey = "";
			string LaboratoryIndex_DBKey = "";
			bool IsLabNoImport = true;  //当前检验单号是否已经导入过了
			foreach (DataRow row in dtLis.Rows) {
				try {
					//获取患者的dbkey
					if (bahm != zyh) {
						bahm = zyh;
						sql = string.Format(sqlGetDBKey, bahm);
						Console.WriteLine("query patient");
						PatientHospitalize_DBKey = context.TargetDataProvider.Db.Sql(sql).QuerySingle<string>();
					}

					if (PatientHospitalize_DBKey == null)
						continue;

					//保存检验数据主表信息
					if (LaboratoryIndexResultNo != row["LaboratoryIndexResultNo"].ToString()) {
						LaboratoryIndexResultNo = row["LaboratoryIndexResultNo"].ToString();

						Console.WriteLine(LaboratoryIndexResultNo + "   -   " + row["SamTime"].ToString());
						string SentTime = row["SamTime"].ToString();

						//判断检验单号是否已经导入过了
						sql = "select count(*) cc from laboratoryindex where LaboratoryIndexResultNo = '" + LaboratoryIndexResultNo + "'";
						Console.WriteLine("query laboratoryindex");

						ret = context.TargetDataProvider.Db.Sql(sql).QuerySingle<int>();

						if (ret == 0) {
							IsLabNoImport = false;
							//获取LaboratoryIndex_DBKey自增
							LaboratoryIndex_DBKey = GetSeed("LaboratoryIndex_DBKey");

							//插入检验单号
							sql = "INSERT INTO `laboratoryindex` (`TestType`,`LaboratoryIndex_DBKey`, `PatientHospitalize_DBKey`, `LaboratoryIndexResultNo`, `SentTime`, `TestTime2`, `TestDoctorID`, `CreateTime`, `CreateProgram`, `CreateIP`, `UpdateBy`, `UpdateTime`, `UpdateProgram`, `UpdateIP`) VALUES (@ReportName,@LaboratoryIndex_DBKey, @PatientHospitalize_DBKey, @LaboratoryIndexResultNo, @SentTime, @TestTime2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);";
							Console.WriteLine("insert laboratoryindex");

							//WriteLogFile("D:\\LIS.txt", "插入检验单号前");

							ret = context.TargetDataProvider.Db.Sql(sql)
								.Parameter("ReportName", row["LabNo"].ToString())
								.Parameter("LaboratoryIndex_DBKey", LaboratoryIndex_DBKey)
								.Parameter("PatientHospitalize_DBKey", PatientHospitalize_DBKey)
								.Parameter("LaboratoryIndexResultNo", LaboratoryIndexResultNo)
								.Parameter("SentTime", SentTime)
								.Parameter("TestTime2", SentTime)
								.Execute();

							//WriteLogFile("D:\\LIS.txt", "插入检验单号后");

						} else {
							IsLabNoImport = true;
						}
					}


					if (!IsLabNoImport) {
						//保存检验项

						//获取TestResult_DBKey自增
						string TestResult_DBKey = GetSeed("TestResult_DBKey");

						string TestItemCode = row["TestItemCode"].ToString().Trim();
						string TestItemDetail_DBKey = "";
						string TestItemMinValue = "";
						string TestItemMaxValue = "";

						//refRange
						string range = row["TestItemRangeValue"].ToString();
						try {
							TestItemMinValue = range.Split(new String[] { "～" }, StringSplitOptions.RemoveEmptyEntries)[0];
							TestItemMaxValue = range.Split(new String[] { "～" }, StringSplitOptions.RemoveEmptyEntries)[1];
						} catch {
						}

						if (testItemDict.ContainsKey(TestItemCode)) {
							TestItemDetail_DBKey = testItemDict[TestItemCode];
						} else {
							//获取TestItemDetail_DBKey自增
							TestItemDetail_DBKey = GetSeed("TestItemDetail_DBKey");

							testItemDict.Add(TestItemCode, TestItemDetail_DBKey);


							//插入检验单号
							sql = "INSERT INTO `testitemdetail` (`TestItemDetail_DBKey`, `TestMedium_DBKey`, `TestItemCode`, `TestItemName`, `TestItemUnit`, `TestItemMinValue`, `TestItemMaxValue`, `IsEnabled`) VALUES (@TestItemDetail_DBKey, 1, @TestItemCode, @TestItemName, @TestItemUnit, @TestItemMinValue, @TestItemMaxValue, '1');";

							Console.WriteLine("insert testitemdetail");
							ret = context.TargetDataProvider.Db.Sql(sql)
								.Parameter("TestItemDetail_DBKey", TestItemDetail_DBKey)
								.Parameter("TestItemCode", TestItemCode)
								.Parameter("TestItemName", row["TestItemName"].ToString())
								.Parameter("TestItemUnit", row["TestItemUnit"].ToString().Trim())
								.Parameter("TestItemMinValue", TestItemMinValue)
								.Parameter("TestItemMaxValue", TestItemMaxValue)
								.Execute();

						}


						sql = "INSERT INTO `testresult` (`TestResult_DBKey`, `LaboratoryIndex_DBKey`, `TestItemDetail_DBKey`, `TestResultNo`, `TestItemCode`, `TestItemName`, `TestItemValue`, `TestItemUnit`, `TestItemMaxValue`, `TestItemMinValue`, `IsPositive`, `IsOverMax`, `IsOverMin`, `TestMedium_DBKey`, `CreateBy`, `CreateTime`, `CreateProgram`, `CreateIP`, `UpdateBy`, `UpdateTime`, `UpdateProgram`, `UpdateIP`) VALUES (@TestResult_DBKey, @LaboratoryIndex_DBKey, @TestItemDetail_DBKey, @TestResultNo, @TestItemCode, @TestItemName, @TestItemValue, @TestItemUnit, @TestItemMaxValue, @TestItemMinValue, @IsPositive, @IsOverMax, IsOverMin, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);";
						Console.WriteLine("insert testresult");

						ret = context.TargetDataProvider.Db.Sql(sql)
							.Parameter("TestResult_DBKey", TestResult_DBKey)
							.Parameter("LaboratoryIndex_DBKey", LaboratoryIndex_DBKey)
							.Parameter("TestItemDetail_DBKey", TestItemDetail_DBKey)
							.Parameter("TestResultNo", TestResult_DBKey)
							.Parameter("TestItemCode", TestItemCode)
							.Parameter("TestItemName", row["TestItemName"].ToString())
							.Parameter("TestItemValue", row["TestItemValue"].ToString())
							.Parameter("TestItemUnit", row["TestItemUnit"].ToString().Trim())
							.Parameter("TestItemMaxValue", TestItemMaxValue)
							.Parameter("TestItemMinValue", TestItemMinValue)
							.Parameter("IsPositive", row["IsPositive"].ToString() == "是" ? "1" : "0")
							.Parameter("IsOverMax", "")
							.Parameter("IsOverMin", "")
							.Execute();
						Console.WriteLine("insert testresult end");

					}

				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
					Console.WriteLine(ex.StackTrace);
					Thread.Sleep(5 * 1000);
				}

			}


		}
	}
}
