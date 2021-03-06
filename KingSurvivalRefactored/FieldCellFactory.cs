﻿namespace KingSurvivalRefactored
{
    using System;
    using KingSurvivalRefactored.Interfaces;

    public class FieldCellFactory : IFieldCellFactory
    {
        private readonly ConsoleColor evenColor;
        private readonly ConsoleColor oddColor;

        private readonly char representationChar;

        private bool currentCellIsOdd;

        private int colCount;
        private int rowCount;

        private int currentCol;
        private int currentRow;

        public FieldCellFactory(int rowCount, int colCount, char representationChar, ConsoleColor evenColor, ConsoleColor oddColor)
        {
            this.RowCount = rowCount;
            this.ColCount = colCount;

            this.currentCol = 0;
            this.currentRow = 0;

            this.evenColor = evenColor;
            this.oddColor = oddColor;

            this.representationChar = representationChar;
            this.currentCellIsOdd = true;
        }
        
        public int RowCount
        {
            get
            {
                return this.rowCount;
            }

            private set
            {
                if (value < 8 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("The number of rows must be between 8 and 20");
                }

                this.rowCount = value;
            }
        }

        public int ColCount
        {
            get
            {
                return this.colCount;
            }

            private set
            {
                if (value < 8 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("The number of columns must be between 8 and 20");
                }

                this.colCount = value;
            }
        }

        public FieldCell GenerateNextCell()
        {
            ConsoleColor currentCellColor = this.currentCellIsOdd ? this.oddColor : this.evenColor;
            FieldCell result = new FieldCell(this.currentCol, this.currentRow, this.representationChar, currentCellColor);
            this.currentCol++;
            if (this.currentCol == this.ColCount)
            {
                this.currentCol = 0;
                this.currentRow++;
                this.currentCellIsOdd = !this.currentCellIsOdd;

                if (this.currentRow > this.RowCount)
                {
                    throw new InvalidOperationException("All cells were generated.");
                }
            }

            this.currentCellIsOdd = !this.currentCellIsOdd;

            return result;
        }
    }
}
