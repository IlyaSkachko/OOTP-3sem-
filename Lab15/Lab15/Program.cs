using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace Lab15
{
    class Program
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {

                    case 1:
                        #region task1

                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        Action action = new Action(Vector);

                        Task task1 = new Task(action);
                        task1.Start();


                        int[] vect = new int[100000];



                        for (int i = 0; i < 100000; i++)
                        {
                            if (i == 5000)
                            {
                                if (!task1.IsCompleted)
                                {
                                    Console.WriteLine($"\n----------\n\n{task1.Status}\n\n-----------------");
                                }
                                Thread.Sleep(3000);

                            }
                            vect[i] = new Random().Next(2000);
                            Console.WriteLine("Main:" + (vect[i] *= new Random().Next(2000, 4000)));

                        }
                        if (task1.IsCompleted)
                        {
                            stopwatch.Stop();
                            TimeSpan ts = stopwatch.Elapsed;
                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                                ts.Hours, ts.Minutes, ts.Seconds,
                                                                ts.Milliseconds / 10);
                            Console.WriteLine("\n\n---------------\nRunTime " + elapsedTime);
                        }


                        break;
                        #endregion

                    case 2:

                        #region task2
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        CancellationToken token = cancellationTokenSource.Token;
                        action = new Action(Vector);
                        Task task2 = new Task(() =>
                        {
                            Console.WriteLine($"\n----------\n\n{Task.CurrentId}\n\n-----------------");
                            int[] vect = new int[100000];

                            for (int i = 0; i < 100000; i++)
                            {
                                if (token.IsCancellationRequested)
                                {
                                    Console.WriteLine("\n\n ----\n\tВыполнение прервано\n---------------");
                                    return; 
                                }
                                vect[i] = new Random().Next(2000);
                                Console.WriteLine("Умножения вектора на число:" + (vect[i] *= new Random().Next(2000, 4000)));
                            }
                        }, token);
                        task2.Start();

                        vect = new int[100000];

                        for (int i = 0; i < 100000; i++)
                        {
                            if (i == 5000)
                            {
                                if (!task2.IsCompleted)
                                {
                                    Console.WriteLine($"\n----------\n\n{task2.Status}\n\n-----------------");
                                    cancellationTokenSource.Cancel();
                                }
                                cancellationTokenSource.Dispose();
                                Thread.Sleep(4000);

                            }
                            vect[i] = new Random().Next(2000);
                            Console.WriteLine("Main:" + (vect[i] *= new Random().Next(2000, 4000)));

                        }


                        break;
                    #endregion


                    case 3:

                        #region task3
                        int square = default;
                        int volume = default;
                        string figure = default;

                        Task task3 = new Task(() =>
                        {
                            int h = 3;
                            int w = 5;
                            square = h * w;
                        });

                        Task task4 = new Task(() =>
                        {
                            int h = 3;
                            int w = 5;
                            int l = 10;
                            volume = h * w * l;
                        });

                        Task task5 = new Task(() =>
                        {
                            figure = "Параллепипед";
                        });

                        task3.Start();
                        task4.Start();
                        task5.Start();

                        task3.Wait();
                        task4.Wait();
                        task5.Wait();

                        Console.WriteLine($"Фигура: {figure}\nПлощадь стороны: {square}\nОбъём: {volume}\n");

                        

                        break;
                    #endregion

                    case 4:
                        #region task4

                        Task tas = new Task(() =>
                        {
                            Console.WriteLine($"Id задачи: {Task.CurrentId}");
                        });

                        Task tas2 = tas.ContinueWith(Print);

                        tas.Start();

                        void Print(Task task)
                        {
                            Console.WriteLine($"\nId задачи: {Task.CurrentId}");
                            Console.WriteLine($"Id предыдущей задачи: {task.Id}");
                        }

                        async Task<int> GetOneAsync()
                        {
                            await Task.Run(() => Console.WriteLine());
                            return 12521;
                        }
                        int obj = GetOneAsync().GetAwaiter().GetResult();
                        Console.WriteLine("\nПункт 2: " + obj);
                        break;

                    #endregion

                    case 5:

                        #region task5
                        Stopwatch stopwatch1 = new Stopwatch();
                        stopwatch1.Start();
                        Parallel.For(1, 10000, arr);
                        stopwatch1.Stop();


                        void arr(int i)
                        {
                            int[] a = new int[10000];
                            a[i] = i;
                            Console.WriteLine(a[i]);
                        }

                        Stopwatch stopwatch2 = new Stopwatch();
                        void arr2()
                        {

                            stopwatch2.Start();
                            int[] a = new int[10000];
                            for (int i = 0; i < 10000; i++)
                            {

                                a[i] = i;
                                Console.WriteLine(a[i]);
                            }
                            stopwatch2.Stop();
                        }
                        arr2();
                        TimeSpan ts1 = stopwatch1.Elapsed;
                        string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                            ts1.Hours, ts1.Minutes, ts1.Seconds,
                                                            ts1.Milliseconds / 10);
                        Console.WriteLine("\n\n---------------\nRunTime Parallel" + elapsedTime1); 
                        
                        TimeSpan ts2 = stopwatch2.Elapsed;
                        string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                            ts2.Hours, ts2.Minutes, ts2.Seconds,
                                                            ts2.Milliseconds / 10);
                        Console.WriteLine("\n\n---------------\nRunTime cycle " + elapsedTime2);
                        break;
                    #endregion

                    case 6:

                        #region task6

                        Parallel.Invoke(
                            () =>
                            {
                                for (int i = 0; i < 10000; i++) Console.WriteLine(i);
                            },                            
                            () =>
                            {
                                for (int i = 0; i < 10000; i++) Console.WriteLine((char)new Random().Next(1, 255));
                            }
                        );

                        break;

                    #endregion

                    case 7:

                        #region task7

                        BlockingCollection<string> bc = new BlockingCollection<string>(5);

                        Task[] sellers = new Task[10]
                        {
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Стол"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Шкаф"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Зеркало"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Бра"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Подоконник"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Микроволновка"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Кровать"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Дверь"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Вазон"); } }),
                            new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Стул"); } })
                        };

                        Task[] consumers = new Task[5]
                        {
                            new Task(() => { while (true) { Thread.Sleep(300); bc.Take(); } }),
                            new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
                            new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
                            new Task(() => { while (true) { Thread.Sleep(400); bc.Take(); } }),
                            new Task(() => { while (true) { Thread.Sleep(250); bc.Take(); } })
                        };

                        foreach (var i in sellers)
                            if (i.Status != TaskStatus.Running)
                                i.Start();

                        foreach (var i in consumers)
                            if (i.Status != TaskStatus.Running)
                                i.Start();

                        int count = 1;
                        while (true)
                        {
                            if (bc.Count != count && bc.Count != 0)
                            {
                                count = bc.Count;
                                Thread.Sleep(500);
                                Console.Clear();
                                Console.WriteLine("---Склад---");

                                foreach (var i in bc)
                                    Console.WriteLine(i);
                            }
                        }

                        break;

                    #endregion

                    case 8:

                        #region task8
                        void Factorial()
                        {
                            int result = 1;
                            for (int i = 1; i <= 6; i++)
                                result *= i;
                            Thread.Sleep(1000);
                            Console.WriteLine($"6! = {result}");
                        }

                        async void FactorialAsync()
                        {
                            Console.WriteLine("FA start");
                            await Task.Run(() => Factorial());
                            Console.WriteLine("FA ends");
                        }

                        FactorialAsync();
                        Console.ReadKey();
                        break;

                    #endregion

                    default: Console.WriteLine("такого нет"); break;
                }
            }
        }
        
        static void Vector()
        {
            int[] vect = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                vect[i] = new Random().Next(2000);
                Console.WriteLine("Vector:" + (vect[i] *= new Random().Next(2000, 4000)));

            }
        }

    }

}