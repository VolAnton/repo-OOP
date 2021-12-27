using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandTree
    {
        public static void Tree(DirectoryInfo curDir)
        {
            try
            {
                DirectoryInformation.PrintTree(Pathes.CheckEndPath(curDir.FullName));
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
