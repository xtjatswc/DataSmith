/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 14:15
 */
using System;
using Autofac;
using System.Reflection;
using System.Linq;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Context;

namespace DataSmith.Core.Config
{
	/// <summary>
	/// Description of AutofacConfig.
	/// </summary>
	public class AutofacConfig
	{
		public static void Register()
		{
			//实例化一个autofac的创建容器
			var builder = new ContainerBuilder();
			Assembly ass = Assembly.Load("DataSmith.Core");
			
			var types = default(Type[]);
			
			builder.RegisterType<Host>().SingleInstance();

            //BaseBLL、IBaseDAL
            types = ass.GetTypes().Where(o => o.BaseType != null &&
			(
			    typeof(BaseBLL).IsAssignableFrom(o.BaseType) ||
			    typeof(IBaseDAL).IsAssignableFrom(o.BaseType)
            )
			).ToArray();
			builder.RegisterTypes(types).PropertiesAutowired().AsImplementedInterfaces().SingleInstance();	
			builder.RegisterTypes(types).PropertiesAutowired().SingleInstance();

			//创建一个Autofac的容器
            Host.iContainer = builder.Build();
		}
	}
}
