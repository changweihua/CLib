using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLib.Basic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	CalendarHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Basic
     * 文 件 名:	CalendarHelper
     * 创建时间:	2013/2/7 14:12:07
     * 作    者:	常伟华 Changweihua
	 * 版    权:	CalendarHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	f770ca80-c4e1-4ee6-93e9-ce14375961f2  
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
    public class CalendarHelper
    {
        /// <summary>
        /// 获取传入日期为星期几
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string GetWeekString(DateTime dt)
        {
            string week = string.Empty;
            if (dt != null)
            {
                string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                week = Day[Convert.ToInt32(dt.DayOfWeek.ToString("d"))].ToString();
            }

            return week;
        }

        /// <summary>
        /// 获取传入日期字符串为星期几
        /// </summary>
        /// <param name="dateTimeString">日期字符串</param>
        /// <returns></returns>
        public static string GetWeekString(string dateTimeString)
        {
            DateTime dt = new DateTime();
            string week = string.Empty;
            if (DateTime.TryParse(dateTimeString, out dt))
            {
                week = GetWeekString(dt);
            }

            return week;
        }

    }
}
