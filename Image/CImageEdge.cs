using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CLib.CImage
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	CImageEdge
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.CImage
     * 文 件 名:	CImageEdge
     * 创建时间:	2013/3/6 19:47:21
     * 作    者:	常伟华 Changweihua
	 * 版    权:	CImageEdge说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	5d03e1b6-252e-4f4c-b147-9b7ffaae4949  
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
    /// 图像边缘检测
    /// </summary>
    public class CImageEdge
    {
        //Roberts算子
        //  gx = f(i,j) - f(i+1,j)
        //  gy = f(i+1,j) - f(i,j+1)
        //  g(i,j) = abs(gx) + abs(gy)
        private Bitmap Roberts(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    Color c1 = lbmp.GetPixel(i, j);
                    Color c2 = lbmp.GetPixel(i + 1, j);
                    Color c3 = lbmp.GetPixel(i, j + 1);
                    Color c4 = lbmp.GetPixel(i + 1, j + 1);

                    int r = Math.Abs(c1.R - c4.R) + Math.Abs(c2.R - c3.R);
                    int g = Math.Abs(c1.G - c4.G) + Math.Abs(c2.G - c3.G);
                    int b = Math.Abs(c1.B - c4.B) + Math.Abs(c2.B - c3.B);

                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }

        //Sobel算子
        //  gx = f(i-1,j-1) + 2f(i-1,j) + f(i-1,j+1) - f(i+1,j-1) - 2f(i+1,j) - f(i+1,j+1)
        //  gy = f(i-1,j-1) + 2f(i,j-1) + f(i+1,j-1) - f(i-1,j+1) - 2f(i,j+1) - f(i+1,j+1)
        //  g(i,j) = gx + gy
        private Bitmap Sobel(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c1 = lbmp.GetPixel(i - 1, j - 1);
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c3 = lbmp.GetPixel(i + 1, j - 1);
                    Color c4 = lbmp.GetPixel(i - 1, j);
                    Color c6 = lbmp.GetPixel(i + 1, j);
                    Color c7 = lbmp.GetPixel(i - 1, j + 1);
                    Color c8 = lbmp.GetPixel(i, j + 1);
                    Color c9 = lbmp.GetPixel(i + 1, j + 1);

                    int r1 = c1.R + 2 * c4.R + c7.R - c3.R - 2 * c6.R - c9.R;
                    int r2 = c1.R + 2 * c2.R + c3.R - c7.R - 2 * c8.R - c9.R;
                    int g1 = c1.G + 2 * c4.G + c7.G - c3.G - 2 * c6.G - c9.G;
                    int g2 = c1.G + 2 * c2.G + c3.G - c7.G - 2 * c8.G - c9.G;
                    int b1 = c1.B + 2 * c4.B + c7.B - c3.B - 2 * c6.B - c9.B;
                    int b2 = c1.B + 2 * c2.B + c3.B - c7.B - 2 * c8.B - c9.B;

                    int r = Math.Abs(r1) + Math.Abs(r2);
                    int g = Math.Abs(g1) + Math.Abs(g2);
                    int b = Math.Abs(b1) + Math.Abs(b2);

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                    //newlbmp.SetPixel(i, j, Color.FromArgb(r, r, r));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }

        //拉普拉斯算子（四邻域）
        //  g(i,j) = abs(4f(i,j) - f(i,j-1) - f(i,j+1) - f(i-1,j) - f(i+1,j))
        private Bitmap Laplace4(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c4 = lbmp.GetPixel(i - 1, j);
                    Color c5 = lbmp.GetPixel(i, j);
                    Color c6 = lbmp.GetPixel(i + 1, j);
                    Color c8 = lbmp.GetPixel(i, j + 1);

                    int r = Math.Abs(4 * c5.R - c2.R - c4.R - c6.R - c8.R);
                    int g = Math.Abs(4 * c5.G - c2.G - c4.G - c6.G - c8.G);
                    int b = Math.Abs(4 * c5.B - c2.B - c4.B - c6.B - c8.B);

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }
        private Bitmap Laplace8(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c1 = lbmp.GetPixel(i - 1, j - 1);
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c3 = lbmp.GetPixel(i + 1, j - 1);
                    Color c4 = lbmp.GetPixel(i - 1, j);
                    Color c5 = lbmp.GetPixel(i, j);
                    Color c6 = lbmp.GetPixel(i + 1, j);
                    Color c7 = lbmp.GetPixel(i - 1, j + 1);
                    Color c8 = lbmp.GetPixel(i, j + 1);
                    Color c9 = lbmp.GetPixel(i + 1, j + 1);

                    int r = Math.Abs(8 * c5.R - c1.R - c2.R - c3.R - c4.R - c6.R - c7.R - c8.R - c9.R);
                    int g = Math.Abs(8 * c5.G - c1.G - c2.G - c3.G - c4.G - c6.G - c7.G - c8.G - c9.G);
                    int b = Math.Abs(8 * c5.B - c1.B - c2.B - c3.B - c4.B - c6.B - c7.B - c8.B - c9.B);

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }

        //右下边缘抽出
        //  g(i,j) = abs(2f(i+1,j) + 2f(i,j+1) - 2f(i,j-1) - 2f(i-1,j));
        private Bitmap RightBottomEdge(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c4 = lbmp.GetPixel(i - 1, j);
                    Color c6 = lbmp.GetPixel(i + 1, j);
                    Color c8 = lbmp.GetPixel(i, j + 1);

                    int r = 2 * Math.Abs(c6.R + c8.R - c2.R - c4.R);
                    int g = 2 * Math.Abs(c6.G + c8.G - c2.G - c4.G);
                    int b = 2 * Math.Abs(c6.B + c8.B - c2.B - c4.B);

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }

        //Prewitt边缘检测样板算子（方向为右下）
        //  g(i,j) = abs(f(i-1,j-1) + f(i,j-1) + f(i+1,j-1) + f(i-1,j) + f(i-1,j+1) - f(i+1,j) - f(i,j+1) - f(i+1,j+1) - 2f(i,j))
        //
        //      右下              右上
        //  1   1   1           1   -1  -1
        //  1   -2  -1          1   -2  -1
        //  1   -1  -1          1   1   1
        //
        //      上               下
        //  -1  -1  -1          1   1   1
        //  1   -2  1           1   -2  1
        //  1   1   1           -1  -1  -1
        private Bitmap Prewitt(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c1 = lbmp.GetPixel(i - 1, j - 1);
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c3 = lbmp.GetPixel(i + 1, j - 1);
                    Color c4 = lbmp.GetPixel(i - 1, j);
                    Color c5 = lbmp.GetPixel(i, j);
                    Color c6 = lbmp.GetPixel(i + 1, j);
                    Color c7 = lbmp.GetPixel(i - 1, j + 1);
                    Color c8 = lbmp.GetPixel(i, j + 1);
                    Color c9 = lbmp.GetPixel(i + 1, j + 1);

                    int r = Math.Abs(c1.R + c2.R + c3.R + c4.R + c7.R - c6.R - c8.R - c9.R - 2 * c5.R);
                    int g = Math.Abs(c1.G + c2.G + c3.G + c4.G + c7.G - c6.G - c8.G - c9.G - 2 * c5.R);
                    int b = Math.Abs(c1.B + c2.B + c3.B + c4.B + c7.B - c6.B - c8.B - c9.B - 2 * c5.R);

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }

        //Robinson算子（这里使用第一个）
        //Robinson算子有八个样板，这里列出四个，剩余四个为下面四个的取反
        //
        //  1   2   1               0   1   2
        //  0   0   0               -1  0   1
        //  -1  -2  -1              -2  -1  0
        //
        //  -1  0   1               -2  -1  0
        //  -2  0   2               -1  0   1
        //  -1  0   1               0   -1  2
        private Bitmap Robinson(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c1 = lbmp.GetPixel(i - 1, j - 1);
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c3 = lbmp.GetPixel(i + 1, j - 1);
                    Color c7 = lbmp.GetPixel(i - 1, j + 1);
                    Color c8 = lbmp.GetPixel(i, j + 1);
                    Color c9 = lbmp.GetPixel(i + 1, j + 1);

                    int r = Math.Abs(c1.R + 2 * c2.R + c3.R - c7.R - 2 * c8.R - c9.R);
                    int g = Math.Abs(c1.G + 2 * c2.G + c3.G - c7.G - 2 * c8.G - c9.G);
                    int b = Math.Abs(c1.B + 2 * c2.B + c3.B - c7.B - 2 * c8.B - c9.B);

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }

        //Kirsch算子（这里使用第一个）
        //Kirsch算子有8个边缘样板，与Prewitt边缘样板类似，这里列出一个
        //
        //  5   5   5
        //  -3  0   -3
        //  -3  -3  -3
        //
        private Bitmap Kirsch(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c1 = lbmp.GetPixel(i - 1, j - 1);
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c3 = lbmp.GetPixel(i + 1, j - 1);
                    Color c4 = lbmp.GetPixel(i - 1, j);
                    Color c6 = lbmp.GetPixel(i + 1, j);
                    Color c7 = lbmp.GetPixel(i - 1, j + 1);
                    Color c8 = lbmp.GetPixel(i, j + 1);
                    Color c9 = lbmp.GetPixel(i + 1, j + 1);

                    int r = Math.Abs(5 * (c1.R + c2.R + c3.R) - 3 * (c4.R + c6.R + c7.R + c8.R + c9.R));
                    int g = Math.Abs(5 * (c1.G + c2.G + c3.G) - 3 * (c4.G + c6.G + c7.G + c8.G + c9.G));
                    int b = Math.Abs(5 * (c1.B + c2.B + c3.B) - 3 * (c4.B + c6.B + c7.B + c8.B + c9.B));

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }

        //Smoothed算子
        //  gx = f(i,j) - f(i+1,j)
        //  gy = f(i+1,j) - f(i,j+1)
        //  g(i,j) = abs(gx) + abs(gy)
        private Bitmap Smoothed(Bitmap bmp)
        {
            Bitmap newbmp = new Bitmap(bmp.Width, bmp.Height);
            LockBitmap lbmp = new LockBitmap(bmp);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    Color c1 = lbmp.GetPixel(i - 1, j - 1);
                    Color c2 = lbmp.GetPixel(i, j - 1);
                    Color c3 = lbmp.GetPixel(i + 1, j - 1);
                    Color c4 = lbmp.GetPixel(i - 1, j);
                    Color c6 = lbmp.GetPixel(i + 1, j);
                    Color c7 = lbmp.GetPixel(i - 1, j + 1);
                    Color c8 = lbmp.GetPixel(i, j + 1);
                    Color c9 = lbmp.GetPixel(i + 1, j + 1);

                    int r1 = c3.R + c6.R + c9.R - c1.R - c4.R - c7.R;
                    int r2 = c1.R + c2.R + c3.R - c7.R - c8.R - c9.R;

                    int g1 = c3.G + c6.G + c9.G - c1.G - c4.G - c7.G;
                    int g2 = c1.G + c2.G + c3.G - c7.G - c8.G - c9.G;
                    int b1 = c3.B + c6.B + c9.B - c1.B - c4.B - c7.B;
                    int b2 = c1.B + c2.B + c3.B - c7.B - c8.B - c9.B;

                    int r = Math.Abs(r1) + Math.Abs(r2);
                    int g = Math.Abs(g1) + Math.Abs(g2);
                    int b = Math.Abs(b1) + Math.Abs(b2);

                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    newlbmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                    //newlbmp.SetPixel(i, j, Color.FromArgb(r, r, r));
                }
            }

            lbmp.UnlockBits();
            newlbmp.UnlockBits();

            return newbmp;
        }



    }
}
