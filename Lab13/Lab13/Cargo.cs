using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab4
{
    [Serializable]
    [DataContract]
    public class Cargo : Aviation
    {
        [DataMember]
        public override int Capacity { get; set; }

        [DataMember]
        public override string Name { get; set; }

        [DataMember]
        public override int ID { get; set; }

        [XmlIgnore]
        public override string Type { get => _type; set => _type = value; }

        [NonSerialized]
        private string _type = "Грузовой";

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

        public Cargo()
        {

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
            return $"\nНазвание: {Name}\nТип: {_type}\nВместимость: {Capacity}";
        }

    }
}
