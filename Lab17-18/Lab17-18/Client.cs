using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    internal abstract class Client
    {
        public abstract string Name { get; set; }

        public abstract int Age { get; set; }

        public abstract string PassportData { get; set; }
    }
}
