namespace KingSurvivalRefactored.Interfaces
{
    public interface IFigureFactory
    {
        IFigure[] GenerateFigures();

        int PawnCount
        {
            set;
        }
    }
}
