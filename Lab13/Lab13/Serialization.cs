using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using Lab4;

namespace Lab13
{
    public interface ISerializer<T>
    {
        void Serialize(string serializer, string path, List<T> ts);
    }
    internal class Serialization<T> : ISerializer<T>
    {


        public void Serialize(string nameSerializer, string path, List<T> ts)
        {
            using (var file = new FileStream(path, FileMode.Create))
            {
                switch (nameSerializer)
                {
                    case "xml":
                        var xmlFormatter = new XmlSerializer(typeof(List<Cargo>));

                        xmlFormatter.Serialize(file, ts);

                        break;
                    case "soap":
                        var soap = new SoapFormatter();

                        soap.Serialize(file, ts);

                        break;

                    case "bin":
                        var binFormatter = new BinaryFormatter();
                        binFormatter.Serialize(file, ts);
                        break;

                    case "json":
                        var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
                        jsonFormatter.WriteObject(file, ts);
                        break;
                }
            }
        }



        #region Binary
        public List<T> BinaryDeserialization()
        {
            var list = new List<T>();

            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("C:\\UNIVER\\OOTP\\Lab13\\Lab13\\cargo.bin", FileMode.Open))
            {
                list = binFormatter.Deserialize(file) as List<T>;
            }

            return list;
        }
        #endregion


        #region Soap

        public List<T> SoapDeserialization()
        {
            var soap = new SoapFormatter();
            var list = new List<T>();
            using (var file = new FileStream(@"C:\UNIVER\OOTP\Lab13\Lab13\cargo.soap", FileMode.Open))
            {
                list = soap.Deserialize(file) as List<T>;
            }
            return list;
        }

        #endregion


        #region XML

        public List<T> XMLDeserialization()
        {
            var list = new List<T>();

            var xmlFormatter = new XmlSerializer(typeof(List<T>));

            using (var file = new FileStream("C:\\UNIVER\\OOTP\\Lab13\\Lab13\\cargo.xml", FileMode.Open))
            {
                list = xmlFormatter.Deserialize(file) as List<T>;
            }

            return list;
        }



        #endregion


        #region Json

        public List<T> JSONDeserialization()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var list = new List<T>();

            using (var file = new FileStream("C:\\UNIVER\\OOTP\\Lab13\\Lab13\\cargo.json", FileMode.Open))
            {
                list = jsonFormatter.ReadObject(file) as List<T>;
            }

            return list;
        }

        #endregion
    }
}
