using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    internal class Millitary : Aviation
    {
        private Type _type = Lab4.Type.MILLITARY;
        public override string Type
        {
            get
            {
                if (_type == Lab4.Type.MILLITARY)
                {
                    return "Военный";
                }
                else
                {
                    _type = Lab4.Type.MILLITARY;
                    return "Военный";
                }
            }
        }
        [DataMember]
        public override int Capacity { get; set; }
        [DataMember]
        public override string Name { get; set; }
        [DataMember]
        public override int ID { get; set;  }
        [DataMember]
        public override int FlightRange { get; set;  }
        [DataMember]
        public override int FuelConsumption { get;  set; }

        public Millitary(string name, int capacity, int flightRange, int fuelConsumption)
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
            FlightRange = flightRange;
            FuelConsumption = fuelConsumption;
        }

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
            FlightRange = new Random().Next(1000, 4000);
            FuelConsumption = new Random().Next(20, 80);
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
            return $"\nНазвание: {Name}\nТип: {Type}\nВместимость: {Capacity}\nДальность: {FlightRange}" +
                   $"\nРасход: {FuelConsumption}";
        }
    }
}
