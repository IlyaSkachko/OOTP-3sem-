


using System.Diagnostics;
using System.Reflection;
using System.Security.Policy;
using System.Text;

namespace Lab14
{
    class Program
    {

        private static object locker = new object();

        private static AutoResetEvent waitHandler = new AutoResetEvent(true);  // объект-событие
        public static void Main(string[] args)
        {

            #region task5

            int num = 0;

            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(TimerWrite);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 2000);


            #endregion

            #region Process(task1)

            Process proc = Process.GetProcessesByName("devenv")[0];
            ProcessThreadCollection processThreads = proc.Threads;

            foreach (ProcessThread thread in processThreads)
            {
                Console.WriteLine($"Id: {thread.Id}\n" +
                                  $"Name: {proc.ProcessName}\n" +
                                  $"Priority: {thread.CurrentPriority}\n" +
                                  $"State: {thread.ThreadState}\n" +
                                  $"Start Time: {thread.StartTime}\n" +
                                  $"Processor Time: {thread.TotalProcessorTime}\n");
            }


            #endregion

            #region Domain(task2)

            AppDomain thisAppDomain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {thisAppDomain.FriendlyName}");
            Console.WriteLine($"Details: {thisAppDomain.SetupInformation}");
            Console.WriteLine($"Assemblies: ");
            thisAppDomain.GetAssemblies().ToList().ForEach(x => Console.WriteLine($"\t{x.FullName}"));

            #endregion

            #region task 3


            Thread thread1 = new Thread(Numbers);
            thread1.Name = "Thread1";

            Console.WriteLine("Поток Thread1 запущен");
            thread1.Start();


            Console.WriteLine($"ThreadState: {thread1.ThreadState}");
            Console.WriteLine($"ThreadName: {thread1.Name}");
            Console.WriteLine($"ThreadPriority: {thread1.Priority}");
            Console.WriteLine($"ThreadID: {thread1.ManagedThreadId}");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main");
                if (i == 50)
                {
                    Console.WriteLine("Блокировка Main");
                    thread1.Join();
                }
            }

            #endregion


            #region task4


            Console.WriteLine("\n\n\nTask 4 (Two Threads)\n\n");

            //Thread thread2 = new Thread(Odd);
            //Thread thread3 = new Thread(Even); 
            
            Thread thread2 = new Thread(OddReset);
            Thread thread3 = new Thread(EvenReset);

            thread2.Priority = ThreadPriority.Highest;

            thread2.Start();
            thread3.Start();

            #endregion



        }

        
        static void Numbers()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                if (i == 40)
                {
                    Console.WriteLine("Thread1 спит");
                    Thread.Sleep(3000);
                   
                }
          
            }
        }        

        
        static void Odd()
        {
            lock (locker)
            {
                using (var file = new StreamWriter(@"C:\UNIVER\OOTP\Lab14\Lab14\numbers.txt", true))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i);
                            file.WriteLine(i);
                        }
                    }
                }
            }
        }       
        
        static void Even()
        {
            lock (locker)
            {
                using (var file = new StreamWriter(@"C:\UNIVER\OOTP\Lab14\Lab14\numbers.txt", true))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                            file.WriteLine(i);
                        }
                    }
                }
            }
        }     
        
        static void OddReset()
        {
            for (int i = 1; i < 100; i += 2)
            {
                waitHandler.WaitOne();
                using (var file = new StreamWriter(@"C:\UNIVER\OOTP\Lab14\Lab14\numbers.txt", true))
                {
                    Console.WriteLine(i);
                    file.WriteLine(i);

                }
                waitHandler.Set();
            }

        }       
        
        static void EvenReset()
        {

            for (int i = 2; i < 100; i += 2)
            {
                waitHandler.WaitOne();
                using (var file = new StreamWriter(@"C:\UNIVER\OOTP\Lab14\Lab14\numbers.txt", true))
                {
                    Console.WriteLine(i);
                    file.WriteLine(i);
                }
                waitHandler.Set();
            }
            

        }

        static void TimerWrite(object i)
        {
            Console.WriteLine("Работа с классом таймер");
        }
    }

}