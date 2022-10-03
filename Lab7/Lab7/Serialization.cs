using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Lab7
{
    public static class Serialization<T> where T : class
    {
        public static void WriteJson(Set<PassengerAviation> set)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Set<PassengerAviation>));

            using (var file = new FileStream(@"C:\UNIVER\OOTP\Lab7\Lab7\object.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, set);
            }
        }

        public static void ReadJson()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Set<PassengerAviation>));

            var set = new Set<PassengerAviation>();

            using (var file = new FileStream(@"C:\UNIVER\OOTP\Lab7\Lab7\object.json", FileMode.OpenOrCreate))
            {
                set = jsonFormatter.ReadObject(file) as Set<PassengerAviation>;

                if (set != null)
                {
                    Console.WriteLine(set.ToString());
                    foreach (var i in set)
                    {
                        Console.WriteLine(i.ToString() + "\n");
                    }
                }
            }

        }
    }
}
