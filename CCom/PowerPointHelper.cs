using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;

namespace CCom
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	PowerPointHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CCom
     * 文 件 名:	PowerPointHelper
     * 创建时间:	2013/3/5 9:39:40
     * 作    者:	常伟华 Changweihua
	 * 版    权:	PowerPointHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	2d7a211f-70aa-40c4-95bc-60a89906d43c  
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
    public class PowerPointHelper
    {
        /// <summary>
        /// PPT 2 PDF
        /// </summary>
        /// <param name="sourcePath">源路径</param>
        /// <param name="targetPath">目标路径</param>
        /// <returns></returns>
        public static bool PPT2PDF(string sourcePath, string targetPath)
        {
            bool result;
            PowerPoint.PpSaveAsFileType targetFileType = PowerPoint.PpSaveAsFileType.ppSaveAsPDF;
            object missing = Type.Missing;
            PowerPoint.ApplicationClass application = null;
            PowerPoint.Presentation persentation = null;
            try
            {
                application = new PowerPoint.ApplicationClass();
                persentation = application.Presentations.Open(sourcePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                persentation.SaveAs(targetPath, targetFileType, Microsoft.Office.Core.MsoTriState.msoTrue);

                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (persentation != null)
                {
                    persentation.Close();
                    persentation = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }
    }
}
