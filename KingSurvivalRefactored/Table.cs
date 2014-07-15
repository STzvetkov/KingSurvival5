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

        public Table(FieldCell[,] cells, Frame frame)
        {
            this.Cells = cells;
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

        public IEnumerator GetEnumerator()
        {
            return new TableEnumerator(this);
        }


    }
}
