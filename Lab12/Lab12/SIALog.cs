

namespace Lab12
{
    internal static class SIALog
    {
       
        public static void WriteLog(string action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string path = @"C:\UNIVER\OOTP\Lab12\Lab12\sialogfile.txt";
                using (var file = new StreamWriter(path, true))
                {
                    file.WriteLine($"{action}\nИмя Файла: sialogfile.txt\n" +
                                   $"Путь: {path}\n" +
                                   $"Дата: {DateTime.Now}\n");
                }
            }
        }

        public static void ReadLog()
        {
            string path = @"C:\UNIVER\OOTP\Lab12\Lab12\sialogfile.txt";

            using (var file = new StreamReader(path))
            {

                SearchAction(file, new DateOnly(2022, 10, 20));
            }
        }

        private static int CountLog(StreamReader file)
        {
            string? line;
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("Дата"))
                {
                    count++;
                }
            }
            return count;
        }

        private static void SearchAction(StreamReader file, DateOnly dateTime)
        {
            string? line;
            string[] strings = new string[4];
            int i = 0;
            int count = 0;

            while ((line = file.ReadLine()) != null)
            {
                strings[i] = line;
                i++;
                if (line == "")
                {
                    Clear(ref strings, 0, strings.Length, ref i);
                    continue;
                }
                if (line.Contains("Дата"))
                {
                    count++;
                    line = line.Substring(6, line.Length - 6);
                    var date = Convert.ToDateTime(line);
                    if (DateOnly.FromDateTime(date) == dateTime)
                    {
                        foreach (var str in strings)
                        {
                            Console.WriteLine(str);
                        }
                        Console.WriteLine();

                        Clear(ref strings, 0, strings.Length, ref i);
                    }
                    else
                    {
                        Clear(ref strings, 0, strings.Length, ref i);
                    }
                }
            }

            Console.WriteLine("Количество log-записей: " + count);
        }

        private static void Clear(ref string[] strings, int start, int end, ref int i)
        {
            Array.Clear(strings, 0, strings.Length);
            i = 0;
        }
    }
}
