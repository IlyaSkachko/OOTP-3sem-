using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [DataContract]
    internal class Cargo : Aviation
    {
        private Type _type = Lab4.Type.CARGO;
        public override string Type
        {
            get
            {
                if (_type == Lab4.Type.CARGO)
                {
                    return "Грузовой";
                }
                else
                {
                    _type = Lab4.Type.CARGO;
                    return "Грузовой";
                }
            }
        }
        [DataMember]
        public override int Capacity { get; set; }
        [DataMember]
        public override string Name { get; set; }
        [DataMember]
        public override int ID { get; set; }
        [DataMember]
        public override int FlightRange { get; set; }
        [DataMember]
        public override int FuelConsumption { get; set; }


        public Cargo(string name, int capacity, int flightRange, int fuelConsumption)
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
            FlightRange = new Random().Next(8000, 12000);
            FuelConsumption = new Random().Next(150, 400);
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
            return $"\nНазвание: {Name}\nТип: {Type}\nВместимость: {Capacity}\nДальность: {FlightRange}" +
                   $"\nРасход: {FuelConsumption}";
        }

    }
}
