using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    class FieldCellFactory:IFieldCellFactory
    {

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
        
        public FieldCell GenerateNextCell()
        {
            ConsoleColor currentCellColor = currentCellIsOdd?oddColor:evenColor;
            FieldCell result = new FieldCell(currentCol, currentRow, representationChar,
                currentCellColor);
             
            if (currentCol>=ColCount)
            {
                currentCol = 0;
                currentRow++;
                if (currentRow>=RowCount)
                {
                    throw new InvalidOperationException("All cells were generated.");
                }
            }
            else
            {
                currentCol++;
            }
            currentCellIsOdd = !currentCellIsOdd;

            return result;
        }

        public int RowCount
        {
            get
            {
                return this.rowCount;
            }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentOutOfRangeException("The number of rows must be greater than 0");
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
                if (value<1)
                {
                    throw new ArgumentOutOfRangeException("The number of columns must be greater than 0");
                }
                this.colCount = value;
            }
        }
        private bool currentCellIsOdd;
        private int colCount;
        private int rowCount;
        private int currentCol;
        private int currentRow;
        private readonly ConsoleColor evenColor;
        private readonly ConsoleColor oddColor;
        private readonly char representationChar;
    }
}
