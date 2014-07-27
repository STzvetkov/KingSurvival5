namespace KingSurvivalRefactored
{
    using System;
    using KingSurvivalRefactored.Interfaces;

    /// <summary>
    /// A class used to perform the drawing on the console
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        private const char EmptyCell = ' ';
        private IWriter outputWriter;

        private int distanceBetweenCellsX;
        private int distanceBetweenCellsY;

        private int consoleInitialPositionX;
        private int consoleInitialPositionY;

        public ConsoleRenderer(int distanceBetweenCellsX, int distanceBetweenCellsY,
            int consoleInitialPositionX, int consoleInitialPositionY)
        {
            this.OutputWriter = new ConsoleWriter();
            this.InitializeDistanceValues(distanceBetweenCellsX, distanceBetweenCellsY,
             consoleInitialPositionX, consoleInitialPositionY);
        }

        public ConsoleRenderer(int distanceBetweenCellsX, int distanceBetweenCellsY,
            int consoleInitialPositionX, int consoleInitialPositionY, IWriter outputWriter)
        {
            this.OutputWriter = outputWriter;
            this.InitializeDistanceValues(distanceBetweenCellsX, distanceBetweenCellsY,
             consoleInitialPositionX, consoleInitialPositionY);
        }

        public int DistanceBetweenCellsX
        {
            get
            {
                return this.distanceBetweenCellsX;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Distance betwen cells cannot be negative");
                }

                this.distanceBetweenCellsX = value;
            }
        }

        public int DistanceBetweenCellsY
        {
            get
            {
                return this.distanceBetweenCellsY;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Distance betwen cells cannot be negative");
                }

                this.distanceBetweenCellsY = value;
            }
        }

        public int ConsoleInitialPositionX
        {
            get
            {
                return this.consoleInitialPositionX;
            }

            private set
            {
                if (value < 0 || value > this.outputWriter.LargestWindowWidth)
                {
                    throw new ArgumentOutOfRangeException("ConsoleInitialPositionX cannot be less than 0 or more than " 
                        + Console.LargestWindowWidth);
                }

                this.consoleInitialPositionX = value;
            }
        }

        public int ConsoleInitialPositionY
        {
            get
            {
                return this.consoleInitialPositionY;
            }

            private set
            {
                if (value < 0 || value > Console.LargestWindowHeight)
                {
                    throw new ArgumentOutOfRangeException("ConsoleInitialPositionX cannot be less than 0 or more than " +
                        Console.LargestWindowHeight);
                }

                this.consoleInitialPositionY = value;
            }
        }

        public IWriter OutputWriter
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The writer cat be set to null.");
                }

                this.outputWriter = value;
            }
        }

        /// <summary>
        /// Draws the frame of the table to the console and then draws each cell.
        /// </summary>
        /// <param name="tableToDraw">The table to be drawn</param>
        public void DrawTable(ITable tableToDraw)
        {
            this.outputWriter.WriteLine(tableToDraw.Frame.Image);
            foreach (ICell cell in tableToDraw)
            {
                this.DrawCell(cell as ICell);
            }
        }

        /// <summary>
        /// Changes the image of the cell in which the figure is positioned to ' '(empty cell)
        /// and then changes the image of the new cell to the drawing representation of the figure
        /// </summary>
        /// <param name="figureToMove">The figure which image will be moved</param>
        /// <param name="newCell">The cell where the image of the figure will be moved</param>
        public void ChangeImagePosition(IFigure figureToMove, ICell newCell)
        {
            int oldAbsoluteX = this.CalculateAbsolutePositionX(figureToMove.ContainingCell);
            int oldAbsoluteY = this.CalculateAbsolutePositionY(figureToMove.ContainingCell);

            this.outputWriter.SetCursorPosition(oldAbsoluteX, oldAbsoluteY);
            this.outputWriter.BackgroundColor = figureToMove.ContainingCell.Color;
            this.outputWriter.Write(EmptyCell);

            int newAbsoluteX = this.CalculateAbsolutePositionX(newCell);
            int newAbsoluteY = this.CalculateAbsolutePositionY(newCell);

            this.outputWriter.SetCursorPosition(newAbsoluteX, newAbsoluteY);
            this.outputWriter.BackgroundColor = newCell.Color;
            this.outputWriter.ForegroundColor = ConsoleColor.Black;
            this.outputWriter.Write(figureToMove.DrawingRepresentation);
            this.outputWriter.ResetColor();
        }

        private void InitializeDistanceValues(int distanceBetweenCellsX, int distanceBetweenCellsY,
            int consoleInitialPositionX, int consoleInitialPositionY)
        {
            this.DistanceBetweenCellsX = distanceBetweenCellsX;
            this.DistanceBetweenCellsY = distanceBetweenCellsY;
            this.ConsoleInitialPositionX = consoleInitialPositionX;
            this.ConsoleInitialPositionY = consoleInitialPositionY;
        }

        /// <summary>
        /// Draws the cell to the console using the coordinates, the color and the value of the cell
        /// </summary>
        /// <param name="cellToDraw">The cell to be drawn</param>
        private void DrawCell(ICell cellToDraw)
        {
            int drawPositionX = this.CalculateAbsolutePositionX(cellToDraw);
            int drawPositionY = this.CalculateAbsolutePositionY(cellToDraw);

            this.outputWriter.SetCursorPosition(drawPositionX, drawPositionY);

            if (cellToDraw.IsFree)
            {
                this.outputWriter.ForegroundColor = cellToDraw.Color;
            }
            else
            {
                this.outputWriter.ForegroundColor = ConsoleColor.Black;
            }

            this.outputWriter.BackgroundColor = cellToDraw.Color;
            this.outputWriter.Write(cellToDraw.Value);
            this.outputWriter.ResetColor();
        }

        private int CalculateAbsolutePositionX(ICell cell)
        {
            return this.ConsoleInitialPositionX + (cell.Col * (this.DistanceBetweenCellsX + 1));
        }

        private int CalculateAbsolutePositionY(ICell cell)
        {
            return this.ConsoleInitialPositionY + (cell.Row * (this.DistanceBetweenCellsY + 1));
        }
    }
}
