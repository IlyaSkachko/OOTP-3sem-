using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Millitary : Aviation
    {
        public override string Type { get { return "Военный"; } }

        public override int Capacity { get; }

        public override string Name { get; }

        public override int ID { get; }

        public Millitary(string name, int capacity)
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

        public void Fire()
        {
            Console.WriteLine("Пыш-пыш\n");
        }
        public override void Height()
        {
            Console.WriteLine("10000m");
        }

        public override string ToString()
        {
            return $"\nНазвание: {Name}\nТип: {Type}\nВместимость: {Capacity}";
        }
    }
}
