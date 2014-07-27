namespace KingSurvivalRefactored.Interfaces
{
    public interface IRenderer
    {
        void DrawTable(ITable tableToDraw);
        
        void ChangeImagePosition(IFigure figureToMove, ICell newCell);
    }
}
