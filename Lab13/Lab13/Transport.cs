// Транспорт, Авиация, Грузовой самолет, Пассажирский, Военный.

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Lab4
{
    [Serializable]
    [DataContract]
    public abstract class Transport   
    {
        [DataMember]
        public abstract int Capacity { get; set; }

        [XmlIgnore]
        public abstract string Type { get; set;  }
        public abstract void Move();
        
    }
}
