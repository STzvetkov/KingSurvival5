using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace KingSurvivalRefactored.Interfaces
{
    public interface ITable: IEnumerable
    {
        ICell[,] Cells { get; }
        IFrame Frame { get; }
    }
}
