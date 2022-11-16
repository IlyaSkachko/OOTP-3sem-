using Lab16;

namespace Lab17_18
{

    class Form
    {
        private string clientName;
        private string passportNumber;
        private int age;
        private Car car;
        private bool sendForm = false;
        private int rentalPeriod;


        #region Properties

        public string ClientName
        {
            get
            {
                return clientName;
            }
            set
            {
                if (value != null)
                {
                    clientName = value;
                }
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }

        public Car Car
        {
            get { return car; }
            set
            {
                if (value != null)
                {
                    car = value;
                }

            }
        }

        public string PassportNumber
        {
            get { return passportNumber; }
            set
            {
                if (value != null)
                {
                    passportNumber = value;
                }
            }
        }

        public int RentalPeriod
        {
            get { return rentalPeriod; }
            set
            {
                if (value > 0)
                {
                    rentalPeriod = value;
                }
            }
        }

        public bool SendForm { get { return sendForm; } }

        #endregion


        public Form(string clientName, string passportData, int age, List<Car> cars)
        {
            ClientName = clientName;
            PassportNumber = passportData;
            Age = age;
            WriteForm(cars);

        }

        private bool SendInfo()
        {
            if (age < 18)
            {
                Console.WriteLine("Форма не отправлена! Заказ автомобиля возможен в возрасте от 18 лет!");
                sendForm = false;
            }
            if (car != null && clientName != null && passportNumber != null && age > 18 && rentalPeriod > 0)
            {
                sendForm = true;
                Console.WriteLine("Заказ оформлен! Ожидайте одобрения аренды.");
            }

            return sendForm;
        }

        public void ApprovalApp(bool approval, string message, string adminName)
        {
            if (approval)
            {
                Console.WriteLine("Заявка одобрена!");
            }
            else
            {
                Console.WriteLine($"Заявка не одобрена!\nПричина: {message}(Администратор: {adminName})");
            }
        }

        public void WriteForm(List<Car> cars)
        {
            Console.WriteLine("--------------- Форма заказа ----------------\n");


            Console.WriteLine("Выберите автомобиль из списка");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice < cars.Count || choice > 0)
            {
                car = cars[choice - 1];
            }

            Console.Write("\nПериод аренды: ");
            rentalPeriod = Convert.ToInt32(Console.ReadLine());

            car.Price *= rentalPeriod;

            bool answer = ReadForm();
            if (answer)
            {
                if (!SendInfo())
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("1 - Заново заполнить форму\n2 - Выход");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: WriteForm(cars); break;
                    default: Environment.Exit(0); break;
                }
            }
        }

        private bool ReadForm()
        {
            bool flag = false;

            Console.WriteLine("--------------- Форма заказа ----------------\n");
            Console.WriteLine($"\t\tИмя: {clientName}");
            Console.WriteLine($"\t\tВозраст: {age}");
            Console.WriteLine($"\t\tНомер паспорта: {passportNumber}");
            Console.WriteLine($"\t\tАвтомобиль: {car}");
            Console.WriteLine($"\t\tВремя аренды: {rentalPeriod}");

            Console.WriteLine("\t\tВерно?\n1 - Да\n2 - Нет");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: flag = true; break;
                case 2: flag = false; break;
                default: Console.WriteLine("Такого варианта ответа нет!"); ReadForm(); break;
            }

            return flag;
        }

    }
    

}
