using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Administrator
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public Administrator(string name)
        {
            Name = name;
        }

        public void Refund(bool damage)
        {
            Console.WriteLine("-------------------- Регистрация возврата --------------");
            if (damage)
            {
                Console.WriteLine($"Счёт за ремонт автомобиля: 1214");
            }
            Console.WriteLine("Возврат прошёл успешно");
        }

        public bool AcceptForm(bool accept)
        {
            if (!accept)
            {
                Message = Console.ReadLine();
            }

            
            return accept;
        }
    }
}
