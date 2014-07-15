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

        /// <summary>
        /// The cell in which the figure is positioned
        /// </summary>
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

        /// <summary>
        /// The image of the figure that will be shown on the table
        /// </summary>
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

        /// <summary>
        /// Moves that the current figure can perform according to the rules of the game
        /// </summary>
        public abstract string[] AllowedMoves
        {
            get;
        }

        /// <summary>
        /// Changes the value of the current cell to ' '(empty cell).
        /// Changes the value of the new cell to the drawing representation of the current figure.
        /// Changes the cell in which the current figure is positioned.
        /// </summary>
        /// <param name="newCell">The new cell in which the figure will be positioned</param>
        public void ChangePosition(FieldCell newCell)
        {
            throw new System.NotImplementedException();
        }

    }
}
