using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    internal class AdministratorA : Administrator
    {
        public override string Name { get; set; }
        public override string Message { get; set; }

        public AdministratorA(string name)
        {
            Name = name;
        }

        public override bool AcceptForm(bool accept)
        {
            if (!accept)
            {
                Message = Console.ReadLine();
            }


            return accept;
        }

        public override void Refund(bool damage)
        {
            Console.WriteLine("-------------------- Регистрация возврата --------------");
            if (damage)
            {
                Console.WriteLine($"Счёт за ремонт автомобиля: 1214");
            }
            Console.WriteLine("Возврат прошёл успешно");
        }
    }
}
