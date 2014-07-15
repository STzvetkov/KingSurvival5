using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
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
