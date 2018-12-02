/*
 * 用户： 张晓松
 * 日期: 2018/12/1
 * 时间: 17:06
 */
using System;
using System.Data;
using DataSmith.Core.Plugins;
using DataSmith.Core.Context;
using DataSmith.CNIS.Plugin.AbsIF;
using DataSmith.CNIS.Plugin.IFace;

namespace DataSmith.CNIS.Plugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class MyClass : IDataTransfer
	{
        public void DataTransfer(JoinContext context)
        {
        	IImp absImp = new ImpPatient(){context = context};
        	absImp.Import();
        }
	}
}