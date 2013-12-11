using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppDomainUnity.Common;

namespace AppDomainUnity.AssemblyB
{
    public class SatClass : MarshalByRefObject, IMyInterface
    {
        public string Speak()
        {
            return "I'm SatClass object";
        }
    }
}
