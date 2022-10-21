

using System.Runtime;

namespace Lab12
{
    internal static class SIADirInfo
    {
        public static void ShowDirInfo(string dirPath)
        {
            if (dirPath == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                if (Directory.Exists(dirPath))
                {
                    int count = 0;
                    Console.Write("\n\nКоличество подкаталогов:");
                    string[] dirs = Directory.GetDirectories(dirPath);
                    foreach (string s in dirs)
                    {
                        count++;
                    }
                    Console.WriteLine($"{count}");
                    count = 0;
                    Console.Write("Количество файлов:");
                    string[] files = Directory.GetFiles(dirPath);
                    foreach (string s in files)
                    {
                        count++;
                    }
                    Console.WriteLine(count);
                    DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                    Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                    Console.WriteLine($"Корневой каталог: {dirInfo.Root}");

                    SIALog.WriteLog("Работа класса \"SIADirInfo\"");
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
        }
    }
}
