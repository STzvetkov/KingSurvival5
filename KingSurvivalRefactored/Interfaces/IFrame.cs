using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored.Interfaces
{
    public interface IFrame
    {
        string Image { get; }
        int Width { get; }
        int Height { get; } 
    }
}
