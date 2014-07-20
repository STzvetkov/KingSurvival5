using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalRefactored
{
    /// <summary>
    /// Represents a cell from the playing field of the table
    /// </summary>
    public class FieldCell
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

            set
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

            set
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

            set 
            {
                this.color = value;
            }
        }
    }
}
