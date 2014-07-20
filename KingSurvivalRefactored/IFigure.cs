using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    public interface IFigure
    {
        FieldCell ContainingCell { get; set;}
        char DrawingRepresentation { get; set; }
        string[] AllowedMoves { get; }
        void ChangePosition(FieldCell newCell);
    }
}
