using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Client
    {
        public Form Form { get; private set; }
        public string Name { get { return Name; } set { if (value != null) Name = value; } }
        public string PassportData { get { return PassportData; } set { PassportData = value; } }


        public Client(List<Car> cars)
        {
            
            Form = new Form();
            Form.WriteForm(cars);
        }


    }
}
