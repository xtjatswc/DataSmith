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
using DataSmith.CNIS.Plugin.Util;
using System.Threading;

namespace DataSmith.CNIS.Plugin
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class Export : IDataTransfer
	{
		public static JoinContext context;
		
        public void DataTransfer(JoinContext context)
        {
        	Export.context = context;
        	var args = context.Args;
        	
        	try {
				string flag = args[0];
				IImp absImp = null;
				string zyh = "";

				switch (flag) {
					case "1":                        
						Console.WriteLine("1.按住院号导入单个住院患者信息>>>");
						zyh = args[1];
						absImp = new ImpPatientSign(zyh);
						break;
					case "2":                        
						Console.WriteLine("2.批量导最近几天住院患者信息>>>");
						absImp = new ImpPatient();
						break;
					case "3":                        
						Console.WriteLine("3.批量按入院时间段导住院患者信息>>>");
						absImp = new ImpPatient(){
							inBeginDate = DateTime.Parse(args[1]),
							inEndDate = DateTime.Parse(args[2]),
						};
						break;
					case "4":
						Console.WriteLine("4.批量导最近门诊患者>>>");
						absImp = new ImpOPatient();
						break;
					case "5":
						Console.WriteLine("5.导单个患者检验数据>>>");
						zyh = args[1];
						absImp = new ImpLis(zyh);
						break;
					case "6":
						Console.WriteLine("6.增量导检验数据>>>");
						absImp = new ImpLisNear();
						break;
					case "7":
						Console.WriteLine("7.批量导病历>>>");
						absImp = new ImpEMR();
						break;
					case "8":
						Console.WriteLine("8.批量导膳食医嘱>>>");
						absImp = new ImpOrderText();
						break;
					case "9":
						Console.WriteLine("9.导单个患者会诊>>>");
						zyh = args[1];
						absImp = new ImpConsultation(){zyh = zyh};
						break;
					case "10":
						Console.WriteLine("10.批量导患者会诊>>>");
                        absImp = new ImpConsultation();
						break;
					case "11":                        
						Console.WriteLine("11.导在院患者的his肠内医嘱信息>>>");
						absImp = new ImpHisOrder();
						break;

				}
				absImp.Import();

			} catch (Exception ex) {
				Console.WriteLine(ExceptionUtil.getInnerException(ex));
				Thread.Sleep(10000);
			}
        }
	}
}