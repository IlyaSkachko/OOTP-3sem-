using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal sealed class Passenger : Aviation, ITransport
    {
        public override string Type { get { return "Пассажирский"; } }

        public override int Capacity { get; }

        public override string Name { get; }

        public override int ID {get; }

        public Passenger(string name, int capacity)
        {
            Name = name;
            if (capacity > 0)
            {
                Capacity = capacity;
            }
            else
            {
                throw new Exception("Ошибка");
            }
            ID = base.GetHashCode();
        }

        public void Boarding()
        {
            Console.WriteLine("Пассажиры заходят\n");
        }

        public override void Height()
        {
            base.Height();
        }

        public override string ToString()
        {
            return $"\nНазвание: {Name}\nТип: {Type}\nВместимость: {Capacity}";
        }
    }
}
