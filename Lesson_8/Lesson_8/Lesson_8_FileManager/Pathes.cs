using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class Pathes
    {
        private static string _startPath = @"startDirectory.cfg";
        private static string _defaultPath = @"C:\";
        private static string _path;

        public static string ReadLastUsePath()
        {
            try
            {
                if (File.Exists(_startPath))
                {
                    _path = File.ReadAllText(_startPath);
                    if (Directory.Exists(_path))
                    {
                        return _path;
                    }
                    else
                    {
                        return _defaultPath;
                    }
                }
                return _defaultPath;
            }
            catch (Exception)
            {
                Console.WriteLine("Стартовый путь задан стандартным");
                return _defaultPath;
            }
        }

        public static void LastUsePath(string path)
        {
            try
            {
                string startPath = @"startDirectory.cfg";
                File.WriteAllText(startPath, $"{path}");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при создании или записи файла со строкой стартовой позиции");
            }
        }

        public static string CutEndFilePath(string path)
        {
            path = path.Substring(0, path.Length - 1);
            return path;
        }
        public static string CheckEndPath(string path)
        {
            if (path.Substring(path.Length - 1) != "\\")
            {
                path += @"\";
            }
            return path;
        }
    }
}
