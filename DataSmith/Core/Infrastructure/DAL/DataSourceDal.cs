/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 13:59
 */
using System;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Infrastructure.Model;
using DataSmith.Core.Context;

namespace DataSmith.Core.Infrastructure.DAL
{
	/// <summary>
	/// Description of DataSourceDal.
	/// </summary>
	public class DataSourceDal : BaseDAL<DataSource>
	{
		public DataSourceDal()
			: base()
		{
			Db = Host.db1;
		}

	}
}
