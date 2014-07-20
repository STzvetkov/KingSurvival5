using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    public interface IWeiter
    {
        ConsoleColor BackgroundColor { set; }
        void SetCursorPosition(int x, int y);
        void Write(char input);
        void Write(string input);
        void WriteLine(char input);
        void WriteLine(string input);
        void ResetColor();

    }
}
