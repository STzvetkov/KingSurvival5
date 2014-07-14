using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalRefactored
{
    public abstract class Figure
    {
        private FieldCell containingCell;
        private char drawingRepresentation;

        public Figure(FieldCell containingCell, char drawingRepresentation)
        {
            this.ContainingCell = containingCell;
            this.DrawingRepresentation = drawingRepresentation; // probably not needed
            this.ContainingCell.Value = this.DrawingRepresentation;
        }
        public FieldCell ContainingCell
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public char DrawingRepresentation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public abstract string[] AllowedMoves
        {
            get;
        }
        

        public void ChangePosition(FieldCell newCell)
        {
            throw new System.NotImplementedException();
        }

    }
}
