using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal enum Type
    {
        PASSENGER,
        CARGO,
        MILLITARY
    }


    struct Info
    {
        public string Name { get; }
        public string Type { get; }
        public int Capacity { get; }

        public int FuelConsumption { get; }

        public int FlightRange { get; }

        public Info(Aviation transport)
        {
            Type = transport.Type;
            Name = transport.Name;
            Capacity = transport.Capacity;
            FuelConsumption = transport.FuelConsumption;
            FlightRange = transport.FlightRange;
        }
        public void Show()
        {
            Console.WriteLine($"\nName: {Name}\nType: {Type}\nCapacity: {Capacity}\nFuel Consumption: {FuelConsumption}" +
                              $"\nFlight range: {FlightRange}");
        }
    }
    internal abstract partial class Aviation
    {

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
    }
}
