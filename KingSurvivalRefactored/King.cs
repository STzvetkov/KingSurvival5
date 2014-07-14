using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalRefactored
{
    public class King : Figure
    {
        private readonly string[] DirectionsAvailable = { "dl", "dr", "ul", "ur" };
        public King(FieldCell position, char drawingRepresentation) : 
            base(position, drawingRepresentation)
        {
        }

        public override string[] AllowedMoves
        {
            get
            {
                return this.DirectionsAvailable;
            }
        }
    }
}
