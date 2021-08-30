using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace Inslib
{
    public class testclass2
    {
        public string InspectRun()
        {

            UserPrincipal user = UserPrincipal.Current;
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

            if (user != null)
            {
                Console.WriteLine("Password expires: {0}", !user.PasswordNeverExpires);
            }



            return "자동점검항목입니다.";
        }
    }
}
