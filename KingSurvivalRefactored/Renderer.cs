using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    /// <summary>
    /// A class used to perform the drawing on the console
    /// </summary>
    public static class Renderer
    {
        private const char EmptyCell = ' ';
        private static IWeiter outputWriter= new ConsoleWriter();
        /// <summary>
        /// Draws the frame of the table to the console and then draws each cell.
        /// </summary>
        /// <param name="tableToDraw">The table to be drawn</param>
        public static void DrawTable(Table tableToDraw)
        {
            Console.WriteLine(tableToDraw.TableFrame.Image);
            foreach (var cell in tableToDraw)
            {
                // once the IEnumerable methods in Table are implemented this will compile
                DrawCell(cell as FieldCell);
            }
        }

        public static IWeiter OutputWriter
        {
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("The writer cat be set to null.");
                }
                outputWriter = value;
            }
        }
        /// <summary>
        /// Draws the cell to the console using the coordinates, the color and the value of the cell
        /// </summary>
        /// <param name="cellToDraw">The cell to be drawn</param>
        private static void DrawCell(FieldCell cellToDraw)
        {
            int drawPositionX = Engine.TableBaseX + cellToDraw.Col * Engine.CellWidth + Engine.CellWidth / 2;
            int drawPositionY = Engine.TableBaseY + cellToDraw.Row * Engine.CellHeight + Engine.CellHeight / 2;
            outputWriter.SetCursorPosition(drawPositionX, drawPositionY);
            if (cellToDraw.IsFree)
            {
                outputWriter.ForegroundColor = cellToDraw.Color;
            }
            else
            {
                outputWriter.ForegroundColor = ConsoleColor.Black;
            }
            outputWriter.BackgroundColor = cellToDraw.Color;
            outputWriter.Write(cellToDraw.Value);
            outputWriter.ResetColor();
        }

        /// <summary>
        /// Changes the image of the cell in which the figure is positioned to ' '(empty cell)
        /// and then changes the image of the new cell to the drawing representation of the figure
        /// </summary>
        /// <param name="figureToMove">The figure which image will be moved</param>
        /// <param name="newCell">The cell where the image of the figure will be moved</param>
        public static void ChangeImagePosition(IFigure figureToMove, FieldCell newCell)
        {
            outputWriter.SetCursorPosition(figureToMove.ContainingCell.Col, figureToMove.ContainingCell.Row);
            outputWriter.BackgroundColor = figureToMove.ContainingCell.Color;
            outputWriter.Write(EmptyCell);
            outputWriter.SetCursorPosition(newCell.Col, newCell.Row);
            outputWriter.BackgroundColor = newCell.Color;
            outputWriter.Write(figureToMove.DrawingRepresentation);
        }
    }
}
