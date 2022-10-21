// Транспорт, Авиация, Грузовой самолет, Пассажирский, Военный.

namespace Lab4
{
    internal abstract class Transport   
    {   
        public abstract string Type { get; }

        public abstract int Capacity { get; } 

        public abstract void Move();
        
    }
}
