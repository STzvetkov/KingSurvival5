using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    public class Engine
    {
        private int moveCounter;
        private Table table;
        private Figure[] figures;
        private Figure currentFigure;

        public Engine()
        {
            this.moveCounter = 0;
        }
        public void Start()
        {
            this.table = CreateTable();
            this.figures = CreateFigures(this.table);
            Renderer.DrawTable(this.table);

            while (true)
            {
                string input = ReadMoveInput();

                if (!(Checker.Instance.IsValidFigureRequested(moveCounter,input)))
                {
                    // Invalid Figure(first letter). Ask the user for new input
                }

                currentFigure = ExtractRequestedFigure(input);
                if (!(Checker.Instance.IsValidMove(currentFigure, input)))
                {
                    // Invalid Move. Ask the user for new input
                }

                FieldCell requestedCell = ExtractRequestedPosition(input);
                if (!(Checker.Instance.IsCellAvailable(requestedCell)))
                {
                    // Cell not free. Ask the user for new input
                }

                MoveFigure(currentFigure, requestedCell);
                if (Checker.Instance.HasKingWon(this.figures[0] as King))
                {
                    // king won message
                    break;
                }

                if (Checker.Instance.HasKingLost(this.figures))
                {
                    //king lost message 
                    break;
                }

                moveCounter++;
            }
        }

        private Figure ExtractRequestedFigure(string input)
        {
            // Get the first letter of the input and find the figure with the same drawingRepresentation from the figures array
            // Ask user for new input 
            throw new NotImplementedException();
        }

        private Table CreateTable() 
        {
            // Create the frame and the cells
            throw new NotImplementedException();
        }

        private Figure[] CreateFigures(Table table)
        {
            // The table is needed to get the cells where we are going to put the figures
            throw new NotImplementedException();
        }

        private string ReadMoveInput() 
        {
            // Ask the user to enter the next move, save it to a string variable and return it
            throw new NotImplementedException();
        }

        private FieldCell ExtractRequestedPosition(string input)
        {
            /*
             * After it is checked that the input is a valid move for the figure by Checker.IsValidMove() 
             * we calculate the new cell coordinates according to the input and try to find the cell with the same
             * coordinates in the table. If it is not exising in the table then it's outside of it. Otherwise we return it.
            */ 
            throw new NotImplementedException();
        }

        private void MoveFigure(Figure figureToMove, FieldCell newCell)
        {
            Renderer.ChangeImagePosition(figureToMove, newCell);
            figureToMove.ChangePosition(newCell);
        }
    }
}
