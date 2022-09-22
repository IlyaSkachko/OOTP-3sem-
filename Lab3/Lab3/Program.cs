
namespace Lab3
{
    class Program
    {
        public static void Main(string[] args)
        {
            Set<int> set1 = new Set<int>();
            Set<int> set2 = new Set<int>();
            Set<int> resultSet = new Set<int>();
            int choice;

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                set1.Add(random.Next(1, 10));
            }

            for (int i = 0; i < 6; i++)
            {
                set2.Add(random.Next(6, 12));
            }

            set1.Show();
            set2.Show();


            Console.Write("Какой элемент удалить из 1 множества: ");

            choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            set1 = set1 - choice;

            set1.Show();

            Console.WriteLine($"Пересечение множеств: ");

            resultSet = set1 * set2;

            resultSet.Show();

            Console.WriteLine($"Сравнение множеств: {set1 < set2}");

            Console.WriteLine($"Проверка на подмножество: {set1 > set2}");

            Console.WriteLine("Объединение: ");

            resultSet = set1 & set2;

            resultSet.Show();


            // Вложенные классы

            Console.WriteLine("\n\nВложенные классы\n\n");

            var production = new Set<string>.Production("DevBel");
            Console.WriteLine($"{production.Name}");

            var developer = new Set<string>.Developer("Ilya", 124, ".NET");
            Console.WriteLine($"{developer.ID}, {developer.Name}, {developer.Department}");


            // Статический класс

            set1.InitArr();
            int[] arr = set1.Arr;



            Console.WriteLine($"\n\nСтатические классы\nСумма: {StatisticOperation.Sum(arr)}\nКоличество: " +
                              $"{StatisticOperation.Count(arr)}\nРазница: {StatisticOperation.Difference(arr)}");


            Set<string> setStr = new Set<string>();

            setStr.Add("wef");
            setStr.Add("wf");
            setStr.Add("w1wegwef");
            setStr.Add(",efwgeef");

            string[] str = setStr.InitArr();

            Console.WriteLine($"\n\nСумма(string): {str.Sum()}\nКоличество: " +
                              $"{str.Count()}\nРазница: {str.Difference()}");
            

        }
    }
}