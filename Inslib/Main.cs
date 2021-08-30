using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    public class Main
    {

        //윈도우 시작 서비스(PC-04), 한글 최신 업데이트(PC-06), 어도비 아크로뱃(PC-08),
        //공유기 암호 설정(PC-16), 서명되지 않은 프로세스 점검(PC-17)
        public static List<IManual> ManualCheck = new List<IManual>()
        {
            new _04_LogonAutorun()
        };


        public static List<IAuto> AutoCheck = new List<IAuto>()
        {
            new _01_UserAccountPassword()
        };
    }
}
