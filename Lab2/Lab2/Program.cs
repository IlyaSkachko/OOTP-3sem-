



namespace Lab2
{
    class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                Random random = new Random();
                Customer customer2 = new Customer();

                Customer customer = new Customer("Ilya", "Skachko", "Minsk", random.Next(1000000, 9999999), 1254);
                Console.WriteLine(customer.ToString());


                int balance = customer.Balance;
                int amount;
                Console.Write("Какою сумму списать: ");
                amount = Convert.ToInt32(Console.ReadLine());
                customer.WriteOff(ref amount, out balance);

                Console.WriteLine($"\n Текущий баланс: {customer.Balance}\n");

                Console.WriteLine("Какую сумму добавить: ");
                amount = Convert.ToInt32(Console.ReadLine());
                customer.Add(ref amount, out balance);
                Console.WriteLine($"\n Текущий баланс: {customer.Balance}\n");

                Console.WriteLine($"Сравнение объектов: {customer.Equals(
                                    new Customer("Ivan", "Ivanov", "Brest", random.Next(1000000, 9999999), 563))}");

                Console.WriteLine($"\nТип объекта: {customer.GetType()}");

                var customers = new List<Customer>();
                customers.Add(new Customer("Vasya", "Pupkin", "Vitebsk", random.Next(1000000, 9999999), 10));
                customers.Add(customer);
                customers.Add(new Customer("Petr", "Sidorov", "Gomel", random.Next(1000000, 9999999), 5323));
                customers.Add(new Customer("Ivan", "Ivanov", "Brest", random.Next(1000000, 9999999), 563));
                customers.Add(customer2);



                var result = Interval(customers);
                Console.WriteLine($"\nсписок покупателей, у которых номер кредитной карточки находится в заданном интервале: \n");
                foreach (var i in result)
                {
                    Console.WriteLine(i.ToString());
                    if (i == null)
                    {
                        break;
                    }
                }

                Console.WriteLine();

                Console.WriteLine("Неотсортированный список: ");

                foreach (var i in customers)
                {
                    Console.WriteLine(i.ToString());
                }

                Console.WriteLine();


                Console.WriteLine("Отсортированный список: ");

                foreach (var i in customers.OrderBy(c => c.Name))
                {
                    Console.WriteLine(i.ToString());
                }



                var cust = new { Name = "Ilya", Surname = "Skachko", Card = random.Next(1000000, 9999999), Balance = 5874 };
                Console.WriteLine("\n\nАнонимный тип\n\n");
                Console.WriteLine(cust);
            }
            catch
            {
                Console.WriteLine("Что-то не то...");
            }
        }

        private static List<Customer> Interval(List<Customer> customers)
        {
            var result = new List<Customer>();
            int a, b;
            Console.WriteLine("Введите диапозон: ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());

            foreach(var c in customers)
            {
                if (a < c.CardNumber &&  b > c.CardNumber)
                {
                    result.Add(c);
                }
            }

            return result;
        }



    }
}