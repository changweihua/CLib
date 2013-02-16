using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace CLib.Basic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	XmlTransform
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Basic
     * 文 件 名:	XmlTransform
     * 创建时间:	2013/1/31 10:28:46
     * 作    者:	常伟华 Changweihua
	 * 版    权:	XmlTransform说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	bd5293ad-2d45-4653-93dd-51f43582f95b  
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
    public class XmlTransform
    {
        public static void Transform(string sXmlPath, string sXslPath, string targetPath)
        {
            try
            {
                //load the Xml doc
                XPathDocument myXPathDoc = new XPathDocument(sXmlPath);
                XslTransform myXslTrans = new XslTransform();

                //load the Xsl 
                myXslTrans.Load(sXslPath);

                //create the output stream
                XmlTextWriter myWriter = new XmlTextWriter("result.html", null);

                //do the actual transform of Xml
                myXslTrans.Transform(myXPathDoc, null, myWriter);

                myWriter.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }

        }
    }
}
