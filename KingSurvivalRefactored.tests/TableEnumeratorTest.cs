namespace KingSurvivalRefactored.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvivalRefactored.Interfaces;

    [TestClass]
    public class TableEnumeratorTest
    {
        private TableEnumerator tableEnumerator;

        [TestInitialize]
        [TestMethod]
        public void InitEnumerator()
        {
            FieldCellFactory testFactory = new FieldCellFactory(8, 8, '&', ConsoleColor.Blue, ConsoleColor.Red);
            Table testTable = new Table(testFactory, new Frame("../../test.txt"));
            tableEnumerator = new TableEnumerator(testTable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorSholdThrowExceptionIfTheTableIsNull()
        {
            tableEnumerator = new TableEnumerator(null);
        }

        [TestMethod]
        public void CurrentShouldReturnTheFirstRow()
        {
            var currentCell = tableEnumerator.Current as FieldCell;
            Assert.AreEqual(0, currentCell.Row);
        }

        [TestMethod]
        public void CurrentShouldReturnTheFirstCol()
        {
            var currentCell = tableEnumerator.Current as FieldCell;
            Assert.AreEqual(0, currentCell.Col);
        }

        [TestMethod]
        public void MoveNextShouldReturnTrueWhenNextCellIsAvailable()
        {
            var result = tableEnumerator.MoveNext();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TheIteratorShouldIterateOverTheTableProperly()
        {
            FieldCellFactory testFactory = new FieldCellFactory(8, 8, '&', ConsoleColor.Blue, ConsoleColor.Red);
            Table testTable = new Table(testFactory, new Frame("../../test.txt"));
            ICell result;
            int row = 0;
            int col = 0;

            foreach (ICell item in testTable)
            {
                result = item;
                Assert.AreEqual(row, result.Row, "The row is not correc. Expected value: " + row + " Actual value: " + result.Row);
                Assert.AreEqual(col, result.Col, "The col is not correc. Expected value: " + col + " Actual value: " + result.Col);

                row++;

                if (row == testTable.Cells.GetLength(0))
                {
                    row = 0;
                    col++;
                }

            }
        }
    }
}
