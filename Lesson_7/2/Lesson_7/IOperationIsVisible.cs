using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7
{
    public interface IOperationIsVisible
    {
        public void MoveHorizontal(int dX)
        {
        }

        public void MoveVertical(int dY)
        {
        }

        public bool IsVisible { get; }

    }
}
