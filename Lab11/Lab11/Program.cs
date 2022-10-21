
using Lab4;
using System.Globalization;
namespace Lab11
{
    class Program
    {

        public static void Main(string[] args)
        {

            #region 1
            Console.WriteLine("----------------- CLASS 1 ---------------------\n\n");

            Console.WriteLine($"Assembly Name: {Reflector<Person>.AssemblyName()}\n");

            Console.WriteLine($"Is there public constructor: {Reflector<Person>.isPublicConstructor()}\n");

            Console.WriteLine($"Public methods: ");
            var publicMethods = Reflector<Person>.GetPublicMethods();
            foreach(var i in publicMethods)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");  
            
            Console.WriteLine($"Fields: ");
            var fields = Reflector<Person>.GetFields();
            foreach(var i in fields)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");          
            
            Console.WriteLine($"Properties: ");
            var properties = Reflector<Person>.GetProperties();
            foreach(var i in properties)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");      
            
            Console.WriteLine($"Interfaces: ");
            var interfaces = Reflector<Person>.GetInterfaces();
            foreach(var i in interfaces)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Name of methods that contain the specified type of parametrs: ");
            Reflector<Person>.GetMethodsOfClass("Lab11.Person", "System.String");
            Console.WriteLine("\n");
            #endregion

            Reflector<Person>.JSONSerialization();
            Reflector<Person>.JSONDeserialization();


            Console.WriteLine("------------------------ INVOKE -------------------------------\n\n");
            Reflector<Person>.Invoke("Lab11.Person", "Method1", new object[] { 100 });

            #region 2
            Console.WriteLine("\n\n----------------- CLASS 2 ---------------------\n\n");



            Console.WriteLine($"Assembly Name: {Reflector<PassengerAviation>.AssemblyName()}\n");

            Console.WriteLine($"Is there public constructor: {Reflector<PassengerAviation>.isPublicConstructor()}\n");

            Console.WriteLine($"Public methods: ");
            publicMethods = Reflector<PassengerAviation>.GetPublicMethods();
            foreach (var i in publicMethods)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            Console.WriteLine($"Fields: ");
            fields = Reflector<PassengerAviation>.GetFields();
            foreach (var i in fields)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            Console.WriteLine($"Properties: ");
            properties = Reflector<PassengerAviation>.GetProperties();
            foreach (var i in properties)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            Console.WriteLine($"Interfaces: ");
            interfaces = Reflector<PassengerAviation>.GetInterfaces();
            foreach (var i in interfaces)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Name of methods that contain the specified type of parametrs: ");
            Reflector<PassengerAviation>.GetMethodsOfClass("Lab4.PassengerAviation", "System.String");
            Console.WriteLine("\n");
            #endregion
            
            Console.ReadLine();
        }
    }
}

