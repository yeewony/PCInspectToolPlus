using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    public class testclass
    {
        public string InspectRun()
        {
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            return username;
        }
    }
}
