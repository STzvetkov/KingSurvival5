using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvivalRefactored.tests
{
    [TestClass]
    public class EngineShould
    {
        Engine engine;
        Figure[] figures;
        Figure pawnA;
        Figure pawnB;
        Figure king;
        [ClassInitialize]
        public void ClassInitialize() 
        {
            
            this.engine = new Engine();
            this.pawnA = new Pawn(new FieldCell(1, 1, ' ', ConsoleColor.Red), 'A');
            this.pawnB = new Pawn(new FieldCell(2,2, ' ', ConsoleColor.Black), 'B');
            this.king = new King(new FieldCell(3, 3, ' ', ConsoleColor.Cyan), 'C');
            this.figures = new Figure[3]{pawnA,pawnB,king};

        }

        [TestMethod]
        public void TestExtractRequestedFigure()
        {
            string input = "ADR";
            
        }
    }
}
