using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataSmith.Core.Config
{
    public class LessConfig
    {
        public static readonly string ConfigPath;
        public static readonly string DbPath;

        static LessConfig()
        {
            //从文件目录加载用户配置
            var executionPath = AppDomain.CurrentDomain.BaseDirectory;
            ConfigPath = executionPath + @"config\";
            DbPath = executionPath + @"db\";
            JsonConfig.Config.User = JsonConfig.Config.ApplyFromDirectory(ConfigPath, JsonConfig.Config.User, true);

        }
        
        public static string db1 { get { return JsonConfig.Config.Global.DataBases.db1; } }

        private static string _db2;
        public static string db2
        {
            get
            {
                if (string.IsNullOrEmpty(_db2))
                {
                    //Password=asdf1234;
                    _db2 = string.Format(JsonConfig.Config.Global.DataBases.db2.ToString(), DbPath, "");
                }
                return _db2;
            }
        }

        public static string Copyright { get { return JsonConfig.Config.Global.LessBase.SystemInfo.Copyright; } }
        public static string Version { get { return JsonConfig.Config.Global.LessBase.SystemInfo.Version; } }

    }
}
