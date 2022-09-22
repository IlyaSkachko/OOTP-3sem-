using System.Text;

class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("-------  Типы  -------------\n\n");
        Types();

        Console.WriteLine("\n\n-------  Строки  -------------\n\n");
        Strings();


        Console.WriteLine("\n\n-------  Массивы  -------------\n\n");
        Arrays();


        Console.WriteLine("\n\n------ Кортежи  ----------\n\n");
        Tuples();

        Console.WriteLine("\n\n------ Локальная функция  ----------\n\n");


        int[] arr = new int[6];
        string str = "Hello world!";
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(10);
        }

        (int, int, int, char) LocalFunc(int[] arr, string str)
        {
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            char ch = Convert.ToChar(str.Substring(0, 1));
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i]; 
                }
                sum += arr[i];
            }
            return (min, max, sum, ch);
        }

        (int, int, int, char) tuple = LocalFunc(arr, str);
        Console.WriteLine(tuple);


        Console.WriteLine("\n\n------ Checked & Unchecked  ----------\n\n");
        Checked();

        Console.ReadLine();
    }

    private static void Types()
    {
        bool a = false;
        int b = 4;
        float c = 4.235f;
        byte d = 255;
        sbyte e = -127;
        short f = 32767;
        ushort g = 65532;
        uint h = 4292967295U;
        long i = 9_223_372_036_854_775_807L;
        ulong j = 0UL;
        double k = 23523.152125;
        decimal l = 2.51251544225m;
        char o = 'a';

        Console.WriteLine("int  bool");
        b = Convert.ToInt32(Console.ReadLine());
        a = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine(b);
        Console.WriteLine(a);




        // неявное приведение

        ushort num = d; // byte
        short num2 = e; // sbyte
        float ff = b;
        double mm = ff;
        object obj = mm;


        // явные преобразования

        byte bi = (byte)b;
        decimal dd = (decimal)ff;
        int ch = (int)o;
        long sh = (long)f;
        float df = (float)k;

        // упаковка - расппковка

        object obj2 = b;
        int cr = (int)obj2;


        // неявно типизированная переменная 
        var fw = 14;
        var str = "wegef";
        Console.WriteLine($"{fw.GetType()}        {str.GetType()}");


        // nullable
        int? nll = null;




    }

    private static void Strings()
    {
        string str1 = "Hello";
        string str2 = "hello";
        Console.WriteLine(str1==str2);


        String str3 = "Hello";
        String str4 = "world!";
        String str5 =  $"{str3} {str4}" ;
        Console.WriteLine(str5);
        Console.WriteLine(str3.Substring(2, str3.Length - 2));

        Console.WriteLine(' ');
        String[] words = str5.Split(' ');
        foreach(String word in words)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine(str5.Insert(12, " bye"));
        Console.WriteLine(str5.Remove(1, 4));


        string? sa = null;
        string sb = "";
        Console.WriteLine(string.IsNullOrEmpty(sa));
        Console.WriteLine(sa);


        StringBuilder stringBuilder = new StringBuilder("Hello world!");
        stringBuilder.Remove(0, 5);
        stringBuilder.Insert(0, "Bye");
        stringBuilder.AppendFormat(" hello");
        Console.WriteLine(stringBuilder);
    }   

    private static void Arrays()
    {
        int[,] matrix = new int[2, 2] { { 1, 2 }, { 5, 6 } };
        for (int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }


        string[] strings = new string[] { "Hello", "world", "!" };
        foreach(string s in strings)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("Длина: " + strings.Length);
        Console.Write("Введите номер индекса для замены: ");
        int k = Convert.ToInt32(Console.ReadLine());
        Console.Write("На что меняем? ");
        strings[k] = Console.ReadLine();
        foreach (string s in strings)
        {
            Console.WriteLine(s);
        }


        int[][] arr = new int[3][];
        arr[0] = new int[2];
        arr[1] = new int[3];
        arr[2] = new int[4];

        for (int i = 0; i < 2; i++)
        {
            arr[0][i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < 3; i++)
        {
            arr[1][i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < 4; i++)
        {
            arr[2][i] = Convert.ToInt32(Console.ReadLine());    
        }

        for(int i = 0;i<2; i++)
        {
            Console.Write(arr[0][i] + " ");
        }
        Console.WriteLine();
        
        for(int i = 0;i<3; i++)
        {
            Console.Write(arr[1][i] + " ");
        }
        Console.WriteLine();        
        for(int i = 0;i<4; i++)
        {
            Console.Write(arr[2][i] + " ");
        }
        Console.WriteLine();


        var arr2 = new[] { 1, 2, 3 };
        var str = "fewgrg";

    }

    private static void Tuples()
    {
        (int, string, char, string, ulong) tuple = (19, "Ilya", 'P', "Skachko", 2);
        (int, string, char, string, ulong) tuple2 = (19, "Ilya", 'P', "Skachko", 2);
        Console.WriteLine(tuple);
        Console.WriteLine(tuple.Item2 + ' ' + tuple.Item5);

        int age = tuple.Item1;
        string name = tuple.Item2;
        char spec = tuple.Item3;
        string surname = tuple.Item4;
        ulong course = tuple.Item5;
        Console.WriteLine($"{age} {name} {spec} {surname} {course}");
        Console.WriteLine(tuple.CompareTo(tuple2));
    }

    private static void Checked()
    {


        void Checked2()
        {
            checked
            {
                int max = int.MaxValue;
                Console.WriteLine(max);
            }
        }
        void Unchecked()
        {
            unchecked
            {
                int max = int.MaxValue + 1;
                Console.WriteLine(max);
            }
        }

        Checked2();
        Unchecked();
    }
}
