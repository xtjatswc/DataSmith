/*
 * 用户： zxs
 * 日期: 2018/6/19
 * 时间: 9:10
 */
using System;
using DataSmith.CNIS.Plugin.AbsIF;
using System.Data;
using System.Threading;
using DataSmith.CNIS.Plugin.Util;
	
namespace DataSmith.CNIS.Plugin.IFace
{
	/// <summary>
	/// 导在院患者的his肠内医嘱信息
	/// </summary>
	public class ImpHisOrder : AbsImpBase
	{
		public ImpHisOrder()
		{

		}
		
		public override void Import()
		{
			string sql = "";
			try {		
				Console.WriteLine("导入在院患者的his医嘱信息");
				
				sql = @"select a.*,b.RYRQ,'' MedicinalType from V_CNIS_HISORDER a 
inner join V_CNIS_ZYBRXX b on a.ZYH = b.ZYH 
where b.CYPB = 0";
				DataTable hisDt = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
				foreach (DataRow hisRow in hisDt.Rows) {
					Import(hisRow);
				}
				
				Console.WriteLine("导入在院患者的cnis FMSP医嘱信息");

				//导cnis的医嘱
				sql = @"select distinct a.HospitalizationNumber ZYH,g.PatientName PatientName,
e.RecipeAndProductCode MedicinalNo,e.RecipeAndProductName OrderText,'FMSP' MedicinalType from patienthospitalizebasicinfo a 
inner join nutrientadvicesummary b on a.PatientHospitalize_DBKey = b.PatientHospitalize_DBKey
inner join nutrientadvice c on b.NutrientAdviceSummary_DBKey = c.NutrientAdviceSummary_DBKey
inner join nutrientadvicedetail d on d.NutrientAdvice_DBKey = c.NutrientAdvice_DBKey
inner join recipeandproduct e on e.RecipeAndProduct_DBKey = d.RecipeAndProduct_DBKey
inner join patientbasicinfo g on g.PATIENT_DBKEY = a.PATIENT_DBKEY
where a.TherapyStatus <> 9";
				DataTable cnisDt = ifObj.TargetDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
				foreach (DataRow cnisRow in cnisDt.Rows) {
					Import(cnisRow);
				}
				
			} catch (Exception ex) {
				Console.WriteLine(ExceptionUtil.getInnerException(ex));
				Thread.Sleep(10000);
			}


			
			//更新已治疗状态
			sql = @"update patienthospitalizebasicinfo a, v_cnis_hisorder b set a.HasHisOrder = 1 where a.HospitalizationNumber = b.ZYH;
update v_cnis_hisorder a, v_cnis_hisorder_dict b set a.MedicinalType = b.MedicinalType where a.MedicinalNo = b.MedicinalNo and a.MedicinalType is not null
";
			int i = ifObj.TargetDataProvider.Db.Sql(sql).Execute();
			
		}
		
		public void Import(DataRow row)
		{
			string ZYH = row["ZYH"].ToString();
			string PatientName = row["PatientName"].ToString();
			string MedicinalNo = row["MedicinalNo"].ToString();
			string OrderText = row["OrderText"].ToString();
			string MedicinalType = row["MedicinalType"].ToString();
						
			string sql = "insert into v_cnis_hisorder(ZYH,PatientName,MedicinalNo,OrderText,MedicinalType) values(@ZYH,@PatientName,@MedicinalNo,@OrderText,@MedicinalType) on duplicate key update OrderText = values(OrderText);";
			int ret = ifObj.TargetDataProvider.Db.Sql(sql)
				.Parameter("ZYH", ZYH)
				.Parameter("PatientName", PatientName)
				.Parameter("MedicinalNo", MedicinalNo)
				.Parameter("OrderText", OrderText)
				.Parameter("MedicinalType", MedicinalType)
				.Execute()
				;
			
		}
	}
}
