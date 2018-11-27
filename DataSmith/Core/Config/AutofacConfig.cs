/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 14:15
 */
using System;
using System.CodeDom;
using Autofac;
using System.Reflection;
using System.Linq;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;

namespace DataSmith.Core.Config
{
    /// <summary>
    /// Description of AutofacConfig.
    /// </summary>
    public class AutofacConfig
    {
        public static IContainer Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();
            Assembly ass = Assembly.Load("DataSmith.Core");

            foreach (var type in ass.GetTypes())
            {
                //BaseBLL、IBaseDAL
                if (
                        type.BaseType != null &&
                        (
                            typeof(BaseBLL).IsAssignableFrom(type.BaseType) ||
                            typeof(IBaseDAL).IsAssignableFrom(type.BaseType)
                        )
                   )
                {
                    builder.RegisterType(type).PropertiesAutowired().SingleInstance();
                }
                else if(typeof(IDataProvider).IsAssignableFrom(type) && !type.IsInterface)
                {
                    builder.RegisterType(type).PropertiesAutowired().SingleInstance();
                }
            }



            //创建一个Autofac的容器
            return builder.Build();
        }
    }
}
