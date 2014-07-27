namespace KingSurvivalRefactored.Interfaces
{
    using System;

    public interface ICell
    {
        int Row { get; }

        int Col { get; }

        char Value { get; set; }

        ConsoleColor Color { get; }

        bool IsFree { get; }
    }
}
