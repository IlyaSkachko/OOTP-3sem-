
namespace Lab11
{
    public class Person : ICloneable
    {
        private Type type = typeof(Person);

        private string name;
        private int age;
        public int Age { get { return age; } }
        public string Name { get { return name; } }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public Person() { name = "Vasya"; }

        public void Show()
        {
            Console.WriteLine(ToString());
        }

        
        public int Method1(int i)
        {
            return i;
        }

        public override string ToString()
        {
            return $"Name: {name}\nAge: {age}\n";
        }

        public object Clone()
        {
            return Name.Clone();
        }
    }
}
