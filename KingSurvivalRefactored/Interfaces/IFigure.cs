namespace KingSurvivalRefactored.Interfaces
{
    public interface IFigure
    {
        ICell ContainingCell { get; set; }

        char DrawingRepresentation { get; set; }

        string[] AllowedMoves { get; }

        void ChangePosition(ICell newCell, ITable table);
    }
}
