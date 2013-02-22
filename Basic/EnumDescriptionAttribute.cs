﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLib.Basic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	EnumDescriptionAttribute
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Basic
     * 文 件 名:	EnumDescriptionAttribute
     * 创建时间:	2013/2/22 11:47:33
     * 作    者:	常伟华 Changweihua
	 * 版    权:	EnumDescriptionAttribute说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	f9ae5873-cf96-4e69-a276-f1e53218e0c7  
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
    /// 自定义枚举属性类
    /// </summary>
    /// 
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDescriptionAttribute : Attribute
    {
        private string text;

        public string Text
        {
            get
            {
                return this.text;
            }
        }

        public EnumDescriptionAttribute(string t)
        {
            this.text = t;
        }

    }
}