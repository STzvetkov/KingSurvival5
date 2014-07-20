using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    public class Table : IEnumerable // Iterator pattern - foreach on Table instance iterates over the table cells
    {
        private FieldCell[,] cells;
        private Frame frame;

        public Table(IFieldCellFactory cellCreator, Frame frame)
        {
            InitializeCells(cellCreator);
            this.TableFrame = frame;
        }

        public FieldCell[,] Cells
        {
            get
            {
                return cells;
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

        public Frame TableFrame
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

        public IEnumerator<FieldCell> GetEnumerator()
        {
            for (int i = 0; i < this.cells.GetLength(0); i++)
            {
                for (int j = 0; j < this.cells.GetLength(1); j++)
                {
                    yield return this.cells[i, j];
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void InitializeCells(IFieldCellFactory cellCreator)
        {
            if (cellCreator==null)
            {
                throw new ArgumentNullException("Class table cant correctly initialize with a null reference for a cellCreator");
            }
            FieldCell[,] cells = new FieldCell[cellCreator.ColCount,cellCreator.RowCount ];
            for (int i = 0; i < cellCreator.RowCount; i++)
            {
                for (int j = 0; j < cellCreator.ColCount; j++)
                {
                    cells[j, i] = cellCreator.GenerateNextCell();
                }
            }
            this.Cells=cells;
        }
    }
}
