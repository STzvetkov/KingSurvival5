using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    /// <summary>
    /// A class used to perform various checks on figures and cells
    /// </summary>
    class Checker // To be made Singleton
    {
        private const char EmptyCell = ' ';
        public static Checker Instance
        {
            get
            {
                return new Checker();
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
        public bool IsValidMove(Figure figureToCheck, string input)
        {
            // Check if the figure given can move in the direction from the input 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches if the table has cell with coordinates the same as the cell given and 
        /// if the cell with the same coordinates is free.
        /// </summary>
        /// <param name="cell">Cell with coordinates equal to the ones requested by the user</param>
        /// <param name="table">The table containing the cells in which the search is performed</param>
        /// <returns>True if such cell exists and it is free. False in any other case</returns>
        public bool IsCellAvailable(FieldCell cell, Table table)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks the Y position of the king.
        /// </summary>
        /// <param name="king">The king to be checked</param>
        /// <returns>True if the king reached the top of the board. False if it hasn't</returns>
        public bool HasKingWon(King king)
        {
            // Check if king reached the top of the board
            throw new NotImplementedException();
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
        public bool HasKingLost(King king, Table table)
        {
            // Check if king has any valid moves left
            throw new NotImplementedException();
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
        public bool IsValidFigureRequested(int counter, string input, Figure[] figures)
        {
            // Check if it is King's or Pawn's turn with the counter(odd or even) and check if the first letter of the input is correct
            throw new NotImplementedException();
        }
    }
}
