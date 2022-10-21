using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Lab2;

namespace Lab10
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Задание 1\n");

            #region task1
            string[] months = { "January", "Febrary", "March", "April", "May", "June", "July", "August", "September",
                                "Octomber", "November", "December"
            };


            Console.WriteLine("Введите длину: ");
            int l = Convert.ToInt32(Console.ReadLine());

            var list = months.Where(month => month.Length == l);

            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");


            Console.Write("Зимние месяцы: ");
            var winterList = months.Where(month => month == "January" || month == "Febrary" || month == "December");
            foreach (var i in winterList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");

            Console.Write("Летние месяцы: ");
            var summerList = months.Where(month => month == "June" || month == "July" || month == "August");
            foreach (var i in summerList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");


            Console.Write("Алфавитный порядок: ");
            var monthABC = months.OrderBy(month => month);
            foreach (var i in monthABC)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");


            Console.Write("Месяцы содержащие букву «u» и длиной имени не менее 4-х: ");
            var monthU = months.Where(month => month.Length >= 4 && month.Any(i => i == 'u'));
            foreach (var i in monthU)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");
            #endregion


            Console.WriteLine("\nЗадание 2-3\n");

            #region task2-3


            //список покупателей в алфавитном порядке; 
            //список покупателей, у которых номер кредитной карточки находится в заданном интервале
            //максимального покупателя(критерии определит самостоятельно) 
            //первых пят покупателей с максимальной суммой на карте

            var customers = new List<Customer>();

            #region init
            customers.Add(new Customer("Ivan"));
            customers.Add(new Customer("Vasya"));
            customers.Add(new Customer("Ilya"));
            customers.Add(new Customer("Petya"));
            customers.Add(new Customer("Kolya"));
            customers.Add(new Customer("Lena"));
            customers.Add(new Customer("Nastya"));
            customers.Add(new Customer("Sanya"));
            customers.Add(new Customer("Galya"));
            #endregion


            Console.Write("Покупатели в алфавитном порядке: ");
            var nameAbc = customers.OrderBy(customer => customer.Name);

            foreach (var i in nameAbc)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");

            


            Console.Write("Покупателей, у которых номер кредитной карточки находится в заданном интервале(ввести): ");

            int min = Convert.ToInt32(Console.ReadLine());
            int max = Convert.ToInt32(Console.ReadLine());

            var cardNumbers = customers.Where(customer => customer.CardNumber > min && customer.CardNumber < max);

            foreach (var i in cardNumbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");


            Console.WriteLine($"Максимальный покупатель: ");
            var maxCustomer = customers.Max(customer => customer.Balance);
            foreach (var i in customers)
            {
                if (maxCustomer == i.Balance)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\n\n");


            Console.WriteLine("первых пят покупателей с максимальной суммой на карте");
            var orderCustomers = customers.OrderByDescending(Customer => Customer.Balance);
            var fiveCustomers = orderCustomers.Take(5);

            foreach (var i in fiveCustomers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n\n");
            #endregion

            Console.WriteLine("\nЗадание 4\n");


            #region task4

            Console.Write("Мой запрос: ");
            Console.WriteLine(customers.Where(customer => customer.CardNumber > 700000)
                                      .GroupBy(customer => customer.Adress)
                                      .OrderBy(adress => adress.Key)
                                      .Select(adress => adress.Key)
                                      .Aggregate((x, y) => " " + x + " " + y));
            Console.WriteLine("\n\n");


            #endregion

            Console.WriteLine("\nЗадание 5\n");

            #region task5

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
            };
            Company[] companies =
            {
                new Company("Microsoft", "C#"),
                new Company("Google", "Go"),
                new Company("Oracle", "Java")
            };

            var employees = people.Join(companies,
                         p => p.Company,
                         c => c.Title, 
                         (p, c) => new { Name = p.Name, Company = c.Title, Language = c.Language });

            foreach (var emp in employees)
                Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");

            #endregion


            Console.ReadLine();
        }
    }
    record class Person(string Name, string Company);
    record class Company(string Title, string Language);

}