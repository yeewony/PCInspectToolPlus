using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace Inslib
{
    class _02_AccountExpirationDate : IAuto
    {
        /// <summary>
        /// 사용자 계정이 암호를 사용하고 있는지 검사합니다.
        /// 윈도우7의 경우 MS계정 확인 과정은 넘어갑니다.
        /// </summary>
        /// 
        public static string InsName = "PC02";
        //0=> 점검번호 1=>결과값, 2 = 기타값..
        public static string[] result = new string[3];

        public string test()
        {

            return InsName;
        }

        public string check()
        {
            try
            {

                using (var userEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + "/" + Environment.UserName))
                {
                    DateTime Exdate = (DateTime)userEntry.InvokeGet("PasswordExpirationDate");

                    Exdate = Exdate.AddDays(1);

                    result[2] = (Exdate - DateTime.Now).Days.ToString();

                    return result[2];

                }

            }
            catch (Exception ex)
            {
                result[2] = ex.ToString();

                return result[2];
            }
        }
    }
}
