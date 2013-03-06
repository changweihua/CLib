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
     * 类 名 称:	CColor
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.CImage
     * 文 件 名:	CColor
     * 创建时间:	2013/3/6 19:43:44
     * 作    者:	常伟华 Changweihua
	 * 版    权:	CColor说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	52ecea36-5960-40af-8aa1-8303651fff13  
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
    public class CColor
    {
        public static void RGB2CMYK(int red, int green, int blue, out double c, out double m, out double y, out double k)
        {
            c = (double)(255 - red) / 255;
            m = (double)(255 - green) / 255;
            y = (double)(255 - blue) / 255;

            k = (double)Math.Min(c, Math.Min(m, y));
            if (k == 1.0)
            {
                c = m = y = 0;
            }
            else
            {
                c = (c - k) / (1 - k);
                m = (m - k) / (1 - k);
                y = (y - k) / (1 - k);
            }
        }
        public static void CMYK2RGB(double c, double m, double y, double k, out int r, out int g, out int b)
        {
            r = Convert.ToInt32((1.0 - c) * (1.0 - k) * 255.0);
            g = Convert.ToInt32((1.0 - m) * (1.0 - k) * 255.0);
            b = Convert.ToInt32((1.0 - y) * (1.0 - k) * 255.0);
        }

        public static void RGB2HSB(int red, int green, int blue, out double hue, out double sat, out double bri)
        {
            double r = ((double)red / 255.0);
            double g = ((double)green / 255.0);
            double b = ((double)blue / 255.0);

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            hue = 0.0;
            if (max == r && g >= b)
            {
                if (max - min == 0) hue = 0.0;
                else hue = 60 * (g - b) / (max - min);
            }
            else if (max == r && g < b)
            {
                hue = 60 * (g - b) / (max - min) + 360;
            }
            else if (max == g)
            {
                hue = 60 * (b - r) / (max - min) + 120;
            }
            else if (max == b)
            {
                hue = 60 * (r - g) / (max - min) + 240;
            }

            sat = (max == 0) ? 0.0 : (1.0 - ((double)min / (double)max));
            bri = max;
        }
        public static void HSB2RGB(double hue, double sat, double bri, out int red, out int green, out int blue)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            if (sat == 0)
            {
                r = g = b = bri;
            }
            else
            {
                // the color wheel consists of 6 sectors. Figure out which sector you're in.
                double sectorPos = hue / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));
                // get the fractional part of the sector
                double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                double p = bri * (1.0 - sat);
                double q = bri * (1.0 - (sat * fractionalSector));
                double t = bri * (1.0 - (sat * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = bri;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = bri;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = bri;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = bri;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = bri;
                        break;
                    case 5:
                        r = bri;
                        g = p;
                        b = q;
                        break;
                }
            }
            red = Convert.ToInt32(r * 255);
            green = Convert.ToInt32(g * 255);
            blue = Convert.ToInt32(b * 255); ;
        }

        public static string RGB2Hex(int r, int g, int b)
        {
            return String.Format("#{0:x2}{1:x2}{2:x2}", (int)r, (int)g, (int)b);
        }
        public static Color Hex2Color(string hexColor)
        {
            string r, g, b;

            if (hexColor != String.Empty)
            {
                hexColor = hexColor.Trim();
                if (hexColor[0] == '#') hexColor = hexColor.Substring(1, hexColor.Length - 1);

                r = hexColor.Substring(0, 2);
                g = hexColor.Substring(2, 2);
                b = hexColor.Substring(4, 2);

                r = Convert.ToString(16 * GetIntFromHex(r.Substring(0, 1)) + GetIntFromHex(r.Substring(1, 1)));
                g = Convert.ToString(16 * GetIntFromHex(g.Substring(0, 1)) + GetIntFromHex(g.Substring(1, 1)));
                b = Convert.ToString(16 * GetIntFromHex(b.Substring(0, 1)) + GetIntFromHex(b.Substring(1, 1)));

                return Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
            }

            return Color.Empty;
        }
        private static int GetIntFromHex(string strHex)
        {
            switch (strHex)
            {
                case ("A"):
                    {
                        return 10;
                    }
                case ("B"):
                    {
                        return 11;
                    }
                case ("C"):
                    {
                        return 12;
                    }
                case ("D"):
                    {
                        return 13;
                    }
                case ("E"):
                    {
                        return 14;
                    }
                case ("F"):
                    {
                        return 15;
                    }
                default:
                    {
                        return int.Parse(strHex);
                    }
            }
        }
    }
}
