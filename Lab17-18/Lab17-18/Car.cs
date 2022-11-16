using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Car
    {
        private string brand;

        private string model;

        private int price;
        public string Brand { get { return brand; } }
        public string Model { get { return model; } }
        public int Price { get { return price; } set { price = value; } }

        public bool Damage { get; set; }

        public Car(string brand, string model, int price)
        {
            if (brand != null && model != null && price > 0)
            {
                this.price = price;
                this.brand = brand;
                this.model = model;
            }
            else
            {
                Console.WriteLine("Неккоректные данные");
            }
            Damage = false;
        }

        public override string ToString()
        {
            return $"{brand} {model}\n\t\tСтоимость аренды: {price} рублей\n";
        }


    }
}
