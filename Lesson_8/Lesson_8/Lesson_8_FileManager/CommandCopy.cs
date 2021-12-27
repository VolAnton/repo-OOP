using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandCopy
    {
        public static void Cp(string [] inputId)
        {
            try
            {
                string fromPath = Pathes.CheckEndPath(inputId[1]);
                Console.WriteLine(fromPath);
                string toPath = Pathes.CheckEndPath(inputId[2]);
                Console.WriteLine(toPath);
                OperationCopy.DirectoryAndFileCopy(fromPath, toPath);
                Info.OperationDoneSuccessfully();
            }
            catch (Exception)
            {
                Info.OperationInfo();
            }
        }

    }
}
