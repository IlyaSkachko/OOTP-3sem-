//Создать Авиакомпанию.Посчитать общую вместимость и грузоподъемность. Провести сортировку самолетов компании по дальности
//полета.Найти самолет в компании, соответствующий заданному диапазону параметров потребления горючего.

using Lab4;

namespace Lab5
{   
    class Program
    {
        public static void Main(string[] args)
        {
            var cargo = new Cargo("Boeing", 15);
            var list = new List<Transport>();

            list.Add(cargo);
            list.Add(new Passenger("TU-134", 86));
            list.Add(new Passenger("Boeing-24", 120));
            list.Add(new Millitary("Shark", 4));


            // Структура
            Info info = new Info(cargo);

            info.Show();

            AviaCompany company = new AviaCompany(list, "BelAvia");

            company.ShowList();


            Controller.CoutingTotalCapacity(ref company);

            Console.WriteLine($"\nTotal Capacity: {Controller.TotalCapacity}\nCargo capacity: {Controller.CargoTotalCapacity}\n");

            Controller.SortFlightRange(company);

            int max = 0;
            int min = 0;

            Console.WriteLine("\n\nВведите диапозон горючего: \n");
            min = Convert.ToInt32(Console.ReadLine());
            max = Convert.ToInt32(Console.ReadLine());

            Controller.SearchFuel(company, min, max);



            Console.WriteLine("\n\nFile transport\n\n");

            var fileTransport = new List<Transport>();

            fileTransport = Controller.ReadTxt();
        
            foreach(var i in fileTransport)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("\n\nJSON transport\n\n");

            var jsonTransport = new List<Transport>();

            jsonTransport = Controller.ReadJSON();

            foreach (var i in jsonTransport)
            {
                Console.WriteLine(i.ToString());
            }
    
        }
    }
}