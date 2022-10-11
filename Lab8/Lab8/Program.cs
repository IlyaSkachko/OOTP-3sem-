


using System.Text;

namespace Lab8
{

    public delegate void Strigns(string obj);

    public class Program
    {
        public static string text = "fgrhb, efewfq, qef qe jfdnnfd";


        public static List<string> list = new List<string>();
        public static void Main(string[] args)
        {
            while (true)
            {
                int choice = 0;


                Console.WriteLine("\n1.Задание 1\n2.Задание 2\n3.Выход\n\n");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {

                    #region 1
                    case 1:
                        list.Add("Java");
                        list.Add("C++");
                        list.Add("PHP");
                        list.Add("Python");
                        list.Add("F#");

                        var programmer = new Programmer("Ivan");

                        Console.WriteLine($"Имя {programmer.Name}\nТехнологии: {programmer.Description}");

                        programmer.NewProperty += Programmer_NewProperty;
                        programmer.Rename += Programmer_Rename;


                        programmer.NewPropertyProgrammer(list[new Random().Next(2, 5)]);
                        programmer.RenameProgrammer();


                        Console.WriteLine($"Имя {programmer.Name}\nТехнологии: {programmer.Description}");


                        programmer.NewPropertyProgrammer(list[new Random().Next(0, 2)]);
                        Console.WriteLine($"Имя {programmer.Name}\nТехнологии: {programmer.Description}");

                        break;
                    #endregion


                    #region 2
                    case 2:
                        Operation.RemoveMarks += Operation_RemoveMarks;
                        Operation.Upper += Operation_Upper;
                        Operation.Add += Operation_Add;
                        Operation.Search += Operation_Search;
                        Operation.Show += Operation_Show;


                        text = Operation.UpperStr(text);
                        text = Operation.RemoveMarksStr(text);
                        text = Operation.AddStr(text, " Hello world");
                        Console.WriteLine($"\nBool: {Operation.SearchStr("/")}\n");
                        Operation.ShowStr(text);
                        break;

                    #endregion
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static bool Operation_Search(string obj)
        {
            if (text.IndexOf(obj)  >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private static void Operation_Show(string obj) => Console.WriteLine(obj);

        private static string Operation_Add(string arg1, string arg2) => arg1 + arg2;

        private static string Operation_Upper(string arg) => arg.ToUpper();



        #region task1
        private static string Programmer_Rename() => "Ilya";

        private static string Programmer_NewProperty(string arg) => arg;

        #endregion

        #region task2
        private static string Operation_RemoveMarks(string arg)
        {
            arg = arg.Replace(",", " ");
            return arg;
        }

        #endregion
    }
}