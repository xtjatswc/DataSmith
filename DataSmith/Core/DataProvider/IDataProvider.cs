/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 10:58
 */
using System;
using System.Data;
using System.Collections.Generic;

namespace DataSmith.Core.DataProvider
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public interface IDataProvider
    {
	    DBType DbType { get; }
        string ConnStr { set; }
        IDataProvider Clone();
        DataTable GetDataTable(string sql);
	}
	
	public enum DBType
	{
		SqlServer=0,
		Oracle=1,
		MySQL=2,
		Sqlite=3
	}
}