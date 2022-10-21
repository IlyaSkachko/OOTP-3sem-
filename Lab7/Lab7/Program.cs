

using Lab4;
using System;

namespace Lab7
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Set<string> set = new Set<string>();


                set.Add("MOfnre");
                set.Add(" fgb");
                set.Add("rnre");

                set.Show();

                set.Remove("MOfnre");

                set.Show();



                var set2 = new Set<PassengerAviation>();


                var pas1 = new PassengerAviation("Boeing", 123);
                var pas2 = new PassengerAviation("TU-123", 93);
                set2.Add(pas1);
                set2.Add(pas2);


                set2.Show();    

                Serialization<PassengerAviation>.WriteJson(set2);

                set2.Remove(pas1);

                set2.Show();

                Serialization<PassengerAviation>.ReadJson();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка вышла...\n\n {ex.Message}");
            }
            finally
            {
                Console.WriteLine("The end");
            }
        }
    }
}