/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 10:58
 */
using System;
using System.Data;
using System.Collections.Generic;

namespace DataSmith.Core
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public interface IDataSource
	{
		DataTable GetDataTable();
	}
	
	public enum DBType
	{
		SqlServer=0,
		Oracle=1,
		MySql=2,
		Sqlite=3
	}
}