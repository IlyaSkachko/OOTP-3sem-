// Транспорт, Авиация, Грузовой самолет, Пассажирский, Военный, Ty134, Boeing.

using System.Runtime.Serialization;

namespace Lab4
{
    [DataContract]
    internal abstract class Transport   
    {
        public abstract string Type { get; }

        [DataMember]
        public abstract int Capacity { get; set; }

        [DataMember]
        public abstract int FuelConsumption { get; set; }
        [DataMember]
        public abstract int FlightRange { get; set; }

        public abstract void Move();
        
    }
}
