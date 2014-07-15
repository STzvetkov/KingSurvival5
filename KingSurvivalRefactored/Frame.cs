using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
    /// <summary>
    /// Represents the frame around the playing field of the table - the directions and row and column numbers
    /// </summary>
    public class Frame
    {

        private string image;
        public Frame(string pathToFrameImage)
        {
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

        /// <summary>
        /// Uses StreamReader to read the image of the frame from a text file and save it to a string
        /// </summary>
        /// <param name="path">The path to the text file containing only the image of the frame</param>
        /// <returns>String with the drawing representation of the frame</returns>
        private string ReadImage(string path) 
        {
            // Read the frame image from .txt file
            throw new NotImplementedException();
        }

    }
}
