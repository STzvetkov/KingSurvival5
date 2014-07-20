using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    class ConsoleWriter:IWeiter
    {
        public ConsoleColor BackgroundColor
        {
            set
            {
                Console.BackgroundColor = value;
            }
        }

        public void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public void Write(char input)
        {
            Console.Write(input);
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(char input)
        {
            Console.WriteLine(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }
    }
}
