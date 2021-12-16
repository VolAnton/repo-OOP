using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7
{
    public class Point : Figure
    {
        protected private Point()
        {
        }

        public Point(int x, int y) : this(x, y, ConsoleColor.White)
        {
        }

        public Point(int x, int y, ConsoleColor color) : this(x, y, ConsoleColor.White, true)
        {
        }

        public Point(int x, int y, ConsoleColor color, bool isVisible) : base(x, y, color, isVisible)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
