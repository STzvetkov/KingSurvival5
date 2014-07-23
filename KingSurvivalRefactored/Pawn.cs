using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored
{
    public class Pawn : Figure
    {
        private readonly string[] DirectionsAvailable = { "DL", "DR" };
        public Pawn(ICell position, char drawingRepresentation) :
            base(position, drawingRepresentation)
        {
        }

        public override string[] AllowedMoves
        {
            get { return this.DirectionsAvailable; }
        }
    }
}
