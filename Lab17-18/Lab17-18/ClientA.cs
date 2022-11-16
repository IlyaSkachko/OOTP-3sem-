using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    internal class ClientA : Client
    {
        private string name;
        private string passportData;
        private int age;

        public override string Name 
        { 
            get { return name; } 
            set 
            {
                if (value != null) 
                { 
                    name = value;
                } 
            } 
        }
        public override int Age
        {
            get { return age; }
            set
            {
                if (value > 10 && value < 100)
                {
                    age = value;
                }
            }
        }
        public override string PassportData 
        { 
            get { return passportData; }

            set
            {
                if (value != null)
                {
                    passportData = value;
                }
            }
        }

        public ClientA()
        {

            Console.Write("Введите Имя: ");
            Name = Console.ReadLine();

            Console.Write("\nВведите возраст: ");
            Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведите номер паспорта: ");
            PassportData = Console.ReadLine();
        }
    }
}
