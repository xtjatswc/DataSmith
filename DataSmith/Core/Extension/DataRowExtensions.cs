/*
 * 用户： zxs
 * 日期: 2018/12/3
 * 时间: 14:07
 */
using System;
using System.Data;
using DataSmith.Core.Context; 
using DataSmith.Core.Infrastructure.Model;

namespace DataSmith.Core.Extension
{
    /// <summary>
    /// Description of DataRowExtension.
    /// </summary>
    public static class DataRowExtensions
	{
	    public static string GetString(this DataRow row, string fieldAlias)
	    {
	        if (fieldAlias == "")
	            return "";

	        return Convert.ToString(row[fieldAlias]);
	    }

	    public static DateTime? GetDateTime(this DataRow row, string fieldAlias)
	    {
	        if (fieldAlias == "")
	            return null;

	        try
	        {
	            return Convert.ToDateTime(row[fieldAlias]);
	        }
            catch (InvalidCastException e)
            {
                return default(DateTime?);

            }
        }
	}
}
