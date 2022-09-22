using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal abstract class Aviation : Transport, ITransport
    {
        public virtual string Name { get; }

        public abstract int ID { get; }       

        public virtual void Height()
        {
            Console.WriteLine("Высота полёта 5000м");
        }


        public bool Equals(Aviation obj)
        {
            return obj != null && obj.ID == ID; 
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Aviation);
        }

        public override int GetHashCode()
        {
            return new Random().Next(12, 12512);
        }

        public void AviationLanding()
        {
            Console.WriteLine("Происходит посадка");
        }

        public override void Move()
        {
            Console.WriteLine("Летит");
        }

        void ITransport.Move()
        {
            Console.WriteLine("Летит(через интерфейс)");
        }

    }
}
