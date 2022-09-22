// Создать класс Customer: id, Фамилия, Имя, Адрес, Номер кредитной карточки, баланс.
// Свойства и конструкторы должны обеспечивать проверку корректности.
// Добавить методы зачисления и списания сумм на счет.

namespace Lab2
{
    public partial class Customer
    {

        public readonly int ID;
        public static int Count = 0;

        public const string className = "Customer";

        private string name;
        private string surname;
        private string adress;
        private int cardNumber;
        private int balance = 0;
        private Random rand = new Random();


        public string Name { get { return name; } }
        public string Surname { get { return surname; } }
        public string Adress { get { return adress; } set { adress = value; } }
        public int CardNumber { get { return cardNumber; } }
        public int Balance { get { return balance; } set {if (balance >= 0) balance = value; } }



        static Customer()
        {
            Console.WriteLine("----------------- Класс Customer -------------");
        }

        private Customer(int id)
        {
            ID = id;
        }
        public Customer()
        {
            var customerID = new Customer(GetHashCode());
            ID = customerID.ID;

            while (true)
            {
                Console.WriteLine("Введите имя: ");
                name = Console.ReadLine();
                Console.WriteLine("Введите фамилию: ");
                surname = Console.ReadLine();
                Console.WriteLine("Введите адрес: ");
                adress = Console.ReadLine();
                Console.WriteLine("Введите номер карты: ");
                cardNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите Баланс: ");
                balance = Convert.ToInt32(Console.ReadLine());


                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(adress))
                {
                    Console.WriteLine("\nВведены некорректные данные\n\n");
                }
                else
                {
                    if (isNumber(name) == false && isNumber(surname) == false && cardNumber > 1000000 && cardNumber < 9999999 
                        && balance >= 0)
                    {
                        Count++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nВведены некорректные данные\n\n");
                    }
                }


            }

        }


        public Customer(string name, string surname, string adress, int cardNumber, int balance)
        {

            var customerID = new Customer(GetHashCode());
            ID = customerID.ID;

            if ((!isNumber(name) && !isNumber(surname)) || !string.IsNullOrEmpty(name) || 
                !string.IsNullOrEmpty(surname) || !string.IsNullOrEmpty(adress))
            {
                this.name = name;
                this.surname = surname;
                this.adress = adress;
            }
            else
            {
                throw new ArgumentException("Неккоректные данные!");
            }

            if (cardNumber < 1000000 || cardNumber > 9999999 || balance < 0)
            {
                throw new ArgumentException("Неккоректные данные!");
            }
            else
            {
                this.cardNumber = cardNumber;
                this.balance = balance;
                Count++;
            }



        }



        public void WriteOff(ref int amount, out int balance)
        {
            balance = this.balance - amount;
            this.balance = balance;
        }

        public void Add(ref int amount, out int balance)
        {
            balance = this.balance + amount;
            this.balance = balance;
        }


        public static void Info()
        {
            Console.WriteLine("Класс: Customer");
        }

        private bool isNumber(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsNumber(c))
                    return true;
            }
            return false;
        }
    }

    public partial class Customer
    {
        public override string ToString()
        {
            return $"\n\nИмя: {name}\n" +
                   $"Фамилия: {surname}\n" +
                   $"Адрес: {adress}\n" +
                   $"Номер счёта: {cardNumber}\n" +
                   $"Баланс: {balance}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Customer);
        }

        public bool Equals(Customer obj)
        {
            return obj != null && ID == obj.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(cardNumber, rand.Next(100, 10000));
        }
    }
    
}
