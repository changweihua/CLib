using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace CLib.CImage
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	ImageStringHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Image
     * 文 件 名:	ImageStringHelper
     * 创建时间:	2013/2/23 10:47:57
     * 作    者:	常伟华 Changweihua
	 * 版    权:	ImageStringHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	d2fbeeb4-eeae-4e2b-9acb-77b7e6a78fd3  
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
    public class ImageStringHelper
    {
        /// <summary>
        /// 图片转字符串
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ImageToString(string fileName)
        {
            string text = string.Empty;

            ImgFormat imgFormat = new ImgFormat();
            //使用该方法，避免独占方式操作图片
            using (FileStream fs = File.OpenRead(fileName))
            {
                using (Image img = Image.FromStream(fs))
                {
                    string extension = fileName.Substring(fileName.LastIndexOf('.'));
                    // MessageBox.Show(ImageFormat.Jpeg.ToString());
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, imgFormat[extension]);
                        text = Convert.ToBase64String(ms.GetBuffer());

                    }
                }
            }

            //注释于 2012-11-25 21:53
            //using (Image img = Image.FromFile(fileName))
            //{
            //    string extension = fileName.Substring(fileName.LastIndexOf('.'));
            //    // MessageBox.Show(ImageFormat.Jpeg.ToString());
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        img.Save(ms, imgFormat[extension]);
            //        text = Convert.ToBase64String(ms.GetBuffer());

            //    }
            //}

            return text;
        }

        /// <summary>
        /// 字符串转图片
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool StringToImage(string text, string fileName)
        {
            bool isSuccess = false;

            //string text = string.Empty;

            //using (StreamReader reader = new StreamReader(fileName1, Encoding.Default))
            //{
            //    text = reader.ReadToEnd();
            //}

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (Bitmap img = new Bitmap(ms))
                {
                    img.Save(fileName);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }

        public static bool FileToImage(string fileName, string saveName)
        {
            bool isSuccess = false;

            string text = string.Empty;

            using (StreamReader reader = new StreamReader(fileName, Encoding.Default))
            {
                text = reader.ReadToEnd();
            }

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (Bitmap img = new Bitmap(ms))
                {
                    img.Save(saveName);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
    }

    /// <summary>
    /// 图片格式类，根据字符串返回指定的图片格式枚举值
    /// </summary>
    public class ImgFormat
    {
        public ImageFormat this[string extension]
        {
            get
            {
                ImageFormat format = null;

                switch (extension)
                {
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                    default:
                        format = ImageFormat.Jpeg;
                        break;
                }
                return format;
            }
        }
    }

}
