using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    class Program
    {
        static void Main(string[] args)
        {
            FieldCellFactory testFactory=new FieldCellFactory(8,8,'&',ConsoleColor.Blue,ConsoleColor.Red);
            for (int i = 0; i < 64; i++)
            {
                FieldCell testCell = testFactory.GenerateNextCell();
                Console.WriteLine(testCell.CoordinateX + " " +
                    testCell.CoordinateY + " " +
                    testCell.Value + " " +
                    testCell.Color+ " ");
            }
        }
    }
}
