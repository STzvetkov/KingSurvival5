﻿using System;
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
        private int pawnCount; // The number of the pawns can be calculated automaticaly based on the size of the Board. But for now it is passed as parameter.
        private Table table;
        

        public FigureFactory(Table table, int pawnCount) {
            this.Table = table;
            this.PawnCount = pawnCount;
            this.AllFigures = new IFigure[this.PawnCount + 1];
        }

        public IFigure[] GenerateFigures()
        {
            int kingInitRow = table.Cells.GetLength(0) - 1; // This gets the end of the playfield
            int kingInitCol = table.Cells.GetLength(1) / 2 - 1; // This gets the center of the columns
            ICell kingInitialPosition = table.Cells[kingInitRow, kingInitCol];

            int firstLetter = 65;

            King theKing = new King(kingInitialPosition, 'K');
            AllFigures[0] = theKing;

            for (int i = 1; i < AllFigures.Length; i++)
            {
                ICell currentPawnPosition = table.Cells[0, (i - 1) * 2];
                Pawn currentPawn = new Pawn(currentPawnPosition, (char)firstLetter);
                allFigures[i] = currentPawn;
                firstLetter++;
            }

            return AllFigures;
        }

        public int PawnCount
        {
            get { return this.pawnCount; }
            set
            {
                if (value < 2 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("The number of pawns must be between 2 and 10");
                }
                this.pawnCount = value;
            }
        }

        private Table Table
        {
            set 
            {
                this.table = value;
            }
        }

        private IFigure[] AllFigures 
        {
            set 
            {
                this.allFigures = value;
            }
            get
            {
                return this.allFigures;
            }
        }
    }
}