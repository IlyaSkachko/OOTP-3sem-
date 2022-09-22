
namespace Lab4
{
    internal class Printer
    {
        public void IAmPrinting(Transport transport)
        {
            Console.WriteLine($"Тип объекта: {transport.GetType()}");
            Console.WriteLine($"ToString:\t {transport.ToString()}\n\n");
        }

    }
}
