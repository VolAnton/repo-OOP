using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandList
    {

        public static void Ls(DirectoryInfo curDir)
        {
            try
            {
                DirectoryInformation.GetListOfDirectory(Pathes.CheckEndPath(curDir.FullName));
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
