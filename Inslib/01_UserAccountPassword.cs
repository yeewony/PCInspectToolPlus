using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace Inslib
{
    class _01_UserAccountPassword : IAuto
    {
        /// <summary>
        /// 사용자 계정이 암호를 사용하고 있는지 검사합니다.
        /// 윈도우7의 경우 MS계정 확인 과정은 넘어갑니다.
        /// </summary>
        /// 
        public static string InsName = "PC01";
        public static string Winver = "";
        //0=> 점검번호 1=>결과값, 2 = 기타값..
        public static string[] result = new string[3];


        // Or use `FindByIdentity` if you want to manually specify a user.
        // UserPrincipal.FindByIdentity( ctx, IdentityType.Sid, <YourSidHere> );

        //PasswordNotRequired = True => 패스워드 없이 로그인 가능한 계정이라는 말임.
        //AccountExpirationDate	은 패스워드 유효기간을 말하는것 같음

        //PrincipalContext context = new PrincipalContext(ContextType.Domain);

        //UserPrincipal p = UserPrincipal.FindByIdentity(context, "Domain\\User Name");

        //if (p.AccountExpirationDate.HasValue)
        //{
        //    DateTime expiration = p.AccountExpirationDate.Value.ToLocalTime();
        //}
        //의미하기로는 패스워드 기간에 대한 문제를 의미하는것 같음.


        public string test()
        {

            return InsName;
        }

        public string check()
        {
            //UserPrincipal user = UserPrincipal.Current;

            //if (user!=null)
            //{
            //    Console.WriteLine("계정이 암호를 사용하고 있습니까? {0}", !user.PasswordNotRequired);
            //    result[2] = user.PasswordNotRequired.ToString();
            //}

            try
            {
                using (var context = new PrincipalContext(ContextType.Machine))
                {
                    var user = UserPrincipal.FindByIdentity(context, Environment.UserName);
                    user.SetPassword("");
                    if (user.)
                    {
                        result[2] = "패스워드...?";
                    }
                    else
                    {
                        result[2] = "패스워드를 설정하십시오.";
                    }

                    return result[2];
                }

            }
            catch (PasswordException)
            {
                result[2] = "패스워드를 사용하고 있습니다.";
                return result[2];
            }
            catch (PrincipalOperationException)
            {
                result[2] = "MS 계정을 사용 중 입니다.";
                return result[2];
            }

        }
    }
}
