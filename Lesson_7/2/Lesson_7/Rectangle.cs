using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7
{
    public sealed class Rectangle : Point, IOperationGetArea
    {
        private Size _size;
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Rectangle(int x, int y, Size size) : this(x, y, size, ConsoleColor.White)
        {
        }

        public Rectangle(int x, int y, Size size, ConsoleColor color) : this(x, y, size, color, true)
        {
        }

        public Rectangle(int x, int y, Size size, ConsoleColor color, bool isVisible) : base(x, y, color, isVisible)
        {
            _size = size;
        }

        public float GetArea()
        {
            int result = Size.Width * Size.Height;
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + $"\r\nПлощадь прямоугольника равна: {GetArea()}";
        }
        
    }
}
