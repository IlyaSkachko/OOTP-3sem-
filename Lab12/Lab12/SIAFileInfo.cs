using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal static class SIAFileInfo
    {
        public static void ShowFileInfo(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                if (File.Exists(path))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Exists)
                    {
                        Console.WriteLine($"Имя файла: {fileInfo.Name}");
                        Console.WriteLine($"Полный путь: {fileInfo.DirectoryName}");
                        Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                        Console.WriteLine($"Размер: {fileInfo.Length}");
                        Console.WriteLine($"Расширение: {fileInfo.Extension}");
                    }
                    SIALog.WriteLog("Работа класса \"SIAFileInfo\"");
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
        }
    }
}
