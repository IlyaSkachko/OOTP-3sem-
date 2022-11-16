

using Lab16;
using System.Xml.Linq;

namespace Lab17_18
{
    class Program
    {
        public static Interface Interface { get; set; }
        public static void Main(string[] args)
        {
            Interface = Interface.getInstance();
            var cars = new List<Car>();
            cars.Add(new Car("BMW", "X5", 300));
            cars.Add(new Car("AUDI", "R8", 1000));
            cars.Add(new Car("MESEDEZ-BENZ", "CLS", 600));
            cars.Add(new Car("FORD", "MUSTANG", 400));

            var clientA = new ClientA();

            var form = new Form(clientA.Name, clientA.PassportData, clientA.Age, cars);


            var adminA = new AdministratorA("Александр");

            form.ApprovalApp(adminA.AcceptForm(true), "Потому что потому", adminA.Name);


            var clientB = new ClientB();

            form = new Form(clientB.Name, clientB.PassportData, clientB.Age, cars);

            Prototype prototype = new AdministratorB("Петрович");
            Prototype prototype2 = prototype.Clone();

            form.ApprovalApp(prototype2.AcceptForm(false), adminA.Message, prototype2.Name);
        }
    }
}