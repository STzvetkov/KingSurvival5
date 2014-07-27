namespace KingSurvivalRefactored.Interfaces
{
    public interface IFieldCellFactory
    {
        FieldCell GenerateNextCell();

        int RowCount
        {
            get;
        }

        int ColCount
        {
            get;
        }
    }
}
