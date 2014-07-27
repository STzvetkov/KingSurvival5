using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored.Interfaces
{
    public interface IRenderer
    {
        void DrawTable(ITable tableToDraw);
        
        void ChangeImagePosition(IFigure figureToMove, ICell newCell);
    }
}
