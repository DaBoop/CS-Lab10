using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    class Image
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public string compression { get; set; }
        public string name { get; private set; }
        public Image(int width_arg = 0, int height_arg = 0, string compression_arg = "bmp", string name_arg = "img") => (width, height, compression, name) = (width_arg, height_arg, compression_arg, name_arg);

        public void Scale (int x = 1, int y = 1)
        {
            if ((x < 0) || (y < 0))
            {
                throw new ArgumentException("One argument is below zero");
            }
            else
            {
                width = width * x;
                height = height * y;
            }
        }

       public override string ToString()
        {
            return $"{name}.{compression}({width}x{height})";
        }
    }
}
