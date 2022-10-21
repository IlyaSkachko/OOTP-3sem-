
using System;
using System.Diagnostics;


namespace Lab6
{
    class Program
    {
        public static void Main(string[] args)
        {
            string exception = "";
            try
            {
                //func1();
                //func2();
                //func3(1);
                try
                {
                    Func();

                    int[] a = new int[1];

                    a[2] = 2;
                }
                catch
                {
                    throw;
                }
            }
            catch (ArgException ex)
            {
                Console.WriteLine(ex.Message);
                exception = ex.Message;
                throw new ArgException();

            }
            catch (NullException ex)
            {
                Console.WriteLine($"{ex.Message}{ex.StackTrace}\n{ex.TargetSite}\n{ex.Source}\n{ex.InnerException}");
                exception = ex.Message;
            }
            catch (ZeroException ex)
            {
                Console.WriteLine($"{ex.Message}{ex.StackTrace}\n{ex.TargetSite}\n{ex.Source}\n{ex.InnerException}");
                exception = ex.Message;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"уже не мой класс ошибок\n{ex.StackTrace}\n{ex.TargetSite}\n{ex.Source}\n{ex.InnerException}");
                exception = ex.Message;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Не мой класс ошибки");
                exception = ex.Message;
            }
            catch (DivideByZeroException ex)
            {
                exception = ex.Message;
                Console.WriteLine($"{ex.Message}{ex.StackTrace}\n{ex.TargetSite}\n{ex.Source}\n{ex.InnerException}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}{ex.StackTrace}\n{ex.TargetSite}\n{ex.Source}\n{ex.InnerException}");
                exception = ex.Message;
            }
            finally
            {
                Console.WriteLine("Всё");
                int g = 10;
                if (exception == "")
                {
                    Logger.Write("Nice program, bro");
                }
                else
                {
                    Logger.Write(exception);
                }
                Debug.Assert(g > 11);
                Debug.Assert(g > 11, "Cтек вызова");
            }
        }


        public static void func1()
        {
            int x = 2, y = x / 0;
        }  
        public static void func2()
        {
            string foo = null;
            foo.ToUpper();
        }

        public static void func3(int a)
        {
            if (a > 10)
            {
                throw new ArgException();
            }
        }
        public static void Func()
        {
            string exception = "";

            try
            {
                int i = int.Parse(Console.ReadLine());
                int[] myArr = new int[i];
                Console.WriteLine("\nВведите теперь элементы массива: ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("{0}й элемент: ", j + 1);
                    // Вложенный оператор try
                    try
                    {
                        myArr[j] = int.Parse(Console.ReadLine());
                    }
                    catch (OverflowException)
                    {
                        throw;
                    }
                }

            }
            catch (FormatException ex)
            {
                exception = ex.Message;
                Console.WriteLine("ОШИБКА: " + ex.Message);
            }

            finally
            {
                if (exception == "")
                {
                    Logger.Write("Nice program, bro");
                }
                else
                {
                    Logger.Write(exception);
                }
            }
        }
    }
}