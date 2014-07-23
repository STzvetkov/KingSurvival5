using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored.Interfaces
{
    public interface IFigure
    {
        ICell ContainingCell { get; set;}
        char DrawingRepresentation { get; set; }
        string[] AllowedMoves { get; }
        void ChangePosition(ICell newCell, ITable table);
    }
}
