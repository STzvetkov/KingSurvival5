using System;
using System.Linq;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored
{
    public class Engine
    {
        private const int DistanceBetweenCellsX = 1;
        private const int DistanceBetweenCellsY = 0;
        private const int ConsoleInitialPositionX = 4;
        private const int ConsoleInitialPositionY = 3;
        private const string FrameSourceFile = "../../test.txt";
        private const byte BoardSize = 8;
        private const char FieldRepresentation = ' ';
        private const ConsoleColor FirstFieldColor = ConsoleColor.Green;
        private const ConsoleColor SecondFieldColor = ConsoleColor.Blue;
                        
        private int moveCounter;
        private Table table;
        private IFigure[] figures;
        private IFigure currentFigure;
        private ConsoleRenderer rendrer;
        public Engine()
        {
            this.moveCounter = 0;
            this.rendrer = new ConsoleRenderer(DistanceBetweenCellsX, DistanceBetweenCellsY, ConsoleInitialPositionX, ConsoleInitialPositionY);
        }

        public void Start()
        {
            this.table = CreateTable();
            this.figures = CreateFigures(this.table, 4);
            this.rendrer.DrawTable(this.table);
            bool validInput = false;

            while (true)
            {
                if (validInput)
                {
                    ClearConsoleLines(this.table.Frame.Height + 1, 3);
                }
                else
                {
                    ClearConsoleLines(this.table.Frame.Height + 2, 3);
                }
                string input = ReadMoveInput(this.moveCounter);
                Console.SetCursorPosition(0, this.table.Frame.Height + 1);

                if (!(Checker.Instance.IsValidFigureRequested(this.moveCounter, input, this.figures)))
                {
                    // Invalid Figure(first letter). Ask the user for new input
                    Console.WriteLine("Invalid Figure (the first letter).");
                    continue;
                }

                currentFigure = ExtractRequestedFigure(input, this.figures);
                if (!(Checker.Instance.IsValidMove(currentFigure, input)))
                {
                    // Invalid Move. Ask the user for new input
                    Console.WriteLine("Invalid move.");
                    continue;
                }

                FieldCell requestedCell = ExtractRequestedPosition(input, currentFigure);
                if (!(Checker.Instance.IsCellAvailable(requestedCell, this.table)))
                {
                    // Cell not free. Ask the user for new input
                    Console.WriteLine("The chosen cell is not free.");
                    continue;
                }

                validInput = true;
                MoveFigure(currentFigure, requestedCell);
                if (Checker.Instance.HasKingWon(this.figures[0] as King))
                {
                    // king won message
                    Console.WriteLine("King wins!");
                    break;
                }

                if (Checker.Instance.HasKingLost(this.figures[0] as King, this.table))
                {
                    //king lost message 
                    Console.WriteLine("King lost!");
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
        private IFigure ExtractRequestedFigure(string input, IFigure[] figures)
        {
            // Get the first letter of the input and find the figure with the same drawingRepresentation from the figures array
            char figureDrawingRepresentation = input[0];

            // Figure requested = figures[0];
            IFigure requested = null;


            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i].DrawingRepresentation == figureDrawingRepresentation)
                {
                    requested = figures[i];
                    break;
                }
            }

            if (requested == null)
            {
                throw new ArgumentNullException("requested", "Invalid figure requested.");
            }

            return requested;
        }

        // TODO: To be moved to a Factory class
        /// <summary>
        /// Creates an instance of Frame class and an array of FieldCell class instances.
        /// Using them as parameters creates a Table instance.
        /// </summary>
        /// <returns>The table created</returns>
        private Table CreateTable()
        {
            FieldCellFactory cellCreator = new FieldCellFactory(BoardSize, BoardSize,
                FieldRepresentation, FirstFieldColor, SecondFieldColor);
            return new Table(cellCreator, new Frame(FrameSourceFile));
        }

        /// <summary>
        /// Creates an array of Figure class instances.
        /// </summary>
        /// <param name="table">Used to give the Figure instances cells from the table where they will be positioned.</param>
        /// <returns>The figures created with cells from the table assigned to them</returns>
        private IFigure[] CreateFigures(Table table, int pawnsCount)
        {
            int kingInitRow = table.Cells.GetLength(0) - 1; // This gets the end of the playfield
            int kingInitCol = table.Cells.GetLength(1) / 2 - 1; // This gets the center of the columns
            ICell kingInitialPosition = table.Cells[kingInitRow, kingInitCol];

            IFigure[] allFigures = new Figure[pawnsCount + 1];
            int firstLetter = 65;

            King theKing = new King(kingInitialPosition, 'K');
            allFigures[0] = theKing;

            for (int i = 1; i < allFigures.Length; i++)
            {
                ICell currentPawnPosition = table.Cells[0, (i - 1) * 2];
                Pawn currentPawn = new Pawn(currentPawnPosition, (char)firstLetter);
                allFigures[i] = currentPawn;
                firstLetter++;
            }

            return allFigures;
        }

        /// <summary>
        /// Asks the user to enter his next move, saves it to a string variable and returns it.
        /// </summary>
        /// <returns>The user move input</returns>
        private string ReadMoveInput(int moveCounter)
        {
            // Ask the user to enter the next move, save it to a string variable and return it
            if (moveCounter % 2 != 0)
            {
                // It's King's turn
                Console.WriteLine("Please enter king's turn: ");
            }
            else
            {
                // It's pawn's turn
                Console.WriteLine("Please enter pawn's turn: ");
            }

            string input = Console.ReadLine();
            return input.Trim().ToUpper();
        }

        private void ClearConsoleLines(int startingLine, int linesCount)
        {
            Console.SetCursorPosition(0, startingLine);
            for (int i = 0; i < linesCount; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.Write(' ');
                }
            }
            Console.SetCursorPosition(0, startingLine);
        }

        /// <summary>
        /// Extracts the last two letters of the user input. 
        /// Calculates the coordinates of the cell requested with the input according to the currentFigure.
        /// Creates a new cell with the requested coordinates
        /// </summary>
        /// <param name="input">The user move input</param>
        /// <param name="currentFigure">The figure that the user wants to move</param>
        /// <returns>Cell with coordinates equal to the ones requested by the user</returns>
        private FieldCell ExtractRequestedPosition(string input, IFigure currentFigure)
        {
            char directionX = input[input.Length - 1];
            char directionY = input[input.Length - 2];
            int newCellCoordinateX = currentFigure.ContainingCell.Col;
            int newCellCoordinateY = currentFigure.ContainingCell.Row;

            if (directionX == 'L')
            {
                newCellCoordinateX++;
            }

            if (directionX == 'R')
            {
                newCellCoordinateX--;
            }

            if (directionY == 'U')
            {
                newCellCoordinateY--;
            }

            if (directionY == 'D')
            {
                newCellCoordinateY++;
            }

            return new FieldCell(newCellCoordinateX, newCellCoordinateY, currentFigure.ContainingCell.Value,
                                 currentFigure.ContainingCell.Color);
        }

        /// <summary>
        /// Removes the image of the figure in the current cell and draws it to the new cell.
        /// Changes the position of the requested figure to the new requested cell
        /// </summary>
        /// <param name="figureToMove">The figure to be moved</param>
        /// <param name="newCell">The new cell where the figure will be positioned</param>
        private void MoveFigure(IFigure figureToMove, FieldCell newCell)
        {
            this.rendrer.ChangeImagePosition(figureToMove, newCell);
            figureToMove.ChangePosition(newCell);
        }
    }
}
