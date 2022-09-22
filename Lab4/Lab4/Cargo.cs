using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Cargo : Aviation
    {
        public override string Type { get { return "Грузовой"; } }

        public override int Capacity { get; }

        public override string Name { get; }

        public override int ID { get; }

        public Cargo(string name, int capacity)
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

        public void LoadCargo()
        {
            Console.WriteLine("Грузится....\n");
        }

        public override void Height()
        {
            Console.WriteLine("8000m");
        }

        public override string ToString()
        {
            return $"\nНазвание: {Name}\nТип: {Type}\nВместимость: {Capacity}";
        }

    }
}
