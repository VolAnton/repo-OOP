using System;
using MyHomeWork.Core;

namespace Lesson_5
{

    class Program
    {
        /*
        Комплексное число — это выражение вида a + bi,
        где a, b — действительные числа, а i — так называемая мнимая единица, символ, квадрат которого равен –1
         */
        public sealed class ComplexNumber
        {
            private double _a;
            private double _b;

            ConsoleLogger message = new ConsoleLogger();

            public double A
            {
                get { return _a; }
                set { _a = value; }
            }

            public double B
            {
                get { return _b; }
                set { _b = value; }
            }

            public double Fraction
            {
                get { return ((double)_a / (double)_b); }
            }

            public ComplexNumber(double a, double b)
            {
                A = a;
                B = b;
            }

            public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
            {
                return new ComplexNumber(c1.A + c2.A, c1.B + c2.B);
            }

            public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
            {
                return new ComplexNumber(c1.A - c2.A, c1.B - c2.B);
            }

            public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
            {
                return new ComplexNumber(c1.A * c2.A - c1.B * c2.B, c1.A * c2.B + c1.B * c2.A);
            }
            public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
            {
                return new ComplexNumber
                    ((c1.A * c2.A + c1.B * c2.B) / (c2.A * c2.A + c2.B * c2.B),
                    (c1.B * c2.A - c1.A * c2.B) / (c2.A * c2.A + c2.B * c2.B));
            }

            public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
            {
                return (c1.A == c2.A && c1.B == c2.B);
            }

            public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
            {
                return (c1.A != c2.A || c1.B != c2.B);
            }

            public bool Equals(ComplexNumber other)
            {
                if (other is null)
                {
                    return false;
                }
                return other.A == A && other.B == B;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as ComplexNumber);
            }

            public override int GetHashCode()
            {
                int hashCode = A.GetHashCode() + B.GetHashCode();
                return hashCode;
            }

            public override string ToString()
            {
                if (A != 0 && B != 0)
                {
                    if (B > 0)
                    {
                        return $"{A}+{B}i";
                    }
                    else
                    {
                        return $"{A}{B}i";
                    }
                }
                if (A != 0)
                {
                    if (B > 0)
                    {
                        return $"+{B}i";
                    }
                    else
                    {
                        return $"{B}i";
                    }
                }
                return $"{A}";
            }
        }

        static void Main(string[] args)
        {
            ConsoleLogger mes = new ConsoleLogger();

            ComplexNumber c1 = new ComplexNumber(99, 23);
            mes.ShowMessage($"Пример рабоы r1.ToString(): \t{c1.ToString()}");

            ComplexNumber c2 = new ComplexNumber(50, 17);
            mes.ShowMessage($"Пример рабоы r2.ToString(): \t{c2.ToString()}");

            ComplexNumber c3 = new ComplexNumber(1, 1);

            mes.ShowMessage($"Пример рабоы c1 == c2: \t{c1 == c2}");
            mes.ShowMessage($"Пример рабоы c1 != c2: \t{c1 != c2}");
            mes.ShowMessage($"Пример рабоы c3 = c1 + c2: \t{c3 = c1 + c2}");
            mes.ShowMessage($"Пример рабоы c3 = c1 - c2: \t{c3 = c1 - c2}");

            c3 = c1 * c2;
            mes.ShowMessage($"Пример рабоы c3 = c1 * c2: \t{c3}");

            c3 = c1 / c2;
            mes.ShowMessage($"Пример рабоы c3 = c1 / c2: \t{c3}");

            mes.ShowMessage($"Пример рабоы c1.Equals(c2): \t{c1.Equals(c2)}");

            c3 = c2;
            mes.ShowMessage($"c3 = c2");
            mes.ShowMessage($"Пример рабоы c3.Equals(c2): \t{c3.Equals(c2)}");

            mes.ShowMessage($"Пример рабоы c1.GetHashCode(): \t{c1.GetHashCode()}");
            mes.ShowMessage($"Пример рабоы c2.GetHashCode(): \t{c2.GetHashCode()}");
            mes.ShowMessage($"Пример рабоы c3.GetHashCode(): \t{c3.GetHashCode()}");

            Console.ReadKey();
        }
    }
}