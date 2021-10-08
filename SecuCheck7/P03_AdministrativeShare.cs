using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuCheck7
{
    public class P03_AdministrativeShare : Auto
    {
        public static string ChkName = "PC-03";
        public static string[] result = new string[3];

        public string[] Check()
        {
            RunCheck();

            return result;
        }

        public string[] Fix()
        {
            result[1] = "Y";
            result[2] = "공유 폴더 제거 완료";
            return result;
        }

        public void RunCheck()
        {
            //OS가 서버군일경우 레지 탐색을 해야한다.

            string rawdata = Command.Cmd("net share");



        }
       
    }
}
