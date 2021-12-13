using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6
{
    public class Circle : Point
    {
        private int _radius;

        public Circle(int x, int y, int radius) : this(x, y, radius, ConsoleColor.White)
        {
        }

        public Circle(int x, int y, int radius, ConsoleColor color) : this(x, y, radius, color, true)
        {
        }

        public Circle(int x, int y, int radius, ConsoleColor color, bool isVisible) : base(x, y, color, isVisible)
        {
            _radius = radius;
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public float GetArea()
        {
            float result = (float)(Math.PI * Radius * Radius);
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + $"\r\nПлощадь круга равна: {GetArea()}";
        }
    }
}
