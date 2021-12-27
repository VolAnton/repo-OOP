using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandChangeDirectory
    {
        public static void Cd(string [] inputId, string  [] inputId_2, ref string myPath, DirectoryInfo curDir)
        {
            try
            {
                if (inputId.Length == 1)
                {
                    Console.WriteLine("Укажите место назначения. Для вывода списка команд можете вызвать справку --help.");
                }
                else if (inputId.Length == 2)
                {
                    if (inputId[1] == ".")
                    {
                        throw new Exception();
                    }
                    if (inputId[1] == "..")
                    {
                        if (myPath == curDir.Root.ToString())
                        {
                            Console.WriteLine("Ошибка. Вы находитесь в корневом каталоге.");
                            return;
                            //break;
                        }
                        myPath = Pathes.CheckEndPath(curDir.Parent.ToString());
                        return;
                        //break;
                    }
                    if (inputId[1] == "/")
                    {
                        myPath = curDir.Root.ToString();
                        return;
                        //break;
                    }
                    if (inputId[1] == "")
                    {
                        throw new Exception();
                    }
                    if (inputId_2.Length == 1)
                    {
                        throw new Exception();
                    }
                    if (Directory.Exists(inputId[1]))
                    {
                        myPath = Pathes.CheckEndPath(inputId[1]);
                    }
                    else if (Directory.Exists(myPath + inputId[1]))
                    {
                        myPath = Pathes.CheckEndPath(Pathes.CheckEndPath(myPath) + inputId[1]);
                    }
                    else if (Directory.Exists(inputId_2[1]))
                    {
                        myPath = Pathes.CheckEndPath(inputId_2[1]);
                    }
                    else
                    {
                        Console.WriteLine("Указанное место: " + inputId[1] + " не существует.");
                    }
                }
            }
            catch (Exception)
            {
                Info.OperationInfo();
            }
        }
    }
}
