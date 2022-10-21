using System.Collections;
using System.Runtime.Serialization;

namespace Lab7
{

    public class Set<T> : IEnumerable<T>, ISet<T> where T : class
    {

        private List<T> _list = new List<T>();

        public int Count { get { return _list.Count; } }

        
        private T[] arr;

        public T[] Arr { get { return arr; } }





        public T[] InitArr()
        {
            arr = new T[_list.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = _list[i];
            }

            return arr;

        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item == null");
            }
            if (!_list.Contains(item))
            {
                _list.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("item == null");
            }
            else if (!_list.Contains(item))
            {
                throw new IndexOutOfRangeException("Не найден во множестве");
            }
            _list.Remove(item);
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentException("set1");
            }

            if (set2 == null)
            {
                throw new ArgumentException("set2");
            }

            var resultSet = new Set<T>();

            if (set1.Count < set2.Count)
            {

                foreach (var item in set1._list)
                {
                    if (set2._list.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2._list)
                {
                    if (set1._list.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }


            return resultSet;

        }

        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {


            var resultSet = new Set<T>();

            var items = new List<T>();

            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }

            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }


            if (set1._list != null && set1._list.Count > 0)
            {
                items.AddRange(new List<T>(set1._list));
            }

            if (set2._list != null && set2._list.Count > 0)
            {
                items.AddRange(new List<T>(set2._list));
            }

            resultSet._list = items.Distinct().ToList();

            return resultSet;
        }

        public static bool Subset(Set<T> set1, Set<T> set2)
        {

            if (set1 == null)
            {
                throw new ArgumentNullException("set1");
            }

            if (set2 == null)
            {
                throw new ArgumentNullException("set2");
            }

            var result = set1._list.All(s => set2._list.Contains(s));
            return result;
        }

        public void Show()
        {
            Console.WriteLine();
            foreach (var i in _list)
            {
                Console.Write(i + " \n");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }


        //   ПЕРЕГРУЗКА ОПЕРАТОРОВ


        //- - удалить элемент из множества (типа set-item);
        //* - пересечение множеств; < - сравнение множеств; > - проверка на подмножество; & - придумайте использование.

        public static Set<T> operator -(Set<T> set, T item)
        {
            set.Remove(item);
            return set;
        }
        public static Set<T> operator *(Set<T> set1, Set<T> set2)
        {
            return Intersection(set1, set2);
        }

        public static bool operator <(Set<T> set1, Set<T> set2)
        {
            bool flag = false;

            if (set1.Count == set2.Count)
            {
                for (int i = 0; i < set2.Count; i++)
                {
                    if (set1._list.Contains(set2._list[i]))
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public static bool operator >(Set<T> set1, Set<T> set2)
        {
            return Subset(set1, set2);
        }

        public static Set<T> operator &(Set<T> set1, Set<T> set2)
        {
            return Union(set1, set2);
        }


    }

   
}
