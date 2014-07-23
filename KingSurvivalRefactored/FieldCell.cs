using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored
{
    /// <summary>
    /// Represents a cell from the playing field of the table
    /// </summary>
    public class FieldCell : Interfaces.ICell
    {
        private int col;
        private int row;
        private char value;
        private ConsoleColor color;

        public FieldCell(int tablePositionX, int tablePositionY, char value, ConsoleColor color)
        {
            this.Col = tablePositionX;
            this.Row = tablePositionY;
            this.Value = value;
            this.Color = color;
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinate X cannot be less than 0");
                }
                this.col = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinate Y cannot be less than 0");
                }
                this.row = value;
            }
        }

        public char Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Checks if the cell is empty
        /// </summary>
        public bool IsFree
        {
            get
            {
                return this.Value == ' ';
            }
        }

        public ConsoleColor Color
        {
            get 
            {
                return this.color;
            }

            private set 
            {
                this.color = value;
            }
        }
    }
}
