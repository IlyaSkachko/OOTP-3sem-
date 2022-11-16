

namespace Lab17_18
{
    internal abstract class Prototype
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public Prototype(string name)
        {
            Name = name;
        }
        public abstract Prototype Clone();

        public abstract bool AcceptForm(bool accept);


       
    }

    class AdministratorB : Prototype
    {
        public AdministratorB(string name)
            : base(name)
        { }
        public override Prototype Clone()
        {
            return new AdministratorB(Name);
        }
        public override bool AcceptForm(bool accept)
        {
            if (!accept)
            {
                Message = Console.ReadLine();
            }


            return accept;
        }

    }
}
