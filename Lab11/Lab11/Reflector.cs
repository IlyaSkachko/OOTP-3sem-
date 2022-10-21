
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Globalization;
namespace Lab11
{
    [Serializable]
    public class Reflector<T> where T : class, new()
    {
        #region fields
        public static Assembly assemeblyName { get; set; }

        public static bool PublicConstructor { get; set; }

        public static IEnumerable<string> Methods { get; set; }    

        public static IEnumerable<string> Fields { get; set; }        

        public static IEnumerable<string> Properties { get; set; }       
        public static IEnumerable<string> Interfaces { get; set; }
        #endregion

        [NonSerialized]
        private static Type type = typeof(T);



        public static Assembly AssemblyName()
        {
            assemeblyName = type.Assembly;
            return type.Assembly;
        }

        public static bool isPublicConstructor()
        {
            bool isPublic = false;
            foreach (ConstructorInfo ctor in type.GetConstructors(BindingFlags.Instance | BindingFlags.Public))
            {
                if (ctor.IsPublic)
                    isPublic = true;

            }
            PublicConstructor = isPublic;
            return isPublic;

        }

        public static IEnumerable<string> GetPublicMethods()
        {
            var methods = new List<string>();
            foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                if (method.IsPublic)
                {
                    methods.Add(method.Name);
                }
            }
            Methods = methods;
            return methods;
        }


        public static IEnumerable<string> GetFields()
        {
            var fields = new List<string>();
            foreach (var field in type.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                fields.Add(field.Name);
            }
            Fields = fields;
            return fields;
        }      
        
        public static IEnumerable<string> GetProperties()
        {
            var properties = new List<string>();
            foreach (var property in type.GetProperties(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                properties.Add(property.Name);
            }
            Properties = properties;
            return properties;
        }    
        
        public static IEnumerable<string> GetInterfaces()
        {
            var interfaces = new List<string>();
            foreach (var property in type.GetInterfaces())
            {
                interfaces.Add(property.Name);
            }
            Interfaces = interfaces;
            return interfaces;
        }

        public static void GetMethodsOfClass(string className, string arg)
        {
            Type? myType = Type.GetType(className, false, true);
            Type? argType = Type.GetType(arg, false, true);

            foreach(var m in myType.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                if (argType == m.ReturnType)
                {
                    Console.WriteLine(m.Name);
                }
            }
        }
        public static void Invoke(string className, string methodName, object[] param)
        {
            Type type = Type.GetType(className, false, true);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            object classObject = constructor.Invoke(new object[] { });


            MethodInfo magicMethod = type.GetMethod(methodName);
            object value = magicMethod.Invoke(classObject, param);
            Console.WriteLine($"{className}.{methodName}() returned: {value}");
        }

        //public static void Serialization()
        //{
        //    using (var file = new StreamWriter("C:\\UNIVER\\OOTP\\Lab11\\Lab11\\reflector.txt", false))
        //    {
        //        file.Write("Assembly name: " + assemeblyName.ToString() + "\n");

        //        file.Write("isPublicConstructor: " + PublicConstructor + "\n");

        //        file.Write("Methods: ");
        //        foreach(var i in Methods)
        //        {
        //            file.Write(i + "\t");
        //        }
        //        file.WriteLine();

        //        file.Write("Fields: ");
        //        foreach (var i in Fields)
        //        {
        //            file.Write(i + "\t");
        //        }
        //        file.WriteLine();

        //        file.Write("Properties: ");
        //        foreach (var i in Properties)
        //        {
        //            file.Write(i + "\t");
        //        }
        //        file.WriteLine();

        //        file.Write("Interfaces: ");
        //        foreach (var i in Interfaces)
        //        {
        //            file.Write(i + "\t");
        //        }
        //        file.WriteLine();

        //    }
        //}

        public static void JSONSerialization()
        {
            using (var file = new StreamWriter("C:\\UNIVER\\OOTP\\Lab11\\Lab11\\reflector.json", false))
            {
                file.WriteLine("{");
                file.Write($"\t\"Assembly name\": \"{assemeblyName}\",\n");
                file.Write($"\t\"PublicConstructor\": \"{PublicConstructor}\",\n");

                file.Write("\t\"Methods\": \"");
                foreach (var i in Methods)
                {
                    file.Write(i + " ");
                }
                file.Write("\",");
                file.WriteLine();

                file.Write("\t\"Fields\": \"");
                foreach (var i in Fields)
                {
                    file.Write(i + " ");
                }
                file.Write("\",");
                file.WriteLine();

                file.Write("\t\"Properties\": \"");
                foreach (var i in Properties)
                {
                    file.Write(i + " ");
                }
                file.Write("\",");
                file.WriteLine();

                file.Write("\t\"Interfaces\": \"");
                foreach (var i in Interfaces)
                {
                    file.Write(i + " ");
                }
                file.Write("\"");
                file.WriteLine();
                file.WriteLine("}");
            }
        }

        public static void JSONDeserialization()
        {
            using (var file = new StreamReader("C:\\UNIVER\\OOTP\\Lab11\\Lab11\\reflector.json"))
            {
                string? line;
                string[] strings;
                string s;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("Methods"))
                    {
                        line = line.Substring(12, line.Length - 15);
                        strings = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        InitMethods(strings);
                    }
                }

            }
        }

        private static void InitMethods(string[] strings)
        {
            Methods = strings;
        }



        public static T Creator()
        {
            return new T();
        }
    }
}
