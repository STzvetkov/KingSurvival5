using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored.Interfaces
{
    public interface ICell
    {
        int Row { get; }
        int Col { get; }
        char Value { get; set; }
        ConsoleColor Color { get; }
        bool IsFree { get; }
    }
}
