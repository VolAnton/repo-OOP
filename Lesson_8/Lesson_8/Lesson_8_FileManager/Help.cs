using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class Help
    {
        private static string _helpPath = @"help.txt";

        public static void GetHelp()
        {
            Console.Clear();
            Console.WriteLine(File.ReadAllText(_helpPath));
        }
    }
}
