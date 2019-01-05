/*
 * 用户： 张晓松
 * 日期: 2019/1/5
 * 时间: 12:02
 */
using System;
using System.Data;
using DataSmith.InBody.Plugin.AbsIF;
using DataSmith.Core.Extension;
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.InBody.Plugin.IFace
{
	/// <summary>
	/// Description of ImpPatient.
	/// </summary>
	public class ImpPatient : AbsImpBase
	{
		public string CheckId { get; set; }
		
		//男性
		private readonly string _male;
		private readonly FieldProperties _birthday_Properties;

		public ImpPatient()
		{
			_male = ifObj.GetTrue("sex");
			_birthday_Properties = ifObj.FieldSets["birthday"].GetFieldProperties();
		}
		
		public override void Import()
		{
			string sql = "select " + ifObj.QueryFields + " from " + ifObj.Interfaces.ViewName + " where " + ifObj.GetFieldAlias("check_id") + " = '" + CheckId + "'";
			DataTable dt = ifObj.SourceDataProvider.Db.Sql(sql).QuerySingle<DataTable>();
			if (dt.Rows.Count == 0) {
				Console.WriteLine("未能查询到住会员号为 “" + CheckId + "” 的会员信息！");
				return;
			}

			var row = dt.Rows[0];
			string check_id = row.GetString(ifObj.GetFieldAlias("check_id"));
			string name = row.GetString(ifObj.GetFieldAlias("name"));
			string sex = (row.GetString(ifObj.GetFieldAlias("sex")).Trim() == _male ? "M" : "F"); //M男、F女
			//出生日期
			DateTime? pbirth = null;
			if (_birthday_Properties == null) {
				pbirth = row.GetDateTime(ifObj.GetFieldAlias("birthday"));
			} else {
				pbirth = DateTime.ParseExact(row.GetString(ifObj.GetFieldAlias("birthday")).Trim(), _birthday_Properties.Property2, System.Globalization.CultureInfo.CurrentCulture);
			}
			string height = row.GetString(ifObj.GetFieldAlias("height"));
			string social_no = row.GetString(ifObj.GetFieldAlias("social_no"));
			string patient_id = row.GetString(ifObj.GetFieldAlias("patient_id"));
			string times = row.GetString(ifObj.GetFieldAlias("times"));
			string apply_no = row.GetString(ifObj.GetFieldAlias("apply_no"));

		}
	}
}
