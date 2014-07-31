using System;
using Moq;
using KingSurvivalRefactored.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingSurvivalRefactored.Tests
{
    [TestClass]
    public class FigureFactoryShould
    {
        private IFigureFactory CreateTestFactory(int pawnCount)
        {
            Mock<ICell> mockedCell = new Mock<ICell>();
            ICell[,] dummyTable = new ICell[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dummyTable[i, j] = mockedCell.Object;
                }
            }
            Mock<ITable> mockedTable = new Mock<ITable>();
           
            mockedTable.Setup(r => r.Cells).Returns(dummyTable);
            IFigureFactory testFactory = new FigureFactory(mockedTable.Object, pawnCount);
            return testFactory;
        }
        [TestMethod]
        public void GenerateTheRightNumberOfFigures()
        {
            int numberOfFigures = CreateTestFactory(4).GenerateFigures().Length;
            Assert.AreEqual(numberOfFigures, 5,
                "We expected the factory to generate 4 figures it generated "
                + numberOfFigures + ".");
        }
    }
}
