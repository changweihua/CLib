using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLib.CBasic
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	RandomHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.CBasic
     * 文 件 名:	RandomHelper
     * 创建时间:	2013/3/5 8:53:35
     * 作    者:	常伟华 Changweihua
	 * 版    权:	RandomHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	f3d16e86-79e1-497a-90ee-3d9d5c508171  
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
    public class RandomHelper
    {
        private static Random random = new Random();

        /// <summary>
        /// 生成一个非重复的随机序列。
        /// 创建一个List，用于保存随机生成的数值，每次插入时，先判断这个数值是否已经在List中存在了，如果已经存在，则重新生成。
        /// 时间复杂度是O(N²) ，空间复杂度是O(N)
        /// </summary>
        /// <param name="count">序列长度。</param>
        /// <returns>序列。</returns>
        public static List<int> BuildRandomSequence1(int length)
        {
            List<int> list = new List<int>();
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    num = random.Next(0, length);
                } while (list.Contains(num));
                list.Add(num);
            }
            return list;
        }


        /// <summary>
        /// 生成一个非重复的随机序列。
        /// 遍历List的时间复杂度是O(N)，访问Hashtable的时间复杂度是O(1)。
        /// 所以，如果我们使用Hashtable来判断是否重复，就可以将整个算法的时间复杂度从O(N²)降至O(N)，而空间复杂度仍然基本保持在O(N)。
        /// </summary>
        /// <param name="count">序列长度。</param>
        /// <returns>序列。</returns>
        public static Hashtable BuildRandomSequence2(int length)
        {
            Hashtable tab = new Hashtable(length);
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    num = random.Next(0, length);
                } while (tab.Contains(num));
                tab.Add(num, null);
            }
            return tab;
        }


        /// <summary>
        /// 生成一个非重复的随机序列。
        /// 时间和空间复杂度都是O(N)
        /// </summary>
        /// <param name="count">序列长度。</param>
        /// <returns>序列。</returns>
        public static int[] BuildRandomSequence3(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            int x = 0, tmp = 0;
            for (int i = array.Length - 1; i > 0; i--)
            {
                x = random.Next(0, i + 1);
                tmp = array[i];
                array[i] = array[x];
                array[x] = tmp;
            }
            return array;
        }

        /// <summary>
        /// 生成一个非重复的随机序列。
        /// </summary>
        /// <param name="low">序列最小值。</param>
        /// <param name="high">序列最大值。</param>
        /// <returns>序列。</returns>
        public static int[] BuildRandomSequence4(int low, int high)
        {
            int x = 0, tmp = 0;
            if (low > high)
            {
                tmp = low;
                low = high;
                high = tmp;
            }
            int[] array = new int[high - low + 1];
            for (int i = low; i <= high; i++)
            {
                array[i - low] = i;
            }
            for (int i = array.Length - 1; i > 0; i--)
            {
                x = random.Next(0, i + 1);
                tmp = array[i];
                array[i] = array[x];
                array[x] = tmp;
            }
            return array;
        }
    }
}
