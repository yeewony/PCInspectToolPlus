using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    class _03_AdministrativeShare : IAuto
    {
        public static string InsName = "PC03";

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
