/*
 * 用户： zxs
 * 日期: 2018/11/26
 * 时间: 14:15
 */
using System;
using System.CodeDom;
using System.IO;
using Autofac;
using System.Reflection;
using System.Linq;
using DataSmith.Core.Infrastructure.Base;
using DataSmith.Core.Context;
using DataSmith.Core.DataProvider;
using System.Windows.Forms;

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
                else if (typeof(IDataProvider).IsAssignableFrom(type.BaseType))
                {
                    builder.RegisterType(type);
                }
            }

            Assembly exeAss = Assembly.Load("DataSmith");
            foreach (var type in exeAss.GetTypes())
            {
                if (typeof(Form).IsAssignableFrom(type))
                {
                    builder.RegisterType(type).SingleInstance();
                }
            }

            //加载插件目录
            var plugin_filename = "Plugin";

            var d = new DirectoryInfo(LessConfig.PluginPath);
            var pluginDlls = (from FileInfo fi in d.GetFiles()
                where (
                    fi.FullName.EndsWith(plugin_filename + ".dll")
                )
                select fi).ToList();
            foreach (var plugin in pluginDlls)
            {
                Assembly assPlugin = Assembly.LoadFile(plugin.FullName);
                //.AsImplementedInterfaces()
                builder.RegisterTypes(assPlugin.GetTypes()).PropertiesAutowired();
            }

            //创建一个Autofac的容器
            return builder.Build();
        }
    }
}
