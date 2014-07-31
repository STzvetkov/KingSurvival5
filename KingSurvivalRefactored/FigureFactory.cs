namespace KingSurvivalRefactored
{
    using System;
    using KingSurvivalRefactored.Interfaces;

    public class FigureFactory : IFigureFactory
    {
        private const int MaxNumberOfPawns = 10;
        private const int MinNumberOfPawns = 2;

        private IFigure[] allFigures;
        private int pawnCount; // The number of the pawns can be calculated automaticaly based on the size of the Board. But for now it is passed as parameter.
        private ITable table;

        public FigureFactory(ITable table, int pawnCount)
        {
            this.Table = table;
            this.PawnCount = pawnCount;
            this.AllFigures = new IFigure[this.PawnCount + 1];
        }

        public int PawnCount
        {
            get
            {
                return this.pawnCount;
            }

            set
            {
                if (value < MinNumberOfPawns || value > MaxNumberOfPawns)
                {
                    throw new ArgumentOutOfRangeException("The number of pawns must be between 2 and 10");
                }

                this.pawnCount = value;
            }
        }

        private ITable Table
        {
            set
            {
                this.table = value;
            }
        }

        private IFigure[] AllFigures
        {
            get
            {
                return this.allFigures;
            }

            set
            {
                this.allFigures = value;
            }
        }

        public IFigure[] GenerateFigures()
        {
            int kingInitRow = this.table.Cells.GetLength(0) - 1; // This gets the end of the playfield
            int kingInitCol = (this.table.Cells.GetLength(1) / 2) - 1; // This gets the center of the columns
            ICell kingInitialPosition = this.table.Cells[kingInitRow, kingInitCol];

            int firstLetter = 65;

            King theKing = new King(kingInitialPosition, 'K');
            this.AllFigures[0] = theKing;

            for (int i = 1; i < this.AllFigures.Length; i++)
            {
                ICell currentPawnPosition = this.table.Cells[0, (i - 1) * 2];
                Pawn currentPawn = new Pawn(currentPawnPosition, (char)firstLetter);
                this.allFigures[i] = currentPawn;
                firstLetter++;
            }

            return this.AllFigures;
        }
    }
}
