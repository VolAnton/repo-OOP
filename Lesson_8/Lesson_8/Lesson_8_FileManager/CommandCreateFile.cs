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
    public sealed class CommandCreateFile
    {
        public static void Crf(string[] inputId)
        {
            try
            {
                string newFolder = Pathes.CheckEndPath(inputId[1]);
                string newFile = inputId[2];

                string textFile = Combine(newFolder, newFile);

                if (!Exists(newFolder))
                {
                    Console.WriteLine("Папка с таким именем не существует.");
                    return;
                }

                if (File.Exists(textFile))
                {
                    Console.WriteLine("Файл с таким именем уже существует.");
                    return;
                }

                StreamWriter textWriter = File.CreateText(textFile);
                textWriter.WriteLine("Hello, C#!");
                textWriter.Close();

                if (File.Exists(textFile))
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
