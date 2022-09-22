// Посчитать общую вместимость и грузоподъемность. Провести сортировку самолетов компании по дальности
//полета.Найти самолет в компании, соответствующий заданному диапазону параметров потребления горючего.
using Lab4;
using System.Diagnostics;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;

namespace Lab5
{
    internal static class Controller
    {
        
        public static int TotalCapacity { get; private set; }
        public static int CargoTotalCapacity { get; private set; }
        
        public static Transport FuelTransport { get; }


        public static void CoutingTotalCapacity(ref AviaCompany aviacompany)
        {
            TotalCapacity = 0;
            CargoTotalCapacity = 0;

            foreach (var i in aviacompany.Transports)
            {

                if (i is Passenger)
                {
                    TotalCapacity += i.Capacity;
                }
                else
                {
                    CargoTotalCapacity += i.Capacity;
                }
            }
        }

        public static void SortFlightRange(AviaCompany aviacompany)
        {
            var result = aviacompany.Transports.OrderBy(t => t.FlightRange).ToList();
            foreach (var i in result)
            {
                Console.WriteLine(i.ToString());
            }
        }



        public static void SearchFuel(AviaCompany company, int min, int max)
        {

            foreach (var i in company.Transports)
            {
                if (i.FuelConsumption > min && i.FuelConsumption < max)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }


        public static List<Transport> ReadTxt()
        {
            string path = @"C:\UNIVER\OOTP\Lab5\Lab5\Transport.txt";
            List<Transport> list = new List<Transport>();

            try
            {
                if (File.Exists(path))
                {
                    string[] text = File.ReadAllLines(path);

                    for (var i = 0; i < text.Length; i++)
                    {
                        string[] info = text[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                        switch (info[1])
                        {
                            case "Пассажирский":
                                list.Add(new Passenger(info[0], Convert.ToInt32(info[2]), Convert.ToInt32(info[3]),
                                                              Convert.ToInt32(info[4])));
                                break;

                            case "Грузовой":
                                list.Add(new Cargo(info[0], Convert.ToInt32(info[2]), Convert.ToInt32(info[3]),
                                  Convert.ToInt32(info[4])));
                                break;
                            case "Военный":
                                list.Add(new Millitary(info[0], Convert.ToInt32(info[2]), Convert.ToInt32(info[3]),
                                        Convert.ToInt32(info[4])));
                                break;

                            default: Console.WriteLine("файл составлен не правильно!"); break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return list;
        }
        

        public static void WriteJson()
        {
            var jsonFormatterCargo = new DataContractJsonSerializer(typeof(List<Cargo>));
            var jsonFormatterPassenger = new DataContractJsonSerializer(typeof(List<Passenger>));
            var cargo = new Cargo("Boeing", 15);
            var passenger = new Passenger("Boeing", 15);
            using (var file = new FileStream(@"C:\UNIVER\OOTP\Lab5\Lab5\Transport.json", FileMode.OpenOrCreate))
            {
                jsonFormatterCargo.WriteObject(file, cargo);
                jsonFormatterPassenger.WriteObject(file, passenger);
            }
        }

        public static List<Transport> ReadJSON()
        {

            var list = new List<Transport>();
            var jsonFormatter = new DataContractJsonSerializer(typeof(Cargo));
            using (var file = new FileStream(@"C:\UNIVER\OOTP\Lab5\Lab5\Transport.json", FileMode.Open))
            {
                var json = jsonFormatter.ReadObject(file) as Cargo;

                list.Add(json);
            }

            return list;
        }
    }
}
