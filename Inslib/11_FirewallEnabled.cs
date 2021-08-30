using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    class _11_FirewallEnabled : IAuto
    {
        public string test()
        {
            return "winupdatestatus ok";
        }

        public string check()
        {
            return "check";
        }
    }
}
