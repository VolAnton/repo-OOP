using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeWork.Core
{
    public abstract class Logger
    {
        public abstract void ShowMessage(string message);
    }

    public sealed class ConsoleLogger : Logger
    {
        public override void ShowMessage(string message)
        {
            System.Console.WriteLine(message);
        }
        public void SkippingLines(sbyte lines)
        {
            if (lines <= 0)
            {
                return;
            }

            for (int i = 1; i <= lines; i++)
            {
                System.Console.WriteLine("");
            }
        }
    }
}
