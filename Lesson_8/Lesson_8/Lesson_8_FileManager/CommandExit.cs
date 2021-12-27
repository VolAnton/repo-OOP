using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandExit
    {
        public static void Exit(ref bool isExit, DirectoryInfo curDir)
        {
            isExit = true;
            Pathes.LastUsePath(curDir.FullName);
        }
    }
}
