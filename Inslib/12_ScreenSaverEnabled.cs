using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    class _12_ScreenSaverEnabled : IAuto
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
