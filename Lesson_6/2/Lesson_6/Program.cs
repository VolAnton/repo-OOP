using System;
using MyHomeWork.Core;

namespace Lesson_6
{

    class Program
    {




        static void Main(string[] args)
        {
            ConsoleLogger mes = new ConsoleLogger();

            mes.ShowMessage($"--==Фигура точка==--");
            mes.ShowMessage($"Создаём точку");
            Point p1 = new Point(1, 1, ConsoleColor.Red, true);
            mes.ShowMessage(p1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Перемещаем точку на 10 вверх и на 10 вправо:");
            p1.MoveVertical(10);
            p1.MoveHorizontal(10);
            mes.ShowMessage(p1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Меняем цвет точки на белый:");
            p1.Color = ConsoleColor.White;
            mes.ShowMessage(p1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Делаем точку невидимой:");
            p1.IsVisible = false;
            mes.ShowMessage(p1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"--==Фигура круг==--");
            mes.ShowMessage($"Создаём круг");
            Circle c1 = new Circle(10, 10, 10, ConsoleColor.Green, true);
            mes.ShowMessage(c1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Перемещаем круг на 30 вверх и на 30 вправо:");
            c1.MoveVertical(30);
            c1.MoveHorizontal(30);
            mes.ShowMessage(c1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Меняем цвет круга на желтый:");
            c1.Color = ConsoleColor.Yellow;
            mes.ShowMessage(c1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Делаем круг невидимым:");
            c1.IsVisible = false;
            mes.ShowMessage(c1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"--==Фигура прямоугольник==--");
            mes.ShowMessage($"Создаём круг");
            Rectangle r1 = new Rectangle(15, 20, new Size(20, 30), ConsoleColor.Blue, true);
            mes.ShowMessage(c1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Перемещаем прямоугольник на 100 вверх и на 200 вправо:");
            r1.MoveVertical(-100);
            r1.MoveHorizontal(200);
            mes.ShowMessage(r1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Меняем цвет прямоугольника на серый:");
            r1.Color = ConsoleColor.Gray;
            mes.ShowMessage(r1.ToString());
            mes.SkippingLines(1);
            mes.ShowMessage($"Делаем прямоугольник невидимым:");
            r1.IsVisible = false;
            mes.ShowMessage(r1.ToString());

            Console.ReadKey();
        }
    }
}
