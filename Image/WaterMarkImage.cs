using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace CLib.Image
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	WaterMarkImage
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Image
     * 文 件 名:	WaterMarkImage
     * 创建时间:	2013/2/8 11:20:17
     * 作    者:	常伟华 Changweihua
	 * 版    权:	WaterMarkImage说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	2843ebc5-349f-4022-a0d3-5257260414eb  
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
    public class WaterMarkImage
    {
        public static Bitmap GenerateWaterMark(string waterMarkImage, string waterMarkString)
        {
            Bitmap bm = null;
            ///图片+文字水印  
            using (System.Drawing.Image copyImage = System.Drawing.Image.FromFile(waterMarkImage))
            {

                string strContent = String.Format("@{0}", waterMarkString);
                Font font = new Font("宋体", 12);

                int fontWidth = strContent.Length * 16;//固定了文字的宽度。12大小的文字 用16宽度还行。

                bm = new Bitmap(copyImage.Width + fontWidth, copyImage.Height);
                using (Graphics tempg = Graphics.FromImage(bm))
                {
                    Size fontSize = tempg.MeasureString(strContent, font).ToSize();//为了取文字的高度。

                    tempg.DrawImage(copyImage, new Rectangle(0, 0, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
                    tempg.DrawString(strContent, font, new SolidBrush(Color.FromArgb(255, 85, 85, 85))
                                               , copyImage.Width, bm.Height - fontSize.Height - 2);//文字阴影
                    tempg.DrawString(strContent, font, new SolidBrush(Color.FromArgb(255, Color.White))
                               , copyImage.Width - 1, bm.Height - fontSize.Height - 3);//文字正文

                }
            }

            return bm;
        }

        public static Bitmap WaterMark(string waterMarkImage, string waterMarkString,Stream fromFileStream)
        {
            Bitmap bm = GenerateWaterMark(waterMarkImage, waterMarkString);
            //取得图片对象，并使用流中嵌入的颜色管理信息  
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(fromFileStream, true);
            //新建一个画板  
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(myImage))
            {
                //设置高质量插值法  
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //设置高质量,低速度呈现平滑程度  
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                #region 水印透明度 转换矩阵
                float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                                         new float[] {0, 1, 0, 0, 0},
                                         new float[] {0, 0, 1, 0, 0},
                                         new float[] {0, 0, 0, 0.5f, 0}, //0.5f 就是转换矩阵中调整透明度的值。0.5就是50%透明。
                                         new float[] {0, 0, 0, 0, 1}
                                       };
                ColorMatrix matrix = new ColorMatrix(nArray);
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                #endregion
                //添加水印 放在 图片的右下角
                g.DrawImage(bm, new Rectangle(myImage.Width - bm.Width, myImage.Height - bm.Height, bm.Width, bm.Height), 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel, attributes);
            }

            return bm;
        }

        public static void SaveImage()
        {
            Bitmap bm = WaterMark(@"D:\qq.jpg", "WaterMark", new FileStream(@"D:\vc.png", FileMode.Open));
            bm.Save(@"D:\qq2.png", ImageFormat.Png);
        }

    }
}
