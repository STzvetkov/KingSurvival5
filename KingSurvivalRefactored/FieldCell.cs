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
        public const Width = 1;
        public const Height = 1;
        
        private int coordinateX;
        private int coordinateY;
        private char value;
        private ConsoleColor color;

        public FieldCell(int coordX, int coordY, char value, ConsoleColor color)
        {
            this.CoordinateX = coordX;
            this.CoordinateY = coordY;
            this.Value = value;
            this.Color = color;
        }

        public int CoordinateX
        {
            get
            {
                return this.coordinateX;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinate X cannot be less than 0");
                }
                this.coordinateX = value;
            }
        }

        public int CoordinateY
        {
            get
            {
                return this.coordinateY;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinate Y cannot be less than 0");
                }
                this.coordinateY = value;
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
