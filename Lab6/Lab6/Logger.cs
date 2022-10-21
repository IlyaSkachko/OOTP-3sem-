using System.Text;

namespace Lab6
{
    internal static class Logger
    {
        public static void Write(string ex)
        {
            using (FileStream sw = new FileStream(@"C:\UNIVER\OOTP\Lab6\Lab6\Log.txt", FileMode.Append))
            {
                ex = $"\n\n{DateTime.Now.ToString()}\nINFO: {ex}";
                byte[] bytes = Encoding.UTF8.GetBytes(ex);
                sw.Write(bytes, 0, bytes.Length);
                WriteConsole(ex);
            }
        }

        public static void WriteConsole(string ex)
        {
            Console.WriteLine(ex + "\n\nФайл log.txt создан\n");
        }
    }
}
