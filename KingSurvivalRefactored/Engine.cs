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
                    ClearConsoleLines(Console.CursorTop, 1);
                    Console.WriteLine("Invalid Figure (the first letter).");
                    validInput = false;
                    continue;
                }

                currentFigure = ExtractRequestedFigure(input, this.figures);
                if (!(Checker.Instance.IsValidMove(currentFigure, input)))
                {
                    // Invalid Move. Ask the user for new input
                    ClearConsoleLines(Console.CursorTop, 1);
                    Console.WriteLine("Invalid move.");
                    validInput = false;
                    continue;
                }

                int requestedCoordinateX = ExtractRequestedCoordinateX(input, currentFigure);
                int requestedCoordinateY = ExtractRequestedCoordinateY(input, currentFigure);
                ICell requestedCell;

                if (!(Checker.Instance.IsRequestedPositionInsideTable(requestedCoordinateX, requestedCoordinateY, table)))
                {
                    ClearConsoleLines(Console.CursorTop, 1);
                    Console.WriteLine("There is no cell in the chosen direction.");
                    validInput = false;
                    continue;
                }

                else
                {
                    requestedCell = table.Cells[requestedCoordinateY, requestedCoordinateX];
                    if (!requestedCell.IsFree)
                    {
                        ClearConsoleLines(Console.CursorTop, 1);
                        Console.WriteLine("The chosen cell is not free.");
                        validInput = false;
                        continue;
                    }
                }

                validInput = true;
                MoveFigure(currentFigure, requestedCell);
                Console.SetCursorPosition(0, this.table.Frame.Height + 1);
                if (Checker.Instance.HasKingWon(this.figures[0] as King))
                {
                    // king won message
                    ClearConsoleLines(Console.CursorTop, 1);
                    Console.WriteLine("King wins!");
                    break;
                }

                if (Checker.Instance.HasKingLost(this.figures[0] as King, this.table))
                {
                    //king lost message 
                    ClearConsoleLines(Console.CursorTop, 1);
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
            IFigureFactory figureCreator = new FigureFactory(table, pawnsCount);
            return figureCreator.GenerateFigures();
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

        private int ExtractRequestedCoordinateX(string input, IFigure currentFigure)
        {
            if (input[2] == 'L')
            {
                return currentFigure.ContainingCell.Col - 1;
            }
            else if (input[2] == 'R')
            {
                return currentFigure.ContainingCell.Col + 1;
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }
        }

        private int ExtractRequestedCoordinateY(string input, IFigure currentFigure)
        {
            if (input[1] == 'U')
            {
                return currentFigure.ContainingCell.Row - 1;
            }
            else if (input[1] == 'D')
            {
                return currentFigure.ContainingCell.Row + 1;
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }
        }

        /// <summary>
        /// Removes the image of the figure in the current cell and draws it to the new cell.
        /// Changes the position of the requested figure to the new requested cell
        /// </summary>
        /// <param name="figureToMove">The figure to be moved</param>
        /// <param name="newCell">The new cell where the figure will be positioned</param>
        private void MoveFigure(IFigure figureToMove, ICell newCell)
        {
            this.rendrer.ChangeImagePosition(figureToMove, newCell);
            figureToMove.ChangePosition(newCell, this.table);
        }
    }
}
