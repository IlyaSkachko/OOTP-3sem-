using System.Runtime.Serialization;
namespace Lab4
{
    [DataContract]
    internal abstract partial class Aviation : Transport, ITransport
    {
        [DataMember]
        public virtual string Name { get; set; }
        
        [DataMember]
        public abstract int ID { get; set; }     
        


        public virtual void Height()
        {
            Console.WriteLine("Высота полёта 5000м");
        }


        public void AviationLanding()
        {
            Console.WriteLine("Происходит посадка");
        }

        public override void Move()
        {
            Console.WriteLine("Летит");
        }

        void ITransport.Move()
        {
            Console.WriteLine("Летит(через интерфейс)");
        }

    }
}
