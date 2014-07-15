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
            Table testTable = new Table(testFactory, new Frame("test.txt"));
            Console.WriteLine(testTable.TableFrame.Image);
                foreach (FieldCell cell in testTable)
                {
                    Console.WriteLine(cell.CoordinateX + " " 
                        + cell.CoordinateY + " "
                        + cell.Value + " "
                        + cell.Color + " ");
                }
        }
    }
}
