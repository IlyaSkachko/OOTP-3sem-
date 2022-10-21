

using System;

namespace Lab12
{
    class Program
    {
        private static string Log;
        public static void Main(string[] args)
        {
            string path = @"C:\UNIVER\OOTP\Lab12\Lab12\sialogfile.txt";
            string dirPath = @"C:\Users\ilyas\Desktop\универ\ООТП";

            try
            {
                SIADiskInfo.ShowDiskInfo();
                SIAFileInfo.ShowFileInfo(path);
                SIADirInfo.ShowDirInfo(dirPath);
                SIAFileManager.FileManager(@"C:\UNIVER\OOTP\Lab12\Lab12\SIAInspect\");

                Console.WriteLine();
                SIALog.ReadLog();
                Console.WriteLine("--------------------- LOG ---------------------");
                Console.WriteLine(Log);


                Console.ReadLine();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }            
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка");
            }
        }


    }
}