namespace KingSurvivalRefactored
{
    using System;
    using System.Linq;
    using KingSurvivalRefactored.Interfaces;

    public abstract class Figure : IFigure
    {
        private ICell containingCell;
        private char drawingRepresentation;

        // TODO: fix the valid symbols
        private char[] validSymbols = { 'K', 'A', 'B', 'C', 'D' };

        public Figure(ICell containingCell, char drawingRepresentation)
        {
            this.ContainingCell = containingCell;
            this.DrawingRepresentation = drawingRepresentation; // probably not needed
            this.ContainingCell.Value = this.DrawingRepresentation;
        }

        /// <summary>
        /// The cell in which the figure is positioned
        /// </summary>
        public ICell ContainingCell
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
                if (this.validSymbols.Contains(value))
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
        public void ChangePosition(ICell newCell, ITable table)
        {
            table.Cells[this.ContainingCell.Row, this.ContainingCell.Col].Value = ' ';
            newCell.Value = this.DrawingRepresentation;
            table.Cells[newCell.Row, newCell.Col].Value = newCell.Value;
            this.ContainingCell = newCell;
        }
    }
}
