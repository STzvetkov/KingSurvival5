namespace KingSurvivalRefactored.Interfaces
{
    public interface IFieldCellFactory
    {
        int RowCount { get; }

        int ColCount { get; }

        FieldCell GenerateNextCell();
    }
}
