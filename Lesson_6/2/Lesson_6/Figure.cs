using System;
using System.Collections.Generic;
using System.Text;
using MyHomeWork.Core;

namespace Lesson_6
{
    public abstract class Figure
    {
        private int _x;
        private int _y;
        private ConsoleColor _color;
        private bool _isVisible;

        ConsoleLogger mes = new ConsoleLogger();

        protected private Figure()
        {
            mes.ShowMessage("Фигура создана успешно");
        }

        public Figure(int x, int y) : this(x, y, ConsoleColor.White)
        {
        }

        public Figure(int x, int y, ConsoleColor color) : this(x, y, ConsoleColor.White, true)
        {
        }

        public Figure(int x, int y, ConsoleColor color, bool isVisible) : this()
        {
            _x = x;
            _y = y;
            _color = color;
            _isVisible = isVisible;
        }

        public int X
        {
            get { return _x; }
            set
            {
                if (value > 0)
                {
                    _x = value;
                }
                return;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value > 0)
                {
                    _y = value;
                }
                return;
            }
        }

        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        public void MoveHorizontal(int dX)
        {
            if ((X + dX) > 0)
            {
                X += dX;
            }
            return;
        }

        public void MoveVertical(int dY)
        {
            if ((Y + dY) > 0)
            {
                Y += dY;
            }
            return;
        }

        public override string ToString()
        {
            return $"Координата X: {X};\n" +
                $"координата Y: {Y};\n" +
                $"цвет: {Color};\n" +
                $"видимость: {IsVisible}.";
        }
    }
}
