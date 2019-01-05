/*
 * 用户： 张晓松
 * 日期: 2019/1/5
 * 时间: 11:35
 */
using System;
using System.Text;
using DataSmith.Core.Plugins;
using DataSmith.Core.Context;
using System.Threading;
using DataSmith.Core.Util;
using DataSmith.InBody.Plugin.AbsIF;
using DataSmith.InBody.Plugin.IFace;

namespace DataSmith.InBody.Plugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class Export : ITransferPlugin
	{
		public string PluginID{ get { return "{90935630-20C3-44A6-AD67-B347142E4D41}"; } }
		public static JoinContext context;

		public void DataTransfer(JoinContext context)
		{
			Export.context = context;
			var args = context.Args;
			
			try {
				string taskSchedulerID = args[0];
				IImp absImp = null;
				switch (taskSchedulerID) {
					case "12":                        
						Console.WriteLine("12.会员信息 -> 按会员号导入>>>");
						var checkId = args[1];
						absImp = new ImpPatient(){ CheckId = checkId };
						break;
				}		
				absImp.Import();				
			} catch (Exception ex) {
				StringBuilder sb = new StringBuilder();
				ExceptionUtil.JoinErrStackTrace(ex, sb);
				var msg = sb.ToString();
				context.Log.Error(msg, ex);
				Console.WriteLine(msg);
				Thread.Sleep(10000);
			}

		}
	}
}