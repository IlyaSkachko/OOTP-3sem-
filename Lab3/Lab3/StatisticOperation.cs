
namespace Lab3
{
    static class StatisticOperation
    {
        static StatisticOperation()
        {
            Console.WriteLine("\n\nСтатический констуктор\n\n");
        }

        public static int Sum(int[] items)
        {
            return items.Sum(); ;
        }   
        
        public static string Sum(this string[] items)
        {
            string str = "";
            for (var i = 0; i < items.Length; i++)
            {

                str += items[i];
                if (i != items.Length - 1)
                {
                    str += " + ";
                }
            }

            return str;
        }

        public static int Difference(int[] arr)
        {
            return arr.Max() - arr.Min();
        }     
        
        public static int Difference(this string[] arr)
        {
            if (arr != null)
            {
                
                return Math.Abs(arr[0].Length - arr[arr.Length-1].Length);
            }
            else
            {
                return 0;
            }
        }      

        public static int Count(int[] arr)
        {
            return arr.Length;
        }        
        
        public static int Count(this string[] arr)
        {
            return arr.Length;
        }
    }
}
