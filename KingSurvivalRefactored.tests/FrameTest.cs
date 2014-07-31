namespace KingSurvivalRefactored.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

    [TestClass]
    public class FrameTest
    {
        [TestMethod]
        public void CorrectlyInitializeTheFrameShouldReturnCorrectWidth()
        {
            Frame frame = new Frame("../../test.txt");
            Assert.AreEqual(16, frame.Width,"The width of the picture is not correct.");
        }

        [TestMethod]
        public void CorrectlyInitializeTheFrameShouldReturnCorrectHeight()
        {
            Frame frame = new Frame("../../test.txt");
            Assert.AreEqual(4, frame.Height, "The height of the picture is not correct.");
        }

        [TestMethod]
        [ExpectedException (typeof (FileNotFoundException))]
        public void PassingIncorrectFileShouldThrowException()
        {
            Frame frame = new Frame("../../test-fake.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PassingTooLagreFileShouldThrowException()
        {
            Frame frame = new Frame("../../test-incorrect1.txt");
        }

        [TestMethod]
        public void ThePropertyShouldReturnTheSamePicture()
        {
            Frame frame = new Frame("../../test.txt");
            Assert.AreEqual("This\nIs some text,\nMent to test the\nframe\n", frame.Image,"The string representing the picture is not correct.");
        }
    }
}