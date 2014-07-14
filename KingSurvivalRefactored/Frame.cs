using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalRefactored
{
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

        private string ReadImage(string path) 
        {
            // Read the frame image from .txt file
            throw new NotImplementedException();
        }

    }
}
