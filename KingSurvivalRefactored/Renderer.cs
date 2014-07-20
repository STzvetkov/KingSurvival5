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
                DrawCell(cell);
            }
        }

        /// <summary>
        /// Draws the cell to the console using the coordinates, the color and the value of the cell
        /// </summary>
        /// <param name="cellToDraw">The cell to be drawn</param>
        private static void DrawCell(FieldCell cellToDraw)
        {
            int drawContentX = Engine.TableBaseX + cellToDraw.Col * Engine.CellWidth + Engine.CellWidth/2;
            int drawContentY = Engine.TableBaseY + cellToDraw.Row * Engine.CellHeight + Engine.CellHeight/2;
            Console.SetCursorPosition(drawContentY, drawContentX);
            Console.BackgroundColor = cellToDraw.Color;
            Console.Write(cellToDraw.Value);
            Console.ResetColor();
        }

        /// <summary>
        /// Changes the image of the cell in which the figure is positioned to ' '(empty cell)
        /// and then changes the image of the new cell to the drawing representation of the figure
        /// </summary>
        /// <param name="figureToMove">The figure which image will be moved</param>
        /// <param name="newCell">The cell where the image of the figure will be moved</param>
        public static void ChangeImagePosition(Figure figureToMove, FieldCell newCell)
        {
            Console.SetCursorPosition(figureToMove.ContainingCell.Col, figureToMove.ContainingCell.Row);
            Console.BackgroundColor = figureToMove.ContainingCell.Color;
            Console.Write(EmptyCell);
            Console.SetCursorPosition(newCell.Col, newCell.Row);
            Console.BackgroundColor = newCell.Color;
            Console.Write(figureToMove.DrawingRepresentation);
        }
    }
}
