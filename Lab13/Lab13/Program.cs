


using Lab4;
using System.Xml;
using System.Xml.Linq;

namespace Lab13
{
    class Program
    {
        public static void Main(string[] args)
        {

            #region Serialization
            var cargos = new List<Cargo>();
            for (int i = 0; i < 5; i++)
            {
                cargos.Add(new Cargo("Boing", new Random().Next(20, 100)));
            }

            Serialization<Cargo> serialization = new Serialization<Cargo>();

            Console.Write("Введите в какой формат сериализовать(xml, bin, soap, json): ");
            string nameSerializer = Console.ReadLine();

            switch (nameSerializer)
            {
                case "bin":
                    serialization.Serialize(nameSerializer, @"C:\UNIVER\OOTP\Lab13\Lab13\cargo.bin", cargos);

                    var binList = serialization.BinaryDeserialization();

                    foreach (var i in binList)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine();
                    break;
                case "soap":
                    serialization.Serialize(nameSerializer, @"C:\UNIVER\OOTP\Lab13\Lab13\cargo.soap", cargos);

                    var soapList = serialization.SoapDeserialization();

                    foreach (var i in soapList)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine();
                    break;
                case "xml":
                    serialization.Serialize(nameSerializer, @"C:\UNIVER\OOTP\Lab13\Lab13\cargo.xml", cargos);

                    var xmlList = serialization.XMLDeserialization();

                    foreach (var i in xmlList)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine();
                    break;
                case "json":
                    serialization.Serialize(nameSerializer, @"C:\UNIVER\OOTP\Lab13\Lab13\cargo.json", cargos);

                    var jsonList = serialization.JSONDeserialization();

                    foreach (var i in jsonList)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine();
                    break;
            }

            #endregion


            #region XPath
            Console.WriteLine("\n\n---------------- XPATH ------------------\n");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\UNIVER\OOTP\Lab13\Lab13\cargo.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList? nodes = xRoot?.SelectNodes("*");
            if (nodes is not null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }

            Console.WriteLine("\nID\n");
            XmlNodeList? companyNodes = xRoot?.SelectNodes("//Cargo/ID");
            if (companyNodes is not null)
            {
                foreach (XmlNode node in companyNodes)
                    Console.WriteLine(node.InnerText);
            }

            #endregion

            #region LINQ to XML

            Console.WriteLine("\n--------------- LINQ to XML -----------------\n");


            XDocument document = new XDocument();
            XElement bmw = new XElement("Car");
            XElement brand = new XElement("Brand", "BMW");
            XElement year = new XElement("Year","2020");

            bmw.Add(brand);
            bmw.Add(year);        
            
            XElement audi = new XElement("Car");
            XElement brand1 = new XElement("Brand", "AUDI");
            XElement year2 = new XElement("Year", "2021");

            audi.Add(brand1);
            audi.Add(year2);

            XElement Cars = new XElement("Cars");
            Cars.Add(bmw);
            Cars.Add(audi);

            document.Add(Cars);

            document.Save(@"C:\UNIVER\OOTP\Lab13\Lab13\cars.xml");

            XElement? c = document.Element("Cars");
            if (c != null)
            {

                foreach (XElement item in c.Elements("Car"))
                {
                    XElement? br = item.Element("Brand");
                    XElement? yr = item.Element("Year");

                    Console.WriteLine($"Brand: {br?.Value}");
                    Console.WriteLine($"Year: {yr?.Value}");

                    Console.WriteLine(); 
                }
            }

            #endregion
        }
    }
}