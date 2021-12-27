using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using MyHomeWork.Core;



namespace Lesson_8_FileManager
{
    class Program
    {
        // Глубина пейджинга MaxDepth. Задается файлом config.json
        // Постраничный вывод информации PrintPages, число строк на странице. Задается файлом config.json

        static void Main(string[] args)
        {
            ConsoleLogger mes = new ConsoleLogger();
            mes.ShowMessage("Вас приветствует программа Файловый Менеджер студента GeekBrains курса ООП Антона Волощука. Приятной работы!");
            mes.SkippingLines(1);

            string input;
            string myPath = Pathes.CheckEndPath(Pathes.ReadLastUsePath());
            bool isExit = false;
            char[] sep = { ' ' };
            char[] sep2 = { ' ', '.', '\\', '/' };
            DirectoryInfo curDir = new DirectoryInfo(myPath);

            do
            {
                try
                {
                    curDir = new DirectoryInfo(myPath);
                    Console.Write(curDir.FullName + " > ");
                    input = Console.ReadLine();
                    string[] inputId = input.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    string[] inputId_2 = input.Split(sep2, StringSplitOptions.RemoveEmptyEntries);

                    if (input.Length == 0)
                    {
                        continue;
                    }

                    if (input.Length == 2)
                    {
                        if (input.Substring(input.Length - 1) == ":")
                        {
                            inputId[0] = "disk";
                        }
                    }

                    switch (inputId[0])
                    {
                        case "disk":
                            CommandDisk.Disk(input, ref myPath);
                            break;
                        case "cd":
                            CommandChangeDirectory.Cd(inputId, inputId_2, ref myPath, curDir);
                            break;
                        case "mv":
                            CommandMove.Mv(inputId);
                            break;
                        case "rm":
                            CommandRemove.Rm(inputId);
                            break;
                        case "cp":
                            CommandCopy.Cp(inputId);
                            break;
                        case "tree":
                            CommandTree.Tree(curDir);
                            break;
                        case "--help":
                            CommandHelp.HelpListPrint();
                            break;
                        case "exit":
                            CommandExit.Exit(ref isExit, curDir);
                            break;
                        case "file":
                            CommandFile.GetFileInfo(inputId);
                            break;
                        case "ls":
                            CommandList.Ls(curDir);
                            break;
                        case "crd":
                            CommandCreateDirectory.Crd(inputId);
                            break;
                        case "crf":
                            CommandCreateFile.Crf(inputId);
                            break;
                        case "find":
                            CommandFind.Find(inputId[1], inputId[2]);
                            break;
                        case "count":
                            CommandCount.Count(inputId);
                            break;
                        default:
                            Info.OperationUnknown();
                            break;
                    }
                }
                catch (Exception)
                {
                    Info.OperationError();
                }
            }
            while (!isExit);

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }
    }
}
