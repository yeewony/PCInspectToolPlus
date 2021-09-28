using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;

namespace SecuCheck7
{
    class P01_UserAccountPassword : Auto
    {
        ///<summary>
        /// 사용자 계정이 암호를 사용하고 있는지 검사합니다.
        /// 윈도우7의 경우 MS 계정 사용 확인 검사는 하지 않고 넘어갑니다.
        /// 윈도우 계정이 암호를 사용하고 있지 않을 경우에만 값이 나옵니다.
        /// </summary>
        /// 

        public static string ChkName = "PC-01";
        public static string Winver;

        //0 > 점검번호, 1> 결과 2> 점검 결과에 대한 안내 등.

        public static string[] Result = new string[3];

        public string[] Check()
        {
            
            try
            {
                RunCheck();

                return Result;
            }
            catch (Exception ex)
            {
                Result[1] = "ERROR";
                Result[2] = ex.ToString();
                return Result;
            }
        }
        public string[] Fix()
        {
            Result[1] = "Y";
            Result[2] = "패스워드 설정 완료";
            return Result;
        }

        public static void RunCheck()
        {
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            try
            {
                using (var context = new PrincipalContext(ContextType.Machine))
                {
                    var user = UserPrincipal.FindByIdentity(context, username);
                    if (user==null)
                    {
                        //로컬 유저가 아님, 패스워드가 필요함
                        Result[1] = "Y";
                        Result[2] = "로컬 사용자 계정이 아닙니다.";
                    }
                    else
                    {
                        //공백으로 패스워드를 변경해봄으로서 변경이 되면 패스워드가 설정된것이 아니다.
                        user.ChangePassword("", "");
                        Result[1] = "N";
                        Result[2] = "패스워드를 설정해야 합니다.";
                    }
                }

            }
            catch (PasswordException)
            {
                Result[1] = "Y";
                Result[2] = "패스워드가 설정되어 있습니다.";
            }
            catch (PrincipalOperationException)
            {
                Result[1] = "Y";
                Result[2] = "MS 계정을 사용 중 입니다.";
            }
        }

        
    }
}
