using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    internal abstract class Administrator
    {
        public abstract string Name { get; set; }
        public abstract string Message { get; set; }


        public abstract void Refund(bool damage);

        public abstract bool AcceptForm(bool accept);
    }
}
