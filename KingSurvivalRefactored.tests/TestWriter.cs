﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored.tests
{
    class TestWriter : IWriter
    {
        public TestWriter()
        {
            ResetColor();
            positionX = 0;
            positionY = 0;
            result = new StringBuilder();
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

        private string backGroundColor;
        private string foregroundColor;
        private int positionX;
        private int positionY;
        private StringBuilder result;
    }
}