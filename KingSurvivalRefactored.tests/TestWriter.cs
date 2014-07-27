namespace KingSurvivalRefactored.Tests
{
    using System;
    using System.Text;
    using KingSurvivalRefactored.Interfaces;

    public class TestWriter : IWriter
    {
        public TestWriter()
        {
            ResetColor();
            positionX = 0;
            positionY = 0;
            result = new StringBuilder();
            LargestWindowWidth = 150;
        }
        public string GetResult()
        {
            return result.ToString();
        }
        public ConsoleColor BackgroundColor
        {
            set { backGroundColor = value.ToString(); }
        }

        public ConsoleColor ForegroundColor
        {
            set { foregroundColor = value.ToString(); }
        }

        public void SetCursorPosition(int x, int y)
        {
            positionY = y;
            positionX = x;
        }

        public void Write(char input)
        {
            Write(input.ToString());
        }

        public void Write(string input)
        {
            result.Append(" Printed '" + input + "' at x:" + positionX
                + " y:" + positionY + " colors bg: " + backGroundColor + " fg: " + foregroundColor);
        }

        public void WriteLine(char input)
        {
            Write(input.ToString());
        }

        public void WriteLine(string input)
        {
            Write(input.ToString());
        }

        public void ResetColor()
        {
            backGroundColor = "black";
            foregroundColor = "white";
        }

        public int LargestWindowWidth
        {
            get;
            set;
        }

        private string backGroundColor;
        private string foregroundColor;
        private int positionX;
        private int positionY;
        private StringBuilder result;
    }
}
