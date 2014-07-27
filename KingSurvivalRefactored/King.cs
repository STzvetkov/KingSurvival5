namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.Interfaces;

    public class King : Figure
    {
        private readonly string[] DirectionsAvailable = { "DL", "DR", "UL", "UR" };

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
