/*
 * 用户： 张晓松
 * 日期: 2018/12/1
 * 时间: 17:06
 */
using System;
using System.Data;
using DataSmith.Core.Plugins;
using System.Collections.Generic;

namespace DataSmith.Plugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class MyClass : IDataTransfer
	{
        public void DataTransfer(DataTable dt)
        {
        	Console.Write("我是插件！");
        }
	}
}