namespace KingSurvivalRefactored
{
    using System;
    using KingSurvivalRefactored.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public ConsoleColor BackgroundColor
        {
            set
            {
                Console.BackgroundColor = value;
            }
        }

        public ConsoleColor ForegroundColor
        {
            set
            {
                Console.ForegroundColor = value;
            }
        }

        public int LargestWindowWidth
        {
            get
            {
                return Console.LargestWindowHeight;
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
