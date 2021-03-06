﻿namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.Interfaces;

    /// <summary>
    /// A class used to perform various checks on figures and cells
    /// </summary>
    public class Checker // To be made Singleton
    {
        private const char EmptyCell = ' ';
        private static Checker instance;

        private Checker()
        {
        }

        public static Checker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Checker();
                }

                return instance;
            }
        }

        /// <summary>
        /// Extracts the last two letters from the input and searches for them the figureToCheck.AllowedMoves.
        /// Checks only if the figure is allowed by the rules to perform such move. Does not check if the new cell is available
        /// </summary>
        /// <param name="figureToCheck">The figure that is checked if it can perform the move</param>
        /// <param name="input">The user move input</param>
        /// <returns>
        /// True if the figure can perform move in the direction given.
        /// False if it can't
        /// </returns>
        public bool IsValidMove(IFigure figureToCheck, string input)
        {
            input = input.ToUpper();

            // Check if the figure given can move in the direction from the input 
            int len = input.Length;
            string lastTwoLetters = input[len - 2].ToString() + input[len - 1];

            string[] allowedMoves = figureToCheck.AllowedMoves;

            for (int i = 0; i < allowedMoves.Length; i++)
            {
                if (allowedMoves[i] == lastTwoLetters)
                {
                    // The figure can perform a move in this direction.
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks the Y position of the king.
        /// </summary>
        /// <param name="king">The king to be checked</param>
        /// <returns>True if the king reached the top of the board. False if it hasn't</returns>
        public bool HasKingWon(King king)
        {
            // Check if king reached the top of the board
            if (king.ContainingCell.Row == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Extracts the coordinates the upper left, upper right, lower left and lower right cells according to the king.
        /// </summary>
        /// <param name="king">The king</param>
        /// <param name="table">The table containing all the field cells</param>
        /// <returns>
        /// True if all of the cells checked are either taken by another figure 
        /// or are outside of the table - do not exist in the table parameter
        /// </returns>
        public bool HasKingLost(King king, ITable table)
        {
            int kingRow = king.ContainingCell.Row;
            int kingCol = king.ContainingCell.Col;
            int tableHeight = table.Cells.GetLength(0);
            int tableWidth = table.Cells.GetLength(1);

            bool isUpperLeftCellFree;
            bool isUpperRightCellFree;
            bool isLowerLeftCellFree;
            bool isLowerRightCellFree;

            if (kingRow > 0 && kingCol > 0)
            {
                isUpperLeftCellFree = table.Cells[kingRow - 1, kingCol - 1].IsFree;
            }
            else
            {
                isUpperLeftCellFree = false;
            }

            if (kingRow > 0 && kingCol < tableWidth - 1)
            {
                isUpperRightCellFree = table.Cells[kingRow - 1, kingCol + 1].IsFree;
            }
            else
            {
                isUpperRightCellFree = false;
            }

            if (kingRow < tableHeight - 1 && kingCol > 0)
            {
                isLowerLeftCellFree = table.Cells[kingRow + 1, kingCol - 1].IsFree;
            }
            else
            {
                isLowerLeftCellFree = false;
            }

            if (kingRow < tableHeight - 1 && kingCol < tableWidth - 1)
            {
                isLowerRightCellFree = table.Cells[kingRow + 1, kingCol + 1].IsFree;
            }
            else
            {
                isLowerRightCellFree = false;
            }

            if (isUpperLeftCellFree || isUpperRightCellFree || isLowerLeftCellFree || isLowerRightCellFree)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the current turn is King's or Pawn's and then
        /// checks if the first letter of the user input matches the drawing representation
        /// a figure which turn it is(king or pawn) in the figures array.
        /// </summary>
        /// <param name="counter">
        /// The move counter of the game. 
        /// Odd number means it's king's turn, even number means it's pawn's turn.
        /// </param>
        /// <param name="input">The user move input</param>
        /// <param name="figures">The figures on the playing table</param>
        /// <returns>
        /// True if there is figure with such drawing representation and it is its turn.
        /// False in any other case
        /// </returns>
        public bool IsValidFigureRequested(int counter, string input, IFigure[] figures)
        {
            input = input.ToUpper();

            // Check if it is King's or Pawn's turn with the counter(odd or even) and check if the first letter of the input is correct
            if (counter % 2 != 0)
            {
                // It's King's turn
                if (input[0] == figures[0].DrawingRepresentation)
                {
                    return true;
                }
            }
            else
            {
                // It's pawn's turn
                char currentFigureDrawingRepresentation;
                for (int i = 1; i < figures.Length; i++)
                {
                    currentFigureDrawingRepresentation = figures[i].DrawingRepresentation;
                    if (currentFigureDrawingRepresentation == input[0])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsRequestedPositionInsideTable(int newX, int newY, ITable table)
        {
            if (newY >= 0 && newY < table.Cells.GetLength(0) &&
                newX >= 0 && newX < table.Cells.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
