

using System.Collections;

namespace Lab9
{
    internal class Game : IEnumerable
    {

        public Point point = new Point();

        public int[,] points = new int[1, 2]; 
        public struct Point
        {
            public int X;
            public int Y;

            public Point()
            {
                X = 1; Y = 2;
            }
        }


        public string Name { get { return "Змейка"; } }

        public Game()
        {
            try
            {
                Play();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка");
            }
            finally
            {
                GameOver();
            }
        }


        public void Play()
        {
            point.X = new Random().Next(1, 500);
            point.Y = new Random().Next(1, 500);       
            points[0, 0] = point.X;
            points[0, 1] = point.Y;
        }



        public void GameOver()
        {
            Console.WriteLine("Game Over!");
        }

        public override string ToString()
        {
            return $"\nНазвание: {Name}\nX: {point.X}\nY:{point.Y}";
        }

        public IEnumerator GetEnumerator() => points.GetEnumerator();

    }
}
