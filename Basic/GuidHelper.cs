using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLib.CBasic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	GuidHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Basic
     * 文 件 名:	GuidHelper
     * 创建时间:	2013/2/7 14:01:33
     * 作    者:	常伟华 Changweihua
	 * 版    权:	GuidHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	60a09241-973e-4072-80bd-d72b85923faf  
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
    public class GuidHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>格式如: 38bddf48f43c48588e0d78761eaa1ce6 </returns>
        public static string GenerateNString()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>格式如: 57d99d89-caab-482a-a0e9-a0a803eed3ba </returns>
        public static string GenerateDString()
        {
            return Guid.NewGuid().ToString("D");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>格式如: {09f140d5-af72-44ba-a763-c861304b46f8} </returns>
        public static string GenerateBString()
        {
            return Guid.NewGuid().ToString("B");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>格式如: (778406c2-efff-4262-ab03-70a77d09c2b5) </returns>
        public static string GeneratePString()
        {
            return Guid.NewGuid().ToString("P");
        }

    }
}
