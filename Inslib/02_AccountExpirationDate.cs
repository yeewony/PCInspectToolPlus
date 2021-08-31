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
        public static string Winver = "";
        //0=> 점검번호 1=>결과값, 2 = 기타값..
        public static string[] result = new string[3];

        public string test()
        {

            return InsName;
        }

        public string check()
        {
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            try
            {
                //using (var context = new PrincipalContext(ContextType.Machine))
                //{
                //    var user = UserPrincipal.FindByIdentity(context, username);
                //    if (user == null)
                //    {
                //        로컬 유저가 아님, 패스워드가 필요함.
                //        result[2] = "로컬 유저가 아닙니다.";
                //    }
                //    else
                //    {
                //        공백으로 패스워드를 변경해봄으로서 변경이 되면 패스워드가 설정된것이 아니다.


                //        result[2] = "패스워드를 설정하십시오.";
                //    }

                //    return result[2];
                //}

                using (var userEntry = new DirectoryEntry("WinNT://"+Environment.MachineName+"/"+Environment.UserName))
                {
                    DateTime r = (DateTime)userEntry.InvokeGet("PasswordExpirationDate");

                    result[2] = r.ToString();

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
