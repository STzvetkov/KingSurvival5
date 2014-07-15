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
                throw new NotImplementedException();
            }

            private set
            {
                throw new NotImplementedException();
            }
        }

        public Frame TableFrame
        {
            get
            {
                throw new NotImplementedException();
            }

            private set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
