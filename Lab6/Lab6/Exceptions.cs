
namespace Lab6
{
    public class ZeroException : DivideByZeroException
    {
        public ZeroException() : base() { }
    }
    public class ArgException : ArgumentOutOfRangeException
    {
        public ArgException() : base() { }
    }
    public class NullException : NullReferenceException
    {
        public NullException(string message) : base(message) { Console.WriteLine(message); }
    }
}
