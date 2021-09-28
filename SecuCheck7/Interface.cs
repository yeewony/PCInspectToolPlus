using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuCheck7
{
    public interface test
    {
        string[] check();
    }

    public interface Auto
    {
        string[] Check();
        string[] Fix();
    }

    public interface Manual
    {
        string[] Check();
        string[] Fix();
    }
}
