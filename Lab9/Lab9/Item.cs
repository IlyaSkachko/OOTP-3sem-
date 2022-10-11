
using System.Collections;

namespace Lab9
{
    internal class Item<T>
    {

        private T data = default;

        public T Data { get { return data; } set { if (data != null) data = value; } }

        public Item<T> Next { get; set; }

        public Item(T data)
        {
            Data = data;   
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
