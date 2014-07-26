using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored
{
    public class FigureFactory:IFigureFactory
    {
        private IFigure[] allFigures;
        private int pawnCount;
        private Table table;
        

        public FigureFactory(Table table, int pawnCount) {
            this.Table = table;
            this.PawnCount = pawnCount;
            this.allFigures = new IFigure[this.PawnCount + 1];
        }

        public IFigure[] GenerateFigures()
        {
            int kingInitRow = table.Cells.GetLength(0) - 1; // This gets the end of the playfield
            int kingInitCol = table.Cells.GetLength(1) / 2 - 1; // This gets the center of the columns
            ICell kingInitialPosition = table.Cells[kingInitRow, kingInitCol];

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

        public int PawnCount
        {
            get { return this.pawnCount; }
            set { this.pawnCount = value; }
        }

        Table Table
        {
            set 
            {
                this.table = value;
            }
        }
    }
}
