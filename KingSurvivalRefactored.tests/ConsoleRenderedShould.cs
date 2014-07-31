using System;
using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvivalRefactored.Interfaces;
namespace KingSurvivalRefactored.Tests
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
            return CreateConsoleRenderer(new TestWriter());
        }
        ConsoleRenderer CreateConsoleRenderer(IWriter testwriter)
        {
            return new ConsoleRenderer(DISTANCE_BETWEEN_CELLS_X, DISTANCE_BETWEEN_CELLS_Y,
                CONSOLE_INITIAL_POSITION_X, CONSOLE_INITIAL_POSITION_Y, testwriter);
        }
        [TestMethod]
        public void ReturnDistanceBetweenCellsHorizontallyCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.DistanceBetweenCellsX, DISTANCE_BETWEEN_CELLS_X,
                "The distance between cells horizontally should be " + DISTANCE_BETWEEN_CELLS_X + " but " +
                testRenderer.DistanceBetweenCellsX + " was reported");
        }
        [TestMethod]
        public void ReturnDistanceBetweenCellsVerticalyCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.DistanceBetweenCellsY, DISTANCE_BETWEEN_CELLS_Y,
                "The distance between cells vertically should be " + DISTANCE_BETWEEN_CELLS_Y + " but " +
                testRenderer.DistanceBetweenCellsY + " was reported");
        }
        [TestMethod]
        public void ReturnConsoleVerticalInitialPositionCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.ConsoleInitialPositionY, CONSOLE_INITIAL_POSITION_Y,
                "The console initial vertical position should be " + CONSOLE_INITIAL_POSITION_Y +" but " +
                testRenderer.ConsoleInitialPositionY + " was reported");
        }
        [TestMethod]
        public void ReturnConsoleHorizontalInitialPositionCorrectly()
        {
            ConsoleRenderer testRenderer = CreateConsoleRenderer();
            Assert.AreEqual(testRenderer.ConsoleInitialPositionX, CONSOLE_INITIAL_POSITION_X,
                "The console initial horizontal position should be " + CONSOLE_INITIAL_POSITION_X + " but " +
                testRenderer.ConsoleInitialPositionX + " was reported");
        }
        [TestMethod]
        public void ShouldCorrectlyDrawTable()
        {
            string testImage="This is a test image";
            //mocking the table 
            var mockedTable = new Mock<ITable>();
            //mocked the frame
            Mock<IFrame>  mockedFrame = new Mock<IFrame>();
            mockedFrame.Setup( r=> r.Image).Returns(testImage);
            mockedTable.Setup(r => r.Frame).Returns(mockedFrame.Object);
            //mock the cells and enumerator
            //first cell
            Mock<ICell> testCell = new Mock<ICell>();
            testCell.Setup(r => r.Col).Returns(10);
            testCell.Setup(r => r.Row).Returns(11);
            testCell.Setup(r => r.IsFree).Returns(true);
            testCell.Setup(r => r.Color).Returns(ConsoleColor.Black);
            testCell.Setup(r => r.Value).Returns('C');

            
            //second cell
            Mock<ICell> testCell2 = new Mock<ICell>();
            testCell2.Setup(r => r.Col).Returns(30);
            testCell2.Setup(r => r.Row).Returns(31);
            testCell2.Setup(r => r.IsFree).Returns(false);
            testCell2.Setup(r => r.Color).Returns(ConsoleColor.White);
            testCell2.Setup(r => r.Value).Returns('C');
            //add the cells to list in order to mock enumeration

            IList<ICell> testCells= new List<ICell>();
            testCells.Add(testCell.Object);
            testCells.Add(testCell2.Object);

            mockedTable.Setup(r => r.GetEnumerator()).Returns(() => testCells.GetEnumerator());  
            //Initialize the test writer
            TestWriter testWriter =   new TestWriter();
            //Create the renderer 
            IRenderer testRenderer = CreateConsoleRenderer(testWriter);
            testRenderer.DrawTable(mockedTable.Object);
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
            //correctly draw cell with a value;
            cellTextRepresentation = "Printed 'C' at x:" + (CONSOLE_INITIAL_POSITION_X + 30 * (DISTANCE_BETWEEN_CELLS_X + 1))
                + " y:" + (CONSOLE_INITIAL_POSITION_Y + 31 * (DISTANCE_BETWEEN_CELLS_Y + 1))
                + " colors bg: White fg: Black";
            Assert.IsTrue(result.Contains(cellTextRepresentation),
               "The test cell wasn't printed or was printed at the wrong place or with the wrong color\n The renderer printed:\n"
               + result + "\nIt was expected to contain " + cellTextRepresentation);
        }
        [TestMethod]
        public void ChangeImagePositionCorrectly()
        {
            //mock the old cell
            int oldCellX=10;
            int oldCellY=10;
            char oldCellSymbol='C';
            Mock<ICell> oldCell = new Mock<ICell>();
            oldCell.Setup(r => r.Col).Returns(oldCellX);
            oldCell.Setup(r => r.Row).Returns(oldCellY);
            oldCell.Setup(r => r.IsFree).Returns(false);
            oldCell.Setup(r => r.Color).Returns(ConsoleColor.Black);
            oldCell.Setup(r => r.Value).Returns(oldCellSymbol);

            //mock the new cell
            int newCellX = 12;
            int newCellY = 12;
            char newCellSymbol = 'N';
            Mock<ICell> newCell = new Mock<ICell>();
            newCell.Setup(r => r.Col).Returns(newCellX);
            newCell.Setup(r => r.Row).Returns(newCellY);
            newCell.Setup(r => r.IsFree).Returns(true);
            newCell.Setup(r => r.Color).Returns(ConsoleColor.Black);
            newCell.Setup(r => r.Value).Returns(newCellSymbol);
            
            //mock the figure
            char figureRepresentation = 'F';
            Mock<IFigure> mockedFigure = new Mock<IFigure>();
            mockedFigure.Setup(r => r.ContainingCell).Returns(oldCell.Object);
            mockedFigure.Setup(r => r.DrawingRepresentation).Returns(figureRepresentation);
            
            //Create the renderer
            TestWriter testWriter = new TestWriter();
            IRenderer testedRenderer= CreateConsoleRenderer(testWriter);
            
            //call the function 
            testedRenderer.ChangeImagePosition(mockedFigure.Object,newCell.Object);
            string result = testWriter.GetResult();
            
            //Check if the old cell is represented as empty
            string expectedCellRepresentation =  "Printed ' ' at x:"+ (CONSOLE_INITIAL_POSITION_X + oldCellX * (DISTANCE_BETWEEN_CELLS_X+1))
                + " y:" + (CONSOLE_INITIAL_POSITION_Y + oldCellY * (DISTANCE_BETWEEN_CELLS_Y + 1)) 
                +" colors bg: Black";
            Assert.IsTrue(result.Contains(expectedCellRepresentation),
                "The old cell wasn't cleared as expected\n Expected occurrence of :\n"
                + expectedCellRepresentation + "\n Actual output : \n" + result);

            //Check to see if the figure is drawn correctly
            string expectedFigureRepresentation = "Printed '"+figureRepresentation
                + "' at x:" + (CONSOLE_INITIAL_POSITION_X + newCellX * (DISTANCE_BETWEEN_CELLS_X + 1))
                + " y:" + (CONSOLE_INITIAL_POSITION_Y + newCellY * (DISTANCE_BETWEEN_CELLS_Y + 1))
                + " colors bg: Black fg: Black";
            Assert.IsTrue(result.Contains(expectedFigureRepresentation),
                "The new cell and figure wasn't cleared as expected\n Expected occurrence of :\n"
                + expectedFigureRepresentation + "\n Actual output : \n" + result);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Console renderer initialized with a null writer.")]
        public void ThrowExceptionWhenInitializingWithNullWriter()
        {
            new ConsoleRenderer(1, 1,
                1, 1, null as IWriter);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Console renderer initialized with negative horizontal initial position")]
        public void ThrowExceptionWhenInitializingWithNegativeVerticalPosition()
        {
            new ConsoleRenderer(1,1,-1,1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Console renderer initialized with negative vertical initial position")]
        public void ThrowExceptionWhenInitializingWithNegativeHorisontalPosition()
        {
            new ConsoleRenderer(1,1,1,-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Console renderer initialized with negative vertical initial margins")]
        public void ThrowExceptionWhenInitializingWithNegativeHorisontalMargins()
        {
            new ConsoleRenderer(-1,1,1,1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Console renderer initialized with negative horizontal initial margins")]
        public void ThrowExceptionWhenInitializingWithNegativeVerticalMargins()
        {
            new ConsoleRenderer(1,-1,1,1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Console renderer initialized with  horizontal initial position outside the maximum width")]
        public void ThrowExceptionWhenInitializingWithHorizontalPositionOutsideTheMaximumWidth()
        {
            TestWriter testWriter = new TestWriter();
            testWriter.LargestWindowWidth = 20;
            new ConsoleRenderer(1, 1, 40, 1,testWriter);
        }
        
    }
}
