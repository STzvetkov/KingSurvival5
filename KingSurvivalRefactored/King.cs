using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored
{
    public class King : Figure
    {
        private readonly string[] DirectionsAvailable = { "dl", "dr", "ul", "ur" };
        public King(ICell position, char drawingRepresentation) : 
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
