using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvivalRefactored.tests
{
    [TestClass]
    public class EngineShould
    {
        [TestMethod]
        public void TestExtractRequestedFigureWithValidInput()
        {
            Pawn pawnA = new Pawn(new FieldCell(1, 1, ' ', ConsoleColor.Red), 'A');
            Pawn pawnB = new Pawn(new FieldCell(2, 2, ' ', ConsoleColor.Black), 'B');
            King king = new King(new FieldCell(3, 3, ' ', ConsoleColor.Cyan), 'C');
            Figure[] figures = new Figure[3] { pawnA, pawnB, king };
            string input = "ADR";
            PrivateObject prv = new PrivateObject(typeof(Engine));
            var result = prv.Invoke("ExtractRequestedFigure", input, figures);
            Assert.AreEqual(pawnA, result, "ExtractRequestedFigure with valid input should extract the figure with the same drawing representation");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExtractRequestedFigureWithInvalidInput()
        {
            Pawn pawnA = new Pawn(new FieldCell(1, 1, ' ', ConsoleColor.Red), 'A');
            Pawn pawnB = new Pawn(new FieldCell(2, 2, ' ', ConsoleColor.Black), 'B');
            King king = new King(new FieldCell(3, 3, ' ', ConsoleColor.Cyan), 'C');
            Figure[] figures = new Figure[3] { pawnA, pawnB, king };
            string input = "ZDR";
            PrivateObject prv = new PrivateObject(typeof(Engine));
            prv.Invoke("ExtractRequestedFigure", input, figures);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExtractRequestedFigureWithNullFiguresParameter()
        {
            string input = "ZDR";
            PrivateObject prv = new PrivateObject(typeof(Engine));
            prv.Invoke("ExtractRequestedFigure", input, null);
        }
    }
}
