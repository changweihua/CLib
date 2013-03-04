using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CLib.CBasic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	FontHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.CBasic
     * 文 件 名:	FontHelper
     * 创建时间:	2013/2/26 11:39:17
     * 作    者:	常伟华 Changweihua
	 * 版    权:	FontHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	292efa74-0e99-4ee6-8923-145eb1844790  
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
    /// 若只使用AddFontResource函数，则重启机器后字体文件消失，此方法字体在机器重启后仍有效
    /// 删除字体功能，需要删除Fonts文件夹下的文件才有效
    /// </summary>
    public class FontHelper
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WriteProfileString(string lpszSection, string lpszKeyName, string lpszString);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, // handle to destination window 
        uint Msg, // message 
        int wParam, // first message parameter 
        int lParam // second message parameter 
        );
        [DllImport("gdi32")]
        public static extern int AddFontResource(string lpFileName);
        [DllImport("gdi32")]
        public static extern int RemoveFontResource(string lpFileName);
        /// <summary>
        /// 安装字体
        /// </summary>
        /// <param name="orginFontPath">原始字体文件所在路径</param>
        public static int installFont(string orginFontPath)
        {
            string WinFontDir = "C://windows//fonts";
            string FontFileName = "my font.TTF";
            string FontName = "my font";
            int Ret = 0;
            int Res;
            string FontPath;
            const int WM_FONTCHANGE = 0x001D;
            const int HWND_BROADCAST = 0xffff;
            FontPath = WinFontDir + "//" + FontFileName;
            if (File.Exists(FontPath))//若已存在则先删除之
            {
                try
                {
                    removeFont(FontPath);
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            if (!File.Exists(FontPath))
            {
                File.Copy(orginFontPath + "//" + FontFileName, FontPath);
                Ret = AddFontResource(FontPath);
                Res = SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0);
                //Ret =
                WriteProfileString("fonts", FontName + "(TrueType)", FontFileName);
            }
            return Ret;
        }
        public static int removeFont(string FontFilePathName)
        {
            RemoveFontResource(FontFilePathName);
            try
            {
                File.Delete(FontFilePathName);
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }
    }
}
