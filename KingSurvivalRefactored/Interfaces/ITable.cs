using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored.Interfaces
{
    public interface ITable
    {
        ICell[,] Cells { get; }
        IFrame Frame { get; }
    }
}
