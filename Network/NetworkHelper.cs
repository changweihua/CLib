using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace CLib.Network
{
    #region 关于
    /*************************************************************************************
     * CLR 版本:	4.0.30319.18034
     * 类 名 称:	NetworkHelper
     * 机器名称:	LUMIA800
     * 命名空间:	CLib.Network
     * 文 件 名:	NetworkHelper
     * 创建时间:	2013/2/22 11:27:39
     * 作    者:	常伟华 Changweihua
	 * 版    权:	NetworkHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2014
     * 签    名:	To be or not, it is not a problem !
     * 网    站:	http://www.cmono.net
     * 邮    箱:	changweihua@outlook.com  
     * 唯一标识:	32198051-09e6-4a9f-b836-4389e10105b1  
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
    public class NetworkHelper
    {
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;

        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);


        /// <summary>
        /// 判断网络的连接状态
        /// </summary>
        /// <returns>
        /// 网络状态(1-->未联网;2-->采用调治解调器上网;3-->采用网卡上网)
        ///</returns>
        public static NetStatus GetConnectionStatus(string netAddress)
        {
            NetStatus netStatus = NetStatus.None;
            int dwFlag = new int();

            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                //没有连上互联网
                netStatus = NetStatus.None;
            }
            else if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
            {
                //采用调制解调器上网，需要进一步判断能否登录具体网址
                if (PingNetAddress(netAddress))
                {
                    //可以ping通，网络OK
                    netStatus = NetStatus.ModemLink;
                }
                else
                {
                    //不可以ping通，网络补OK
                    netStatus = NetStatus.ModemUnlink;
                }
            }
            else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
            {
                //采用网卡上网,需要进一步判断能否登录具体网站
                if (PingNetAddress(netAddress))
                {
                    //可以ping通给定的网址,网络OK
                    netStatus = NetStatus.LanCardLink;
                }
                else
                {
                    //不可以ping通给定的网址,网络不OK
                    netStatus = NetStatus.LanCardUnlink;
                }
            }

            return netStatus;
        }


        /// <summary>
        /// ping 具体的网址看能否ping通
        /// </summary>
        /// <param name="strNetAdd"></param>
        /// <returns></returns>
        private static bool PingNetAddress(string strNetAdd)
        {
            bool Flage = false;
            Ping ping = new Ping();
            try
            {
                PingReply pr = ping.Send(strNetAdd, 3000);
                if (pr.Status == IPStatus.TimedOut)
                {
                    Flage = false;
                }
                if (pr.Status == IPStatus.Success)
                {
                    Flage = true;
                }
                else
                {
                    Flage = false;
                }
            }
            catch
            {
                Flage = false;
            }
            return Flage;
        }

    }

    public enum NetStatus
    {
        [Description("网络未连接")]
        None,
        [Description("采用调治解调器上网")]
        ModemLink,
        [Description("连不上微博哟，您可以尝试重新启动一个Modem")]
        ModemUnlink,
        [Description("采用网卡上网")]
        LanCardLink,
        [Description("网络没有连通，是不是没有输入账号和密码呢？")]
        LanCardUnlink
    }
}
