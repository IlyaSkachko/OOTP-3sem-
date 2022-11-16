// Прокат автомобилей. Клиент выбирает Автомобиль из списка доступных.
//  Заполняет форму Заказа, указывая паспортные данные, срок аренды. Клиент оплачивает Заказ.
//  Администратор регистрирует возврат автомобиля. 
//  В случае повреждения Автомобиля, Администратор вносит информацию и выставляет счет за ремонт.
//  Администратор может отклонить Заявку, указав причины отказа

namespace Lab16
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            cars.Add(new Car("BMW", "X5", 300));
            cars.Add(new Car("AUDI", "R8", 1000));
            cars.Add(new Car("MESEDEZ-BENZ", "CLS", 600));
            cars.Add(new Car("FORD", "MUSTANG", 400));

            var client = new Client(cars);


            var admin = new Administrator("Валера");

            Form.ApprovalApp(admin.AcceptForm(true), admin.Message);
            client.Form.Car.Damage = true;
            admin.Refund(client.Form.Car.Damage);


            client = new Client(cars);
            admin.Message = "обойдёшся";
            Form.ApprovalApp(admin.AcceptForm(false), admin.Message);
            Console.ReadLine();
        }
    }

}