
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Lab4
{

    [DataContract]
    internal sealed class Passenger : Aviation, ITransport
    {
        private Type _type = Lab4.Type.PASSENGER;
        public override string Type 
        {
            get
            {
                if (_type == Lab4.Type.PASSENGER)
                {
                    return "Пассажирский";
                }
                else
                {
                    _type = Lab4.Type.PASSENGER;
                    return "Пассажирский";
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
            FlightRange = new Random().Next(5000, 10000);
            FuelConsumption = new Random().Next(100, 200);
        }

        public Passenger (string name, int capacity, int flightRange, int fuelConsumption )
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

        public Passenger()
        {
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
            return $"\nНазвание: {Name}\nТип: {Type}\nВместимость: {Capacity}\nДальность: {FlightRange}" +
                   $"\nРасход: {FuelConsumption}";
        }
    }
}
