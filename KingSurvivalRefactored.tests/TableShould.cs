using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace KingSurvivalRefactored.tests
{
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
            bool IsCurrentOdd = true;
            string expectedCell="";
            string givenCell = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    expectedCell = j + " " + i + " & " + 
                        (IsCurrentOdd?ConsoleColor.Red:ConsoleColor.Blue);
                    IsCurrentOdd = !IsCurrentOdd;
                    givenCell = testTable.Cells[j,i].Col + " "
                        + testTable.Cells[j, i].Row + " "
                        + testTable.Cells[j, i].Value + " "
                        + testTable.Cells[j, i].Color;
                    if (expectedCell != givenCell)
                    {
                        testISValid = false;
                        break;
                    }
                }
            }
                Console.WriteLine( );
                Assert.IsTrue(testISValid, "One of the cells wasn't initialized or returned properly.\nExpected:"
                    + expectedCell + "\nGiven:\n" + givenCell);
            Assert.AreEqual(testTable.TableFrame.Image, expectedFrameImage,
                "The frame image isn't the expected one.\nImageGiven by the table:\n"
                + testTable.TableFrame.Image + "\nExpected Image:\n"
                + expectedFrameImage);
        }
    }
}
