using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class OperationMove
    {
        public static void DirectoryAndFileMove(string oldPath, string newPath)
        {
            try
            {
                string filePathOld = Pathes.CutEndFilePath(oldPath);
                string filePathNew = Pathes.CutEndFilePath(newPath);
                if (Directory.Exists(oldPath))
                {
                    Directory.Move(oldPath, newPath);
                    if (filePathOld.Substring(0, filePathOld.LastIndexOf('\\')) == filePathNew.Substring(0, filePathNew.LastIndexOf('\\')))
                    {
                        Console.WriteLine("Директория переименована");
                    }
                    else
                    {
                        Console.WriteLine("Директория перемещена");
                    }
                }
                else if (File.Exists(filePathOld))
                {
                    File.Move(filePathOld, filePathNew);
                    Path.GetFullPath(filePathOld);
                    if (filePathOld.Substring(0, filePathOld.LastIndexOf('\\')) == filePathNew.Substring(0, filePathNew.LastIndexOf('\\')))
                    {
                        Console.WriteLine("Файл переименован");
                    }
                    else
                    {
                        Console.WriteLine("Файл перемещен");
                    }
                }
                else
                {
                    Console.WriteLine("Указанный путь не существует");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка пути");
            }
        }
    }
}
