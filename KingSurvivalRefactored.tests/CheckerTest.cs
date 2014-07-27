namespace KingSurvivalRefactored.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvivalRefactored.Interfaces;

    [TestClass]
    public class CheckerTest
    {
        [TestMethod]
        public void IsValidMoveForKingShouldReturnTrueForCorrectData()
        {
            IFigure king = this.InitKing(2, 3);
            bool isValid = Checker.Instance.IsValidMove(king, "kur");
            Assert.IsTrue(isValid, "KUR should be valid move for king");
        }

        [TestMethod]
        public void IsValidMoveForKingShouldReturnFalseForIvalidDirection()
        {
            IFigure king = this.InitKing(2, 3);
            bool isValid = Checker.Instance.IsValidMove(king, "kfr");
            Assert.IsFalse(isValid, "KFR shouldn't be valid move");
        }

        [TestMethod]
        public void HasKingWonShouldReturtTrueWhenTheKingIsOnTheTop()
        {
            IFigure king = this.InitKing(0, 0);
            bool hasWon = Checker.Instance.HasKingWon(king as King);
            Assert.IsTrue(hasWon, "If the king is with Y position = 0, it should win");
        }

        [TestMethod]
        public void HasKingWonShouldReturtFalseWhenTheKingIsNotOnTheTop()
        {
            IFigure king = this.InitKing(0, 1);
            bool hasWon = Checker.Instance.HasKingWon(king as King);
            Assert.IsFalse(hasWon, "If the king is NOT with Y position = 0, it should NOT win");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenAllTheCellsAroundTheKingAreFree()
        {
            IFigure king = this.InitKing(5, 5);
            Table table = this.InitTable(9, 9);
            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost, "The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenBottomRightCellsAroundTheKingIsFree()
        {
            IFigure king = this.InitKing(5, 5);
            Table table = this.InitTable(9, 9);

            table.Cells[4, 4] = new FieldCell(4, 4, 'A', ConsoleColor.Blue);
            table.Cells[4, 6] = new FieldCell(4, 6, 'B', ConsoleColor.Blue);
            table.Cells[6, 4] = new FieldCell(6, 4, 'C', ConsoleColor.Blue);

            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost, "The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenBottomLeftCellsAroundTheKingIsFree()
        {
            IFigure king = this.InitKing(5, 5);
            Table table = this.InitTable(9, 9);

            table.Cells[4, 4] = new FieldCell(4, 4, 'A', ConsoleColor.Blue);
            table.Cells[6, 4] = new FieldCell(6, 4, 'B', ConsoleColor.Blue);
            table.Cells[6, 6] = new FieldCell(6, 6, 'D', ConsoleColor.Blue);

            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost, "The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenUpperLeftCellsAroundTheKingIsFree()
        {
            IFigure king = this.InitKing(5, 5);
            Table table = this.InitTable(9, 9);

            table.Cells[6, 4] = new FieldCell(6, 4, 'B', ConsoleColor.Blue);
            table.Cells[4, 6] = new FieldCell(4, 6, 'B', ConsoleColor.Blue);
            table.Cells[6, 6] = new FieldCell(6, 6, 'D', ConsoleColor.Blue);

            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost, "The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenUpperRightCellsAroundTheKingIsFree()
        {
            IFigure king = this.InitKing(5, 5);
            Table table = this.InitTable(9, 9);

            table.Cells[4, 4] = new FieldCell(4, 4, 'a', ConsoleColor.Blue);
            table.Cells[4, 6] = new FieldCell(4, 6, 'B', ConsoleColor.Blue);
            table.Cells[6, 6] = new FieldCell(6, 6, 'D', ConsoleColor.Blue);

            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost, "The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenThereIsPossibleMoveAndKingIsAtTheEndOfTheTable()
        {
            IFigure king = this.InitKing(8, 8);
            Table table = this.InitTable(9, 9);
            table.Cells[4, 4] = new FieldCell(7, 7, 'a', ConsoleColor.Blue);
            table.Cells[4, 6] = new FieldCell(4, 6, 'B', ConsoleColor.Blue);
            table.Cells[6, 6] = new FieldCell(6, 6, 'D', ConsoleColor.Blue);

            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost, "The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void HasKingLostShouldReturnFalseWhenThereIsPossibleMoveAndKingIsAtTheStartOfTheTable()
        {
            IFigure king = this.InitKing(0, 0);
            Table table = this.InitTable(9, 9);
            table.Cells[4, 4] = new FieldCell(4, 4, 'a', ConsoleColor.Blue);
            table.Cells[4, 6] = new FieldCell(4, 6, 'B', ConsoleColor.Blue);
            table.Cells[6, 6] = new FieldCell(6, 6, 'D', ConsoleColor.Blue);

            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsFalse(hasLost, "The king cannot lose if there is a free cell around it");
        }

        [TestMethod]
        public void HasKingLostShouldReturnTrue()
        {
            IFigure king = this.InitKing(5, 5);
            Table table = this.InitTable(9, 9);

            table.Cells[4, 4] = new FieldCell(4, 4, 'A', ConsoleColor.Blue);
            table.Cells[4, 6] = new FieldCell(4, 6, 'B', ConsoleColor.Blue);
            table.Cells[6, 4] = new FieldCell(6, 4, 'C', ConsoleColor.Blue);
            table.Cells[6, 6] = new FieldCell(6, 6, 'D', ConsoleColor.Blue);

            bool hasLost = Checker.Instance.HasKingLost(king as King, table);
            Assert.IsTrue(hasLost, "The king lose if there is no  a free cell around it");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithCorrectDataInPawnsTurn()
        {
            IFigure[] figures = this.GetFigures();

            bool isValid = Checker.Instance.IsValidFigureRequested(2, "cdl", figures);
            Assert.IsTrue(isValid, "C should be valid figure when its pawn's turn");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithIncorrectFigureRequestedInPawnsTurn()
        {
            IFigure[] figures = this.GetFigures();

            bool isValid = Checker.Instance.IsValidFigureRequested(2, "kdl", figures);
            Assert.IsFalse(isValid, "K should not be valid figure when its pawn's turn");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithInorrectDataInKingsTurn()
        {
            IFigure[] figures = this.GetFigures();

            bool isValid = Checker.Instance.IsValidFigureRequested(3, "cdl", figures);
            Assert.IsFalse(isValid, "C should not be valid figure when its king's turn");
        }

        [TestMethod]
        public void IsValidFigureRequestedWithCorrectFigureRequestedInKingsTurn()
        {
            IFigure[] figures = this.GetFigures();

            bool isValid = Checker.Instance.IsValidFigureRequested(3, "kdl", figures);
            Assert.IsTrue(isValid, "K should be valid figure when its king's turn");
        }

        [TestMethod]
        public void IsRequestedPositionInsideTableShouldReturnTrueForCorrectPosition()
        {
            Table table = this.InitTable(9, 9);
            bool result = Checker.Instance.IsRequestedPositionInsideTable(3, 3, table);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRequestedPositionInsideTableShouldReturnFalseForIncorrectPosition()
        {
            Table table = this.InitTable(9, 9);
            bool result = Checker.Instance.IsRequestedPositionInsideTable(13, 23, table);
            Assert.IsFalse(result);
        }

        private Table InitTable(int rowsCountInTable, int colsCountInTable)
        {
            return new Table(new FieldCellFactory(rowsCountInTable, colsCountInTable, ' ',
                ConsoleColor.Red, ConsoleColor.DarkCyan), new Frame("test.txt"));
        }

        private King InitKing(int kingRow, int kingCol)
        {
            return new King(new FieldCell(kingRow, kingCol, 'K', ConsoleColor.Blue), 'K');
        }

        private IFigure[] GetFigures()
        {
            IFigure[] figures = new IFigure[]
            {
                new King(new FieldCell(8, 1, 'K', ConsoleColor.Yellow), 'K'),
                new Pawn(new FieldCell(8, 3, 'A', ConsoleColor.Blue), 'A'),
                new Pawn(new FieldCell(8, 6, 'B', ConsoleColor.Blue), 'B'),
                new Pawn(new FieldCell(8, 1, 'C', ConsoleColor.Blue), 'C')
            };

            return figures;
        }
    }
}