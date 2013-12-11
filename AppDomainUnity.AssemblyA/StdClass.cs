using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppDomainUnity.Common;

namespace AppDomainUnity.AssemblyA
{
    public class StdClass : IMyInterface
    {
        public string Speak()
        {
            return "I'm StdClass object";
        }
    }
}
