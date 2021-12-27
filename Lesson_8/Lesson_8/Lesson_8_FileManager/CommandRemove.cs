using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandRemove
    {
        public static void Rm(string [] inputId)
        {
            try
            {
                string deletePath = Pathes.CheckEndPath(inputId[1]);
                OperationRemove.DirectoryAndFileRemove(deletePath);
                Info.OperationDoneSuccessfully();
            }
            catch (Exception)
            {
                Info.OperationInfo();
            }
        }
    }
}
