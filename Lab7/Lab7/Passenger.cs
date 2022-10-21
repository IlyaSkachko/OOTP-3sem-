
using Lab7;
using System.Runtime.Serialization;

namespace Lab4
{

    [DataContract]
    public class PassengerAviation
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public int Capacity { get; set;  }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
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

        public void Boarding()
        {
            Console.WriteLine("Пассажиры заходят\n");
        }

        public void AviationLanding()
        {
            Console.WriteLine("Происходит посадка");
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
