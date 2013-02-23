using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CLib.CBasic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	EnumHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Basic
     * 文 件 名:	EnumHelper
     * 创建时间:	2013/2/22 11:45:06
     * 作    者:	常伟华 Changweihua
	 * 版    权:	EnumHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	4a60993b-ec44-46b0-bcf2-d145033e0a00  
	 *
	 * 登录用户:	Changweihua
	 * 所 属 域:	Lumia800

	 * 创建年份:	2013
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    #endregion

    /// <summary>
    /// 摘要
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// 遍历Enum枚举项，判断是否存在，如果存在，返回，否则，返回默认值
        /// </summary>
        /// <typeparam name="T">枚举类类型</typeparam>
        /// <param name="str">查询字符串</param>
        /// <returns>结果</returns>
        public static T Contains<T>(string str)
        {
            T t = default(T);

            if (!string.IsNullOrEmpty(str))
            {
                foreach (string name in Enum.GetNames(typeof(T)))
                {
                    if (string.Compare(name, str, true) == 0)
                    {
                        t = (T)Enum.Parse(typeof(T), name, false);
                    }
                }
            }

            return t;
        }


        /// <summary>
        /// Enum转换成List
        /// </summary>
        /// <typeparam name="T">Enum类型</typeparam>
        /// <returns></returns>
        public static List<string> EnumToList<T>()
        {
            List<string> list = new List<string>();
            foreach (string name in Enum.GetNames(typeof(T)))
            {
                list.Add(name);
            }

            return list;
        }



        public static List<EnumDescription> EnumToDescriptionList<T>()
        {
            List<EnumDescription> list = new List<EnumDescription>();
            EnumDescription ed = null;
            foreach (string name in Enum.GetNames(typeof(T)))
            {
                T t = Contains<T>(name);
                string desc = GetEnumDescription<T>(t);
                ed = new EnumDescription { Name = name, Description = desc };
                list.Add(ed);
            }

            return list;
        }

        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private static string GetName(System.Type t, object v)
        {
            try
            {
                return Enum.GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static string GetName(object v)
        {
            try
            {
                return Enum.GetName(v.GetType(), v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }


        /// <summary>
        /// 返回指定枚举类型的指定值的描述
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <param name="v">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(System.Type t, object v)
        {
            try
            {
                FieldInfo oFieldInfo = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])oFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }
        /// <summary>
        /// 返回指定枚举类型的指定值的描述
        /// </summary>
        /// <param name="v">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(object v)
        {
            try
            {
                Type t = v.GetType();
                FieldInfo oFieldInfo = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])oFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }


        /// <summary>
        /// 过滤Enum项
        /// </summary>
        /// <typeparam name="T">Enum类型</typeparam>
        /// <param name="filters">需要过滤的枚举项的名称</param>
        /// <returns></returns>
        public static List<string> EnumFilter<T>(string[] filters)
        {
            List<string> list = new List<string>();
            foreach (string name in Enum.GetNames(typeof(T)))
            {
                foreach (string filter in filters)
                {
                    if (string.Compare(name, filter, false) == 0)
                    {
                        continue;
                    }
                    list.Add(name);
                }

            }

            return list;
        }

        static StringDictionary enumDescriptions = new StringDictionary();

        public static string GetEnumDescription<EnumType>(EnumType @enum)
        {
            string descriptionContent = string.Empty;

            Type enumType = @enum.GetType();

            string key = enumType.ToString() + "__" + @enum.ToString();

            if (enumDescriptions[key] == null)
            {
                FieldInfo fieldInfo = enumType.GetField(@enum.ToString());
                if (fieldInfo != null)
                {
                    EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
                    if (attributes != null && attributes.Length > 0)
                    {

                        enumDescriptions[key] = attributes[0].Text;

                        return enumDescriptions[key];

                    }
                }

                enumDescriptions[key] = @enum.ToString();
            }

            return enumDescriptions[key];
        }

    }

    public class EnumDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
