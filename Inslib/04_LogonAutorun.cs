﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    class _04_LogonAutorun : IManual
    {
        public static string InsName;
        public string test()
        {
            InsName = this.GetType().Name;

            return InsName;
        }

        public string check()
        {


            return InsName + "Load ok";
        }
    }
}
