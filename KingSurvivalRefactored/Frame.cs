using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using KingSurvivalRefactored.Interfaces;

namespace KingSurvivalRefactored
{
    /// <summary>
    /// Represents the frame around the playing field of the table - the directions and row and column numbers
    /// </summary>
    public class Frame:IFrame
    {

        private string image;
        private int height;
        private int width;
        public Frame(string pathToFrameImage)
        {
            this.Width = 0;
            this.Height = 0;
            this.image = ReadImage(pathToFrameImage);
        }
        public string Image
        {
            get
            {
                return this.image;
            }

            private set
            {
                this.image = value;
            }
        }

        public int Width
        {
            get 
            {
                return this.width;
            }
            private set
            {
                if (value < 0 || value > Console.LargestWindowWidth)
                {
                    throw new ArgumentOutOfRangeException("The frame is too wide to fit the console window");
                }
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0 || value > Console.LargestWindowHeight)
                {
                    throw new ArgumentOutOfRangeException("The frame is too high to fit the console window");
                }
                this.height = value;
            }
        }

        /// <summary>
        /// Uses StreamReader to read the image of the frame from a text file and save it to a string
        /// </summary>
        /// <param name="path">The path to the text file containing only the image of the frame</param>
        /// <returns>String with the drawing representation of the frame</returns>
        private string ReadImage(string path) 
        {
            StringBuilder result = new StringBuilder();
            //may be handling the exception when the file is not present
            //however at this point we don't have the means to adequately manage that situation better than the framework 
            using (StreamReader imageReader = new StreamReader(path))
            {
                string readLineBuffer = imageReader.ReadLine();
                this.Width = readLineBuffer.Length;
                while (readLineBuffer != null)
                {
                    result.Append(readLineBuffer + "\n");
                    this.Height++;
                    if (readLineBuffer.Length > this.Width)
                    {
                        this.Width = readLineBuffer.Length;
                    }
                    readLineBuffer = imageReader.ReadLine();
                }
            }
            return result.ToString();
        }

    }
}
