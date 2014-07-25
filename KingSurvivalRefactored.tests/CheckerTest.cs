using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored.tests
{
    [TestClass]
    public class CheckerTest
    {
        [TestMethod]
        public void IsValidMoveForKingShouldReturnTrueForCorrectData()
        {
            IFigure king = new King(new FieldCell(2, 3, 'K', ConsoleColor.Blue), 'K');
            bool isValid = Checker.Instance.IsValidMove(king, "kur");
            Assert.IsTrue(isValid,"KUR should be valid move for king");
        }

        [TestMethod]
        public void IsValidMoveForKingShouldReturnFalseForIvalidDirection()
        {
            IFigure king = new King(new FieldCell(2, 3, 'K', ConsoleColor.Blue), 'K');
            bool isValid = Checker.Instance.IsValidMove(king, "kfr");
            Assert.IsFalse(isValid,"KFR shouldn't be valid move");
        }

        [TestMethod]
        public void HasKingWonShouldReturtTrueWhenTheKingIsOnTheTop()
        {
            IFigure king = new King(new FieldCell(0, 0, 'K', ConsoleColor.Blue), 'K');
            bool hasWon = Checker.Instance.HasKingWon(king as King);
            Assert.IsTrue(hasWon,"If the king is with Y position = 0, it should win");
        }

        [TestMethod]
        public void HasKingWonShouldReturtFalseWhenTheKingIsNotOnTheTop()
        {
            IFigure king = new King(new FieldCell(0, 1, 'K', ConsoleColor.Blue), 'K');
            bool hasWon = Checker.Instance.HasKingWon(king as King);
            Assert.IsFalse(hasWon, "If the king is NOT with Y position = 0, it should NOT win");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenTheCellsAroundTheKingAreFree()
        {
            IFigure king = new King(new FieldCell(8, 3, 'K', ConsoleColor.Blue), 'K');
            Table table = new Table(new FieldCellFactory(9, 9, ' ', ConsoleColor.Red, ConsoleColor.DarkCyan), new Frame("test.txt"));
            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost,"The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithCorrectDataInPawnsTurn()
        {
            IFigure[] figures = new IFigure[]
            {
                new King(new FieldCell(8, 1, 'K', ConsoleColor.Yellow), 'K'),
                new Pawn(new FieldCell(8, 3, 'A', ConsoleColor.Blue), 'A'),
                new Pawn(new FieldCell(8, 6, 'B', ConsoleColor.Blue), 'B'),
                new Pawn(new FieldCell(8, 1, 'C', ConsoleColor.Blue), 'C')
            };

            bool isValid = Checker.Instance.IsValidFigureRequested(2, "cdl", figures);
            Assert.IsTrue(isValid,"C should be valid figure when its pawn's turn");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithIncorrectFigureRequestedInPawnsTurn()
        {
            IFigure[] figures = new IFigure[]
            {
                new King(new FieldCell(8, 1, 'K', ConsoleColor.Yellow), 'K'),
                new Pawn(new FieldCell(8, 3, 'A', ConsoleColor.Blue), 'A'),
                new Pawn(new FieldCell(8, 6, 'B', ConsoleColor.Blue), 'B'),
                new Pawn(new FieldCell(8, 1, 'C', ConsoleColor.Blue), 'C')
            };

            bool isValid = Checker.Instance.IsValidFigureRequested(2, "kdl", figures);
            Assert.IsFalse(isValid,"K should not be valid figure when its pawn's turn");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithInorrectDataInKingsTurn()
        {
            IFigure[] figures = new IFigure[]
            {
                new King(new FieldCell(8, 1, 'K', ConsoleColor.Yellow), 'K'),
                new Pawn(new FieldCell(8, 3, 'A', ConsoleColor.Blue), 'A'),
                new Pawn(new FieldCell(8, 6, 'B', ConsoleColor.Blue), 'B'),
                new Pawn(new FieldCell(8, 1, 'C', ConsoleColor.Blue), 'C')
            };

            bool isValid = Checker.Instance.IsValidFigureRequested(3, "cdl", figures);
            Assert.IsFalse(isValid, "C should not be valid figure when its king's turn");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithCorrectFigureRequestedInKingsTurn()
        {
            IFigure[] figures = new IFigure[]
            {
                new King(new FieldCell(8, 1, 'K', ConsoleColor.Yellow), 'K'),
                new Pawn(new FieldCell(8, 3, 'A', ConsoleColor.Blue), 'A'),
                new Pawn(new FieldCell(8, 6, 'B', ConsoleColor.Blue), 'B'),
                new Pawn(new FieldCell(8, 1, 'C', ConsoleColor.Blue), 'C')
            };

            bool isValid = Checker.Instance.IsValidFigureRequested(3, "kdl", figures);
            Assert.IsTrue(isValid, "K should be valid figure when its king's turn");
        }

        [TestMethod]
        public void IsRequestedPositionInsideTableShouldReturnTrueForCorrectPosition()
        {
            Table table = new Table(new FieldCellFactory(9, 9, ' ', ConsoleColor.Red, ConsoleColor.DarkCyan), new Frame("test.txt"));
            bool result = Checker.Instance.IsRequestedPositionInsideTable(3, 3, table);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRequestedPositionInsideTableShouldReturnFalseForIncorrectPosition()
        {
            Table table = new Table(new FieldCellFactory(9, 9, ' ', ConsoleColor.Red, ConsoleColor.DarkCyan), new Frame("test.txt"));
            bool result = Checker.Instance.IsRequestedPositionInsideTable(13, 23, table);
            Assert.IsFalse(result);
        }
    }
}
