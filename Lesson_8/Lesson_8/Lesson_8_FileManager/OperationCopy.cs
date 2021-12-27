using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class OperationCopy
    {
        public static void DirectoryAndFileCopy(string sourcePath, string destinationPath)
        {
            string filePathSource = Pathes.CutEndFilePath(sourcePath);
            string filePathDestination = Pathes.CutEndFilePath(destinationPath);
            if (Directory.Exists(sourcePath))
            {
                DirectoryInfo dirs = new DirectoryInfo(sourcePath);
                foreach (DirectoryInfo dir in dirs.GetDirectories())
                {
                    try
                    {
                        if (Directory.Exists(destinationPath + dir.Name) != true)
                        {
                            Directory.CreateDirectory(destinationPath + dir.Name);
                        }
                        DirectoryAndFileCopy(dir.FullName, destinationPath + dir.Name);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка копирования папок");
                    }
                }
                foreach (string fileName in Directory.GetFiles(sourcePath))
                {
                    try
                    {
                        string fLink = fileName.Substring(fileName.LastIndexOf('\\'), fileName.Length - fileName.LastIndexOf('\\'));
                        File.Copy(fileName, destinationPath + fLink, true);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка копирования файлов");
                    }
                }
            }
            else if (File.Exists(filePathSource))
            {
                try
                {
                    File.Copy(filePathSource, filePathDestination, true);
                    Console.WriteLine($"Указанный файл {filePathSource} скопирован");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка копирования файлов");
                }
            }
            else
            {
                Console.WriteLine("Указанный путь не существует");
            }
        }
    }
}
