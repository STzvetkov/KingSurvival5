namespace KingSurvivalRefactored.Interfaces
{
    using System.Collections;

    public interface ITable: IEnumerable
    {
        ICell[,] Cells { get; }

        IFrame Frame { get; }
    }
}
