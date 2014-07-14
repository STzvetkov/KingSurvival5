using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    class Checker // To be made Singleton
    {
        public static Checker Instance
        {
            get
            {
                return new Checker();
            }
        }
        public bool IsValidMove(Figure figureToCheck, string input)
        {
            // Check if the figure given can move in the direction from the input 
            throw new NotImplementedException();
        }
        public bool IsCellAvailable(FieldCell cell)
        {
            if (cell.Value == ' ')
            {
                return true;
            }
            return false;
        }

        public bool HasKingWon(King king)
        {
            // Check if king reached the top of the board
            throw new NotImplementedException();
        }

        public bool HasKingLost(Figure[] figures)
        {
            // Check if king has any valid moves left
            throw new NotImplementedException();
        }

        public bool IsValidFigureRequested(int counter, string input)
        {
            // Check if it is King's or Pawn's turn with the counter(odd or even) and check if the first letter of the input is correct
            throw new NotImplementedException();
        }
    }
}
