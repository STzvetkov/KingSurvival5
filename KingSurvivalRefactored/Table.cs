using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvivalRefactored.Interfaces;


namespace KingSurvivalRefactored
{
    public class Table : IEnumerable, ITable // Iterator pattern - foreach on Table instance iterates over the table cells
    {
        private ICell[,] cells;
        private IFrame frame;
        
        public Table(IFieldCellFactory cellCreator, IFrame frame)
        {
            InitializeCells(cellCreator);
            this.Frame = frame;
        }

        public ICell[,] Cells
        {
            get
            {
                return this.cells;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The array of FieldCell-s given to the table is null. This is unacceptable behaviour");
                }
                for (int i = 0; i < value.GetLength(0); i++)
                {
                    for (int j = 0; j < value.GetLength(1); j++)
                    {
                        if (value[i,j] == null)
                        {
                            throw new ArgumentNullException("One of the FieldCells in the given array is null");
                        }
                    }
                }
                this.cells = value;
            }
			
                
        }

        public IFrame Frame
        {
            get
            {
                return frame;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The Frame given to the table is null.");
                }
                this.frame = value;
            }
        }

        

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new TableEnumerator(this);
        }

        private void InitializeCells(IFieldCellFactory cellCreator)
        {
            if (cellCreator==null)
            {
                throw new ArgumentNullException("Class table cant correctly initialize with a null reference for a cellCreator");
            }
            FieldCell[,] cells = new FieldCell[cellCreator.RowCount ,cellCreator.ColCount];
            for (int i = 0; i < cellCreator.RowCount; i++)
            {
                for (int j = 0; j < cellCreator.ColCount; j++)
                {
                    cells[i, j] = cellCreator.GenerateNextCell();
                }
            }
            this.Cells=cells;
        }
    }
}
