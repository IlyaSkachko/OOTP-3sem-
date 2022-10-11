
using System.Security.Principal;

namespace Lab8
{
    internal class Programmer
    {
        public event Func<string> Rename; 
        public event Func<string, string> NewProperty; 


        public string Name { get; set; }
        public string Description { get; set; }

        public Programmer(string name)
        {
            if (name != null)
            {
                Name = name;
            }
            
            Description = "C# SQL HTML CSS JavaScript ";
        }   

        public void RenameProgrammer()
        {
            if (Rename != null)
            {
                Name = Rename?.Invoke();
            }
            else
            {
                Console.WriteLine("Имя не введено");
            }
        }        
        public void NewPropertyProgrammer(string str)
        {
            if (NewProperty != null)
            {
                Description += NewProperty?.Invoke(str) + " ";
            }
        }
    }
}
