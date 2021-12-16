using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7
{
    public struct Size
    {
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Size(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}
