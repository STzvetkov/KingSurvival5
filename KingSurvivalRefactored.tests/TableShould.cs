namespace KingSurvivalRefactored.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TableShould
    {
        [TestMethod]
        public void TraverseAndTinitializeCorrectlyWhenCorrectDataIsProvided()
        {
            string expectedFrameImage = "This\nIs some text,\nMent to test the\nframe\n";
             
            FieldCellFactory testFactory = new FieldCellFactory(8, 8, '&', ConsoleColor.Blue, ConsoleColor.Red);
            Table testTable = new Table(testFactory, new Frame("test.txt"));

            bool testISValid=true;
            bool isCurrentOdd;

            string expectedCell="";
            string givenCell = "";
           
            for (int i = 0; i < 8; i++)
            {
                isCurrentOdd = (i%2 == 0);
                for (int j = 0; j < 8; j++)
                {
                    expectedCell = j + " " + i + " & " + 
                        (isCurrentOdd? ConsoleColor.Red : ConsoleColor.Blue);
                    isCurrentOdd = !isCurrentOdd;
                    givenCell = testTable.Cells[j,i].Row + " "
                        + testTable.Cells[j, i].Col + " "
                        + testTable.Cells[j, i].Value + " "
                        + testTable.Cells[j, i].Color;

                    if (expectedCell != givenCell)
                    {
                        testISValid = false;
                        break;
                    }
                }
                if (!testISValid)
                {
                    break;
                }
                
            }
                Console.WriteLine( );
                Assert.IsTrue(testISValid, "One of the cells wasn't initialized or returned properly.\nExpected:"
                    + expectedCell + "\nGiven:\n" + givenCell);
            Assert.AreEqual(testTable.Frame.Image, expectedFrameImage,
                "The frame image isn't the expected one.\nImageGiven by the table:\n"
                + testTable.Frame.Image + "\nExpected Image:\n"
                + expectedFrameImage);
        }
    }
}
