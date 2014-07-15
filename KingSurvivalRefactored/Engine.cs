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

                if (!(Checker.Instance.IsValidFigureRequested(moveCounter,input, this.figures)))
                {
                    // Invalid Figure(first letter). Ask the user for new input
                }

                currentFigure = ExtractRequestedFigure(input, this.figures);
                if (!(Checker.Instance.IsValidMove(currentFigure, input)))
                {
                    // Invalid Move. Ask the user for new input
                }

                FieldCell requestedCell = ExtractRequestedPosition(input, currentFigure);
                if (!(Checker.Instance.IsCellAvailable(requestedCell, this.table)))
                {
                    // Cell not free. Ask the user for new input
                }

                MoveFigure(currentFigure, requestedCell);
                if (Checker.Instance.HasKingWon(this.figures[0] as King))
                {
                    // king won message
                    break;
                }

                if (Checker.Instance.HasKingLost(this.figures[0] as King, this.table))
                {
                    //king lost message 
                    break;
                }

                moveCounter++;
            }
        }

        /// <summary>
        /// Extracts the first letter of the input and finds the figure with the same drawing representation
        /// </summary>
        /// <param name="input">The user move input</param>
        /// <param name="figures">The figures from which the requested figure will be found</param>
        /// <returns>The figure with the requested drawin representation</returns>
        private Figure ExtractRequestedFigure(string input, Figure[] figures)
        {
            // Get the first letter of the input and find the figure with the same drawingRepresentation from the figures array
            // Ask user for new input 
            throw new NotImplementedException();
        }

        // TODO: To be moved to a Factory class
        /// <summary>
        /// Creates an instance of Frame class and an array of FieldCell class instances.
        /// Using them as parameters creates a Table instance.
        /// </summary>
        /// <returns>The table created</returns>
        private Table CreateTable() 
        {
            // Create the frame and the cells
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an array of Figure class instances.
        /// </summary>
        /// <param name="table">Used to give the Figure instances cells from the table where they will be positioned.</param>
        /// <returns>The figures created with cells from the table assigned to them</returns>
        private Figure[] CreateFigures(Table table)
        {
            // The table is needed to get the cells where we are going to put the figures
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asks the user to enter his next move, saves it to a string variable and returns it.
        /// </summary>
        /// <returns>The user move input</returns>
        private string ReadMoveInput() 
        {
            // Ask the user to enter the next move, save it to a string variable and return it
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts the last two letters of the user input. 
        /// Calculates the coordinates of the cell requested with the input according to the currentFigure.
        /// Creates a new cell with the requested coordinates
        /// </summary>
        /// <param name="input">The user move input</param>
        /// <param name="currentFigure">The figure that the user wants to move</param>
        /// <returns>Cell with coordinates equal to the ones requested by the user</returns>
        private FieldCell ExtractRequestedPosition(string input, Figure currentFigure)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the image of the figure in the current cell and draws it to the new cell.
        /// Changes the position of the requested figure to the new requested cell
        /// </summary>
        /// <param name="figureToMove">The figure to be moved</param>
        /// <param name="newCell">The new cell where the figure will be positioned</param>
        private void MoveFigure(Figure figureToMove, FieldCell newCell)
        {
            Renderer.ChangeImagePosition(figureToMove, newCell);
            figureToMove.ChangePosition(newCell);
        }
    }
}
