using System;
using MyHomeWork.Core;

namespace Lesson_5
{

    class Program
    {

        public sealed class RationalNumbers
        {
            //Поле числитель
            private int _nunemrator;

            //Поле знаменатель
            private uint _denominator;

            ConsoleLogger message = new ConsoleLogger();

            public int Numerator
            {
                get { return _nunemrator; }
                set { _nunemrator = value; }
            }

            public uint Denominator
            {
                get { return _denominator; }
                set
                {
                    if (value != 0)
                    {
                        _denominator = value;
                    }
                    else
                    {
                        _denominator = 1;
                        message.ShowMessage("Знаменатель не может быть равен нулю, он был заменен на 1.");
                    }
                }
            }

            public double Fraction
            {
                get { return ((double)_nunemrator / (double)_denominator); }
            }

            public RationalNumbers(int numerator, uint denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }

            public static bool operator ==(RationalNumbers value1, RationalNumbers value2)
            {
                return (value1.Numerator == value2.Numerator && value1.Denominator == value2.Denominator);
            }

            public static bool operator !=(RationalNumbers value1, RationalNumbers value2)
            {
                return (value1.Numerator != value2.Numerator || value1.Denominator != value2.Denominator);
            }


            public bool Equals(RationalNumbers other)
            {
                if (other is null)
                {
                    return false;
                }
                return other.Numerator == Numerator && other.Denominator == Denominator;

            }

            public override bool Equals(object obj)
            {
                return Equals(obj as RationalNumbers);
            }

            public override int GetHashCode()
            {
                int hashCode = Numerator.GetHashCode() + Denominator.GetHashCode();
                return hashCode;
            }

            public static bool operator <(RationalNumbers value1, RationalNumbers value2)
            {
                return (value1.Fraction < value2.Fraction);
            }

            public static bool operator >(RationalNumbers value1, RationalNumbers value2)
            {
                return (value1.Fraction > value2.Fraction);
            }

            public static bool operator <=(RationalNumbers value1, RationalNumbers value2)
            {
                return (value1.Fraction <= value2.Fraction);
            }

            public static bool operator >=(RationalNumbers value1, RationalNumbers value2)
            {
                return (value1.Fraction >= value2.Fraction);
            }

            public static RationalNumbers operator +(RationalNumbers value1, RationalNumbers value2)
            {
                return new RationalNumbers((value1.Numerator * (int)value2.Denominator) + (value2.Numerator * (int)value1.Denominator), value1.Denominator * value2.Denominator);
            }

            public static RationalNumbers operator -(RationalNumbers value1, RationalNumbers value2)
            {
                return new RationalNumbers((value1.Numerator * (int)value2.Denominator) - (value2.Numerator * (int)value1.Denominator), value1.Denominator * value2.Denominator);
            }

            public static RationalNumbers operator ++(RationalNumbers value)
            {
                return (value + new RationalNumbers(1, 1));
            }

            public static RationalNumbers operator --(RationalNumbers value)
            {
                return (value - new RationalNumbers(1, 1));
            }

            public override string ToString()
            {
                if (Numerator != 0)
                {
                    return $"{Numerator}/{Denominator}";
                }
                return $"0";
            }

            public static implicit operator double(RationalNumbers value)
            {
                return value.Fraction;
            }

            public static explicit operator float(RationalNumbers value)
            {
                return (float)value.Fraction;
            }

            public static explicit operator int(RationalNumbers value)
            {
                return (int)value.Fraction;
            }

            public static RationalNumbers operator *(RationalNumbers value1, RationalNumbers value2)
            {
                return new RationalNumbers(value1.Numerator * value2.Numerator, value1.Denominator * value2.Denominator);
            }

            public static RationalNumbers operator /(RationalNumbers value1, RationalNumbers value2)
            {
                return new RationalNumbers(value1.Numerator * (int)value2.Denominator, value1.Denominator * (uint)value2.Numerator);
            }

            public static double operator %(RationalNumbers value1, RationalNumbers value2)
            {
                if (value2.Fraction != 0)
                {
                    return (double)(value1.Fraction % value2.Fraction);
                }
                return 0;
            }

        }

        static void Main(string[] args)
        {
            ConsoleLogger mes = new ConsoleLogger();

            RationalNumbers r1 = new RationalNumbers(99, 23);
            mes.ShowMessage($"Пример рабоы r1.ToString(): \t{r1.ToString()}");


            RationalNumbers r2 = new RationalNumbers(50, 17);
            mes.ShowMessage($"Пример рабоы r2.ToString(): \t{r2.ToString()}");

            RationalNumbers r3 = new RationalNumbers(1, 1);

            mes.ShowMessage($"Пример рабоы r1 == r2: \t{r1 == r2}");
            mes.ShowMessage($"Пример рабоы r1 != r2: \t{r1 != r2}");
            mes.ShowMessage($"Пример рабоы r1 < r2: \t{r1 < r2}");
            mes.ShowMessage($"Пример рабоы r1 > r2: \t{r1 > r2}");
            mes.ShowMessage($"Пример рабоы r1 <= r2: \t{r1 <= r2}");
            mes.ShowMessage($"Пример рабоы r1 >= r2: \t{r1 >= r2}");
            mes.ShowMessage($"Пример рабоы r3 = r1 + r2: \t{r3 = r1 + r2}");
            mes.ShowMessage($"Пример рабоы r3 = r1 - r2: \t{r3 = r1 - r2}");

            r1++;
            mes.ShowMessage($"Пример рабоы r1++: \t{r1}");

            r2--;
            mes.ShowMessage($"Пример рабоы r2--: \t{r2}");

            double d = r1.Fraction;
            mes.ShowMessage($"Пример рабоы неявное преобразование (double): \t{d}");

            float f = (float)r1.Fraction;
            mes.ShowMessage($"Пример рабоы явное преобразование (float): \t{f}");

            int i = (int)r1.Fraction;
            mes.ShowMessage($"Пример рабоы явное преобразование (int): \t{i}");

            r3 = r1 * r2;
            mes.ShowMessage($"Пример рабоы r3 = r1 * r2: \t{r3}");

            r3 = r1 / r2;
            mes.ShowMessage($"Пример рабоы r3 = r1 / r2: \t{r3}");

            mes.ShowMessage($"Пример рабоы r1 % r2: \t{r1 % r2}");

            mes.ShowMessage($"Пример рабоы r1.Equals(r2): \t{r1.Equals(r2)}");

            r3 = r2;
            mes.ShowMessage($"r3 = r2");
            mes.ShowMessage($"Пример рабоы r3.Equals(r2): \t{r3.Equals(r2)}");

            mes.ShowMessage($"Пример рабоы r1.GetHashCode(): \t{r1.GetHashCode()}");
            mes.ShowMessage($"Пример рабоы r2.GetHashCode(): \t{r2.GetHashCode()}");
            mes.ShowMessage($"Пример рабоы r3.GetHashCode(): \t{r3.GetHashCode()}");

            Console.ReadKey();
        }
    }
}