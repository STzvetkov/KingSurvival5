using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalRefactored
{
    public abstract class Figure : IFigure
    {
        private FieldCell containingCell;
        private char drawingRepresentation;
        private char[] VALID_SYMBOLS = {'K', 'A', 'B', 'C', 'D'};

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
                return this.containingCell;
            }
            set
            {
                this.containingCell = value;
            }
        }

        /// <summary>
        /// The image of the figure that will be shown on the table
        /// </summary>
        public char DrawingRepresentation
        {
            get
            {
                return this.drawingRepresentation;
            }
            set
            {
                if (VALID_SYMBOLS.Contains(value))
                {
                    this.drawingRepresentation = value;
                }
                else
                {
                    throw new ArgumentException("The Symbol must be one of the following: K, A, B, C, D");
                }
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
