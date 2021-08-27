using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inslib
{
    public interface IAuto
    {
        string InspectRun();

    }
    
    public interface IManual
    {
        string InspectRun();
    }
}
