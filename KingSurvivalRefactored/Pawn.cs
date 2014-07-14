using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalRefactored
{
    public class Pawn : Figure
    {
        private readonly string[] DirectionsAvailable = { "dl", "dr" };
        public Pawn(FieldCell position, char drawingRepresentation) :
            base(position, drawingRepresentation)
        {
        }

        public override string[] AllowedMoves
        {
            get { return this.DirectionsAvailable; }
        }
    }
}
