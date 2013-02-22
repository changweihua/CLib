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
            //CLib.Image.VerificationCode vc = new CLib.Image.VerificationCode();
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
            string b = CLib.Security.AESHelper.EncryptAES(a);
            Console.WriteLine(b);
            Console.WriteLine(CLib.Security.AESHelper.DecryptAES(b));

            Console.WriteLine(CLib.Network.NetworkHelper.GetConnectionStatus("www.baidu.com"));

            Console.ReadLine();
        }
    }
}
