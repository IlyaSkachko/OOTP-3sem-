

using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab9
{
    class Program
    {
        public static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine();

                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {

                    #region task1
                    case 1:

                        var collection = new BlockingCollection<Game>();

                        Console.WriteLine("\n -----  Добавление -------\n");

                        for (int i = 0; i < 4; i++)
                        {
                            collection.Add(new Game());
                        }


                        foreach (var item in collection)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("\n ------ Удаление ------ \n");
                        collection.Take();

                        foreach (var item in collection)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("\n ------ Поиск ------ \n");


                        int X = Convert.ToInt32(Console.ReadLine());

                        foreach (var item in collection)
                        {
                            if (item.point.X == X)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine("\n\n ---- GetEnumerator -----");

                        Game game = new Game();

                        foreach (var i in game)
                        {
                            Console.WriteLine(i);
                        }
                        break;


                        #endregion

                    #region task2
                            
                        case 2:
                        var col = new LinkList<int>();

                        col.Add(1);
                        col.Add(2);
                        col.Add(3);
                        col.Add(4);
                        col.Add(5);

                        foreach (var i in col)
                        {
                            Console.Write(i + "\t");
                        }
                        Console.WriteLine();
                        Console.WriteLine();

                        col.Delete(3);


                        foreach (var i in col)
                        {
                            Console.Write(i + "\t");
                        }

                        Console.WriteLine();

                        var queue = new Queue<int>();

                        queue.Enqueue(12);
                        queue.Enqueue(7);
                        queue.Enqueue(1);
                        queue.Enqueue(2);
                        queue.Enqueue(3);
                        queue.Enqueue(4);
                        queue.Enqueue(5);
                        queue.Enqueue(5);


                        queue.Show();

                        if (queue.Count < col.Count)
                        {
                            Console.WriteLine("HashCode" + queue.GetHashCode());
                        }
                        else if (queue.Count > col.Count)
                        {
                            var list = new List<int>();
                            Console.WriteLine("\n\nОтличие: ");
                            for (int i = 0; i < queue.Count - col.Count + 1; i++)
                            {
                                var item = queue.Dequeue();
                                Console.WriteLine(item);
                                list.Add(item);
                            }

                            for (int i = list.Count - 1; i >= 0; i--)
                            {
                                queue.EnqueueStart(list[i]);
                            }
                        }
                        queue.Show();

                        Console.WriteLine("\n\nВведите значение которое хотите найти");
                        var fl = Convert.ToInt32(Console.ReadLine());

                        var items = new List<int>();
                        var count = queue.Count;
                        for (int i = 0; i < count; i++)
                        {
                            var item = queue.Dequeue();
                            if (item == fl)
                            {
                                Console.WriteLine("Нашёл " + fl);
                            }
                            items.Add(item);
                        }

                        for (int i = items.Count - 1; i >= 0; i--)
                        {
                            queue.EnqueueStart(items[i]);
                        }

                        queue.Show();
                        break;
                    #endregion

                    #region task3
                    case 3:
                        var observarble = new ObservableCollection<Game>();
                        observarble.CollectionChanged += Observarble_CollectionChanged;


                        var games = new Game();
                        observarble.Add(games);
                        observarble.Add(new Game());
                        observarble.Add(new Game());
                        observarble.Add(new Game());


                        observarble.Remove(games);


                        break;
                    #endregion
                    default:
                        Console.WriteLine("Нет такого");
                        break;
                }
            }
        }

        private static void Observarble_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is Game newGame)
                        Console.WriteLine($"Добавлен новый объект: {newGame.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is Game oldGame)
                        Console.WriteLine($"Удален объект: {oldGame.Name}");
                    break;
            }
        }

        public static void Add()
        {
        }
    }
}