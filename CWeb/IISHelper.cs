using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;

namespace CLib.CWeb
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	IISHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.CWeb
     * 文 件 名:	IISHelper
     * 创建时间:	2013/3/4 9:17:55
     * 作    者:	常伟华 Changweihua
	 * 版    权:	IISHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	b36f9dff-d85a-44db-babf-f08b59624ed4  
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
    public class IISHelper
    {
        public static string GetIISVersion()
        {
            DirectoryEntry getEntity = new DirectoryEntry("IIS://localhost/W3SVC/INFO");
            string Version = getEntity.Properties["MajorIISVersionNumber"].Value.ToString();

            return Version;
        }
    }
}
