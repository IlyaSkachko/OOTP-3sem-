

using System.Drawing;

namespace Cont
{
    public interface IWater
    {
        void WaterPlant();
    }


    class Program
    {
        public static void Main(string[] args)
        {

            #region task1
            Console.WriteLine(float.MaxValue);

            int[][] arr = new int[2][];
            arr[0] = new int[3] { 1, 2, 3 };
            arr[1] = new int[5] { 1, 2, 3, 4, 5 };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            #endregion


            #region task2

            var plant = new Plant("flower", Color.Red);
            var plant2 = new Plant("flower", Color.Red);

            Console.WriteLine(plant == plant2);
            #endregion

            #region task3
            IWater water = new Flower(Color.Pink);
            IWater water1 = new Plant(Color.White);

            water.WaterPlant();
            water1.WaterPlant();
            #endregion
        }
    }

    public class Plant : IWater
    {
        public const string Name = "Rose"; 
        public string Group { get; set; }
        public Color Color { get; set; }


        public Plant(Color color)
        {
            Group = "flower";
            Color = color;
        }
        public Plant (string group, Color color)
        {
            Group = group;
            Color = color;
        }

        public override string ToString()
        {
            return $"Name {Name}\nGroup: {Group}\nColor: {Color}";
        }

        public void WaterPlant()
        {
            Console.WriteLine("Растение полито");
        }

        public static bool operator ==(Plant obj1, Plant obj2)
        {
            if (obj1.Group.Equals(obj2.Group))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator != (Plant obj1, Plant obj2)
        {
            if (obj1.Group.Equals(obj2.Group))
            { 
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class Flower : Plant, IWater
    {
        public Color Color { get; set; }
        public Flower(Color color) : base(color)
        {
            Color = color;
        }


        public new void WaterPlant()
        {
            base.WaterPlant();
        }

/*        void IWater.WaterPlant()
        {
            Console.WriteLine("Цветок полит");
        }*/

    }
}