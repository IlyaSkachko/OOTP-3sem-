//Создать Авиакомпанию.Посчитать общую вместимость и грузоподъемность. Провести сортировку самолетов компании по дальности
//полета.Найти самолет в компании, соответствующий заданному диапазону параметров потребления горючего.

using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class AviaCompany
    {
        private List<Transport> transports;

        public string Name { get; }

        public List<Transport> Transports { get { return transports; } set { } }


        public AviaCompany(List<Transport> transports, string name)
        {
            this.transports = transports;
            Name = name;
        }

        public void Add(Transport transport)
        {
            transports.Add(transport);
        }

        public void Remove(Transport transport)
        {
            transports.Remove(transport);
        }

        public void ShowList()
        {
            Console.WriteLine();
            foreach (Transport transport in Transports)
            {
                Console.WriteLine(transport.ToString());
            }
            Console.WriteLine();
        }
            
    }
}
