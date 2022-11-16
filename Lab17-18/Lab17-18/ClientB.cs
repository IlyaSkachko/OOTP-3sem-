using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    internal class ClientB : Client
    {

        private string passportData;
        private int age;
        private string name = "Валера";

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

        public override string Name { get => name; set { name = "Валера"; } }

        public ClientB()
        {


            Console.Write("\nВведите возраст: ");
            Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведите номер паспорта: ");
            PassportData = Console.ReadLine();
        }
    }
}
