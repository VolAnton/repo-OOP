using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;


namespace Lesson_8_FileManager
{
    public sealed class CommandCreateDirectory
    {
        public static void Crd(string[] inputId)
        {
            try
            {
                string newFolder = Pathes.CheckEndPath(inputId[1]);

                if (Exists(newFolder))
                {
                    Console.WriteLine("Папка с таким именем уже существует.");
                    return;
                }

                CreateDirectory(newFolder);

                if (Exists(newFolder))
                {
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
