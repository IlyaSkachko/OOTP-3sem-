using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
    internal class Interface
    {

        private static Interface instance;
        private Interface()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        public static Interface getInstance()
        {
            if (instance == null)
                instance = new Interface();
            return instance;
        }


    }
}
