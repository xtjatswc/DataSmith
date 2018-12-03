﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmith.Core.JsonConfig;

namespace DataSmith.Core.Extension
{
    public static class HashTableExtension
    {
        #region 获取请求参数
        public static String GetString(this Hashtable ht, String name)
        {
            return Convert.ToString(ht[name]);
        }

        public static int GetInt(this Hashtable ht, String name)
        {
            return Convert.ToInt32(ht[name]);
        }

        public static bool GetBoolean(this Hashtable ht, String name)
        {
            return Convert.ToBoolean(ht[name]);
        }

        public static DateTime GetDateTime(this Hashtable ht, String name)
        {
            return Convert.ToDateTime(ht[name]);
        }

        public static Decimal GetDecimal(this Hashtable ht, String name)
        {
            return Convert.ToDecimal(ht[name]);
        }

        public static dynamic GetObject(this Hashtable ht, String name)
        {
            return JsonUtil.ToObj<dynamic>(GetString(ht, name));
        }

        public static Hashtable GetHashtable(this Hashtable ht, String name)
        {
            return JsonUtil.ToObj<Hashtable>(GetString(ht, name));
        }

        public static List<Hashtable> GetArrayList(this Hashtable ht, String name)
        {
            return JsonUtil.ToObj<List<Hashtable>>(GetString(ht, name));
        }

        public static T Get<T>(this Hashtable ht, String name)
        {
            return JsonUtil.ToObj<T>(GetString(ht, name));
        }

        public static List<T> GetList<T>(this Hashtable ht, String name)
        {
            return JsonUtil.ToObj<List<T>>(GetString(ht, name));
        }

        #endregion
    }
}
