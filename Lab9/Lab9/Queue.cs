using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class Queue<T>
    {
        private List<T> _items = new List<T>();


        private T Head => _items.Last();
        private T Tail => _items.First();
        public int Count => _items.Count;

        public Queue() { }

        public void Enqueue(T data)
        {
            _items.Insert(0, data);
        }

        public void EnqueueStart(T data)
        {

            _items.Insert(Count, data);
        }

        public T Dequeue()
        {
            var item = Head;
            _items.Remove(item);
            return item;
        }

        public void Show()
        {
            Console.WriteLine();
            foreach(var i in _items)
            {
                Console.Write(i + "\t");
            }    
        }

    }   
}
