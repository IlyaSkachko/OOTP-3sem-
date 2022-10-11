

using System.Collections;

namespace Lab9
{
    internal class LinkList<T> : IEnumerable
    {

        public Item<T> Head { get; private set; }
        public Item<T> Tail { get; private set; }

        public int Count { get; private set; }  

        public LinkList()
        {
            Clear();
        }

        public void Add(T data)
        {
            var item = new Item<T>(data);   
            if (Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                Head = item;
                Tail = item;
                Count = 1;
            }
        }

        public void Delete(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                 
                var current = Head.Next;
                var prev = Head;
                while(current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        prev.Next = current.Next;
                        Count--;
                        return;
                    }

                    prev = current;
                    current = current.Next;
                }
            }
        }


        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
