using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandMove
    {
        public static void Mv(string[] inputId)
        {
            try
            {
                string oldPath = Pathes.CheckEndPath(inputId[1]);
                string newPath = Pathes.CheckEndPath(inputId[2]);
                if (inputId.Length == 3)
                {
                    OperationMove.DirectoryAndFileMove(oldPath, newPath);
                    Info.OperationDoneSuccessfully();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Info.OperationInfo();
            }
        }
    }
}
