using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CLib.CImage.VerificationCode vc = new CLib.CImage.VerificationCode();
            //string code = vc.CreateVerifyCode();
            //vc.SaveImage(code);
            //Console.WriteLine("生成成功" + code);

            //Console.WriteLine(CLib.Basic.GuidHelper.GenerateBString());
            //Console.WriteLine(CLib.Basic.GuidHelper.GenerateNString());
            //Console.WriteLine(CLib.Basic.GuidHelper.GenerateDString());
            //Console.WriteLine(CLib.Basic.GuidHelper.GeneratePString());

            //Console.WriteLine(CLib.Basic.CalendarHelper.GetWeekString("1991-02-09"));

            DateTime dt = DateTime.Now;
            CLib.Basic.ChineseCalendar cc = new CLib.Basic.ChineseCalendar(dt);
            Console.WriteLine("阳历：" + cc.DateString);
            Console.WriteLine("属相：" + cc.AnimalString);
            Console.WriteLine("农历：" + cc.ChineseDateString);
            Console.WriteLine("时辰：" + cc.ChineseHour);
            Console.WriteLine("节气：" + cc.ChineseTwentyFourDay);
            Console.WriteLine("节日：" + cc.DateHoliday);
            Console.WriteLine("前一个节气：" + cc.ChineseTwentyFourPrevDay);
            Console.WriteLine("后一个节气：" + cc.ChineseTwentyFourNextDay);
            Console.WriteLine("干支：" + cc.GanZhiDateString);
            Console.WriteLine("星期：" + cc.WeekDayStr);
            Console.WriteLine("星宿：" + cc.ChineseConstellation);
            Console.WriteLine("星座：" + cc.Constellation);

            //CLib.Image.WaterMarkImage.SaveImage();

            string a = "明文";

            Console.WriteLine(a);
            string b = CLib.CSecurity.AESHelper.EncryptAES(a);
            Console.WriteLine(b);
            Console.WriteLine(CLib.CSecurity.AESHelper.DecryptAES(b));

            Console.WriteLine(CLib.CBasic.EnumHelper.GetDescription(CLib.CNetwork.NetworkHelper.GetConnectionStatus("www.baidu.com")));

            var query1 = CLib.CBasic.RandomHelper.BuildRandomSequence1(10);
            foreach (var item in query1)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            var query2 = CLib.CBasic.RandomHelper.BuildRandomSequence2(10);
            foreach (var item in query2.Keys)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            var query3 = CLib.CBasic.RandomHelper.BuildRandomSequence3(10);
            foreach (var item in query3)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            var query4 = CLib.CBasic.RandomHelper.BuildRandomSequence4(1, 10);
            foreach (var item in query4)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            string error = "";
            bool flag = CCom.WordHelper.DOC2PDF(@"D:\resume.doc", @"D:\resume.pdf", out error);
            Console.WriteLine(flag + "\t" + error);

            CLib.CNetwork.CDialer ras = new CLib.CNetwork.CDialer();
            ras.Disconnect();//断开连接
            ras.Connect("ADSL");//重新拨号
            Console.WriteLine(ras.Connections.Length);
            Console.ReadLine();
        }
    }
}
