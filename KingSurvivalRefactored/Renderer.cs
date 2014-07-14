using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    public static class Renderer
    {
        private const char EmptyCell = ' ';
        public static void DrawTable(Table tableToDraw)
        {
            Console.WriteLine(tableToDraw.TableFrame.Image);
            foreach (var cell in tableToDraw)
            {
                // once the IEnumerable methods in Table are implemented this will not throw an exception
                //DrawCell(cell);
            }
        }

        private static void DrawCell(FieldCell cellToDraw)
        {
            Console.SetCursorPosition(cellToDraw.CoordinateX, cellToDraw.CoordinateY);
            Console.BackgroundColor = cellToDraw.Color;
            Console.Write(cellToDraw.Value);
            Console.ResetColor();
        }

        public static void ChangeImagePosition(Figure figureToMove, FieldCell newCell)
        {
            Console.SetCursorPosition(figureToMove.ContainingCell.CoordinateX, figureToMove.ContainingCell.CoordinateY);
            Console.BackgroundColor = figureToMove.ContainingCell.Color;
            Console.Write(EmptyCell);
            Console.SetCursorPosition(newCell.CoordinateX, newCell.CoordinateY);
            Console.BackgroundColor = newCell.Color;
            Console.Write(newCell.Value);
        }
    }
}
