

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var boeing = new Millitary("Boeing", 4);

            var TU_134 = new Passenger("ТУ-134", 80);

            boeing.Move();

            TU_134.Move();

            boeing.Fire();

            TU_134.Boarding();

            TU_134.AviationLanding();

            Console.WriteLine("\nEquals " + TU_134.Equals(boeing));

            Console.WriteLine(TU_134.ToString());

            Console.WriteLine(boeing.ToString());


            var cargo = new Cargo("Cargo", 19);
            var printer = new Printer();

            var arr = new Transport[3];
            arr[0] = TU_134;
            arr[1] = boeing;
            arr[2] = cargo;


            Console.WriteLine();
            foreach (var i in arr)
            {
                printer.IAmPrinting(i);
            }
        }
    }
}