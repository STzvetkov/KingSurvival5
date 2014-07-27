namespace KingSurvivalRefactored.Interfaces
{
    using System;

    public interface IWriter
    {
        ConsoleColor BackgroundColor { set; }

        ConsoleColor ForegroundColor { set; }

        void SetCursorPosition(int x, int y);

        void Write(char input);

        void Write(string input);

        void WriteLine(char input);

        void WriteLine(string input);

        void ResetColor();

    }
}
