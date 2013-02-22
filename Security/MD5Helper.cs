using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CLib.Security
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	MD5
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Security
     * 文 件 名:	MD5
     * 创建时间:	2013/2/22 11:14:13
     * 作    者:	常伟华 Changweihua
	 * 版    权:	MD5说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	d863f836-6b1e-4134-bc42-2e8993ddff27  
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
    public class MD5Helper
    {
        /// <summary>
        /// MD5 16位加密 加密后代码为大写
        /// </summary>
        /// <param name="cryptString">待加密的字符串</param>
        /// <returns>密文</returns>
        public static string GetMD5StringUpperCase(string cryptString)
        {
            string result = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                result = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(cryptString)), 4, 8);
                result = result.Replace("-", "");
            }

            return result;
        }

        /// <summary>
        /// MD5 16位加密 加密后代码为小写
        /// </summary>
        /// <param name="cryptString">待加密的字符串</param>
        /// <returns>密文</returns>
        public static string GetMD5StringLowerCase(string cryptString)
        {
            return GetMD5StringUpperCase(cryptString).ToLower();
        }

        /// <summary>
        /// MD5 32位加密
        /// </summary>
        /// <param name="cryptString">明文</param>
        /// <returns>密文</returns>
        public static string GetMD5String(string cryptString)
        {
            string result = string.Empty;

            //实例化一个MD5对象
            using (MD5 md5 = MD5.Create())
            {
                StringBuilder sb = new StringBuilder();
                //加密后是一个字节类型的数组
                byte[] cryptStringArray = md5.ComputeHash(Encoding.UTF8.GetBytes(cryptString));
                //通过循环，将字节类型的数组转换成字符串
                for (int i = 0; i < cryptStringArray.Length; i++)
                {
                    //将得到的字符串使用16进制类型格式
                    sb.Append(cryptStringArray[i].ToString("X"));
                }

                result = sb.ToString();

            }

            return result;
        }


        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(b[i].ToString("X").PadLeft(2, '0'));
            }

            return sb.ToString();
        }


    }
}
