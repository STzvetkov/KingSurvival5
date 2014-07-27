using System;
using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored.tests
{
    [TestClass]
    public class ConsoleRenderedShould
    {
        const int DISTANCE_BETWEEN_CELLS_X = 1;
        const int DISTANCE_BETWEEN_CELLS_Y = 0;
        const int CONSOLE_INITIAL_POSITION_X = 4;
        const int CONSOLE_INITIAL_POSITION_Y = 3;
        ConsoleRenderer CreateConsoleRenderer()
        {
            return new ConsoleRenderer(DISTANCE_BETWEEN_CELLS_X, DISTANCE_BETWEEN_CELLS_Y,
                CONSOLE_INITIAL_POSITION_X, CONSOLE_INITIAL_POSITION_Y,new TestWriter());
        }
        [TestMethod]
        public void returnDistanceBetweenCellsHorizontallyCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.DistanceBetweenCellsX, DISTANCE_BETWEEN_CELLS_X,
                "The distance between cells horizontally should be " + DISTANCE_BETWEEN_CELLS_X + " but " +
                testRenderer.DistanceBetweenCellsX + " was reported");
        }
        [TestMethod]
        public void returnDistanceBetweenCellsVerticalyCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.DistanceBetweenCellsY, DISTANCE_BETWEEN_CELLS_Y,
                "The distance between cells vertically should be " + DISTANCE_BETWEEN_CELLS_Y + " but " +
                testRenderer.DistanceBetweenCellsY + " was reported");
        }
        [TestMethod]
        public void returnConsoleVerticalInitialPositionCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.ConsoleInitialPositionY, CONSOLE_INITIAL_POSITION_Y,
                "The console initial vertical position should be " + CONSOLE_INITIAL_POSITION_Y +" but " +
                testRenderer.ConsoleInitialPositionY + " was reported");
        }
        [TestMethod]
        public void returnConsoleHorizontalInitialPositionCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.ConsoleInitialPositionX, CONSOLE_INITIAL_POSITION_X,
                "The console initial horizontal position should be " + CONSOLE_INITIAL_POSITION_X + " but " +
                testRenderer.ConsoleInitialPositionX + " was reported");
        }
        [TestMethod]
        public void shouldCorrectlyDrawTable()
        {
            string testImage="This is a test image";
            //mocking the table 
            var mockedTable = new Mock<ITable>();
            //mocked the frame
            Mock<IFrame>  mockedFrame = new Mock<IFrame>();
            mockedFrame.Setup( r=> r.Image).Returns(testImage);
            mockedTable.Setup(r => r.Frame).Returns(mockedFrame.Object);
            //mock the cells and enumerator
            Mock<ICell> testCell = new Mock<ICell>();
            testCell.Setup(r => r.Col).Returns(10);
            testCell.Setup(r => r.Row).Returns(11);
            testCell.Setup(r => r.IsFree).Returns(true);
            testCell.Setup(r => r.Color).Returns(ConsoleColor.Black);
            testCell.Setup(r => r.Value).Returns('C');
            IList<ICell> testCells= new List<ICell>();
            testCells.Add(testCell.Object);
            mockedTable.Setup(r => r.GetEnumerator()).Returns(() => testCells.GetEnumerator());  
            //Initialize the test writer
            TestWriter testWriter =   new TestWriter();
            //Create the renderer 
            IRenderer testRenderer = new ConsoleRenderer(DISTANCE_BETWEEN_CELLS_X, DISTANCE_BETWEEN_CELLS_Y,
                CONSOLE_INITIAL_POSITION_X, CONSOLE_INITIAL_POSITION_Y,testWriter);
            testRenderer.DrawTable(mockedTable.Object);
            //Printed 'This is a test image' at x:0 y:0 colors bg: black fg: white Printed '\0' at x:24 y:14 colors bg: Black fg: Black
            string result  = testWriter.GetResult();
            //Correctly draw image
            Assert.IsTrue(result.Contains("Printed '" + testImage + "' at x:0 y:0 colors bg: black fg: white"),
                "The test image frame wasn't printed or was printed at the wrong place or with the wrong color\n The renderer printed:\n" + result);
            //Correctly draw cells
            //cellTextRepresentation is constructing the cell text representation as we expect our test writer to record it
            string cellTextRepresentation = "Printed 'C' at x:"+ (CONSOLE_INITIAL_POSITION_X + 10 * (DISTANCE_BETWEEN_CELLS_X+1))
                + " y:" + (CONSOLE_INITIAL_POSITION_Y + 11 * (DISTANCE_BETWEEN_CELLS_Y + 1)) 
                +" colors bg: Black fg: Black";
            Assert.IsTrue(result.Contains(cellTextRepresentation),
                "The test cell wasn't printed or was printed at the wrong place or with the wrong color\n The renderer printed:\n"
                + result + "\nIt was expected to contain " + cellTextRepresentation);
       

        }
    }
}
