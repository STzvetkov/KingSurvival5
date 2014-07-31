namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.Interfaces;

    public class Pawn : Figure
    {
        private readonly string[] DirectionsAvailable = { "DL", "DR" };

        public Pawn(ICell position, char drawingRepresentation)
            : base(position, drawingRepresentation)
        {
        }

        public override string[] AllowedMoves
        {
            get { return DirectionsAvailable; }
        }
    }
}
