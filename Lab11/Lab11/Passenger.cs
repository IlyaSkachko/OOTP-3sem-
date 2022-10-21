
using System.Runtime.Serialization;

namespace Lab4
{

    public class PassengerAviation
    {
        public string Type { get; set; }

        public int Capacity { get; set;  }

        public string Name { get; set; }

        public int ID { get; set; }

        public PassengerAviation(string name, int capacity)
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
            Type = "Пассажирский";
        }

        public PassengerAviation() { }
        public void Boarding()
        {
            Console.WriteLine("Пассажиры заходят\n");
        }

        public void AviationLanding()
        {
            Console.WriteLine("Происходит посадка");
        }

        public int ItsMagic(int preMagic)
        {
            return preMagic * 5;
        }

        public void Move()
        {
            Console.WriteLine("Летит");
        }

        public override string ToString()
        {
            return $"\nНазвание: {Name}\nТип: {Type}\nВместимость: {Capacity}";
        }
    }
}
