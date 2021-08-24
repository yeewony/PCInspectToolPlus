using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    public class Main
    {
        public static List<IManual> ManualCheck = new List<IManual>()
        {
            new testclass(),
            new testclass(),
            new testclass(),
            new testclass(),
            new testclass(),
            new testclass(),
            new testclass(),
            new testclass()
        };
        public static List<IAuto> AutoCheck = new List<IAuto>()
        {
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2(),
            new testclass2()
        };
    }
}
