using System.IO.Compression;
using File = System.IO.File;

namespace Lab12
{
    internal static class SIAFileManager
    {
        private static string[] dirs;
        private static string[] files;

        public static void FileManager(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException();    
            }
            else
            {
                string oldPath = Path.Combine(path, "siadirinfo.txt");
                string newPath = @"C:\UNIVER\OOTP\Lab12\Lab12\siadirinfo2.txt";

                Directory.CreateDirectory(path);
                ReadFileAndDir();
                File.Copy(oldPath, newPath, true);
                File.Delete(oldPath);

                Directory.CreateDirectory(@"C:\UNIVER\OOTP\Lab12\Lab12\SIAFiles");

                string str, dir;
                Console.WriteLine("Введите расширение");
                str = Console.ReadLine();
                Console.WriteLine("Введите путь к директорию");
                dir = Console.ReadLine();

                string[] files = Directory.GetFiles(dir);
                int i =0;
                foreach (string s in files)
                {
                    var f = new FileInfo(s);
                    if (f.Extension == str)
                    {
                        i++;
                        File.Copy(s, @"C:\UNIVER\OOTP\Lab12\Lab12\SIAInspect\file" + i + str, true);
                    }
                }
                //Zip(@"C:\UNIVER\OOTP\Lab12\Lab12\SIAInspect", @"C:\UNIVER\OOTP\Lab12\Lab12\SIAInspect.zip");
            }

        }


        private static void ReadFileAndDir()
        {
            string dirName = "C:\\";

            if (Directory.Exists(dirName))
            {
                using (var file = new StreamWriter(@"C:\UNIVER\OOTP\Lab12\Lab12\SIAInspect\siadirinfo.txt", false))
                {
                    Console.WriteLine("\n\nПодкаталоги:"); 
                    file.Write("Подкаталоги:\n");
                    dirs = Directory.GetDirectories(dirName);
                    foreach (string s in dirs)
                    {
                        file.Write(s + "\n");
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    file.Write("Файлы:\n");
                    Console.WriteLine("Файлы:");
                    files = Directory.GetFiles(dirName);
                    foreach (string s in files)
                    {
                        file.Write(s + "\n");
                        Console.WriteLine(s);
                    }
                }
            }
        }
        

        private static void Zip(string sourceDirectoryName, string destinationFileName)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationFileName);
            ZipFile.ExtractToDirectory(destinationFileName, @"C:\UNIVER\OOTP\Lab12\Lab12\SIAFiles");
        }


    }
}
