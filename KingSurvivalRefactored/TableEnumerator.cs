﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored
{
    public class TableEnumerator : IEnumerator
    {
        //If we need a performance boost, we can make iterationTarget a simple array of cells.
        private readonly Table iterationTarget;

        private int currentX;
        private int currentY;

        private ICell lastCell;

        //will be needed to trace the state of the enumerator
        public TableEnumerator(Table table)
        {
            if (table == null)
            {
                throw new ArgumentNullException("The Enumerator can not work with a uninitialized table.");
            }
            else if (table.Cells.Length == 0)
            {
                throw new ArgumentOutOfRangeException("The Enumerator cant work with a empty table.");
            }

            this.iterationTarget = table;
            this.Reset();
        }

        public bool MoveNext()
        {
            this.currentX++;
            if (this.currentX == iterationTarget.Cells.GetLength(0))
            {
                this.currentX = 0;
                this.currentY++;
                if (this.currentY == iterationTarget.Cells.GetLength(1))
                {
                    return false;
                }
            }

            this.lastCell = this.iterationTarget.Cells[this.currentX, this.currentY];
            return true;
        }

        public void Reset()
        {
            this.currentX = -1;
            this.currentY = 0;
            this.lastCell = this.iterationTarget.Cells[0, 0];
        }

        public object Current
        {
            get
            {
                return lastCell;
            }
        }
    }
}
