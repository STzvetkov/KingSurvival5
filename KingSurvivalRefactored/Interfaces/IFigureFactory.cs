namespace KingSurvivalRefactored.Interfaces
{
    public interface IFigureFactory
    {
        int PawnCount
        {
            set;
        }

        IFigure[] GenerateFigures();
    }
}
