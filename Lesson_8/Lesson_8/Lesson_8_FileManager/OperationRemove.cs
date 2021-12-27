using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class OperationRemove
    {
        public static void DirectoryAndFileRemove(string path)
        {
            try
            {
                string filePath = Pathes.CutEndFilePath(path);
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    Console.WriteLine($"Указанная директория {path} удалена");
                }
                else if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Указанный файл {filePath} удален");
                }
                else
                {
                    Console.WriteLine("Указанный путь не существует");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка удаления");
            }
        }
    }
}
