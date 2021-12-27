using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandFile
    {
        public static void GetFileInfo(string [] inputId)
        {
            try
            {
                FileInformation.GetFileInfo(Pathes.CheckEndPath(inputId[1]));
                PrintPaging.GetPrintPaging(Config.GetConfig().PrintPages);
                Info.OperationDoneSuccessfully();
            }
            catch (Exception)
            {
                Info.OperationInfo();
            }
        }
    }
}
