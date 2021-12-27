using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class DirectoryInformation
    {
        public static long GetDirectorySize(DirectoryInfo directory, bool includeSubdir)
        {
            long totalSize = 0;
            try
            {
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    totalSize += (long)file.Length;
                }
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    totalSize += GetDirectorySize(dir, true);
                }
                return (long)totalSize;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Отказано в доступе.");
                return (long)totalSize;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка чтения размера файлов.");
                return (long)totalSize;
            }
        }

        public static void GetListOfDirectory(string path)
        {
            string dirName = path;
            if (Directory.Exists(dirName))
            {
                ReportList.reportList.Add("**********************************************************************************************************************");
                ReportList.reportList.Add("Подкаталоги: " + dirName);
                DirectoryInfo dirs = new DirectoryInfo(dirName);
                DirectoryInfo[] getDirs = dirs.GetDirectories();
                ReportList.reportList.Add($"{"Имя папки",-70} {"Размер, байт",15} {"Дата создания",20} {"Тип",-10}");
                foreach (DirectoryInfo s in getDirs)
                {
                    ReportList.reportList.Add($"{s.Name,-70} {DirectoryInformation.GetDirectorySize(s, true),15:N0} {s.CreationTime,20} {s.Attributes,-10} ");
                }
                ReportList.reportList.Add("");
                ReportList.reportList.Add("**********************************************************************************************************************");
                ReportList.reportList.Add("Файлы: " + dirName);
                DirectoryInfo files = new DirectoryInfo(dirName);
                FileInfo[] getFiles = files.GetFiles();
                ReportList.reportList.Add($"{"Имя файла",-70} {"Размер, байт",15} {"Дата создания",20} {"Тип",-10}");
                if (getFiles.Length != 0)
                {
                    for (int i = 0; i < getFiles.Length; i++)
                    {
                        ReportList.reportList.Add($"{getFiles[i].Name,-70} {getFiles[i].Length,15:N0} {getFiles[i].CreationTime,20} {getFiles[i].Attributes,-10} ");
                    }
                }
                else if (getFiles.Length == 0)
                {
                    ReportList.reportList.Add("Данная папка: " + dirName + " не содержит файлов.");
                }
                ReportList.reportList.Add("");
                ReportList.reportList.Add("**********************************************************************************************************************");
                ReportList.reportList.Add("Информация о директории: " + dirName);
                ReportList.reportList.Add("");
                ReportList.reportList.Add($"{"Имя: ",-15} {dirs.Name}");
                ReportList.reportList.Add($"{"Размер: ",-15} {DirectoryInformation.GetDirectorySize(dirs, true):N0} байт");
                ReportList.reportList.Add($"{"Дата создания: ",-15} {dirs.CreationTime}");
                ReportList.reportList.Add($"{"Тип: ",-15} {dirs.Attributes}");
                ReportList.reportList.Add("");
            }
        }

        public static bool IsDirectory(FileSystemInfo fsItem)
        {
            return ((fsItem.Attributes & FileAttributes.Directory) == FileAttributes.Directory);
        }

        public static void PrintTree(string startPath, string prefix = "", int depth = 0)
        {
            try
            {
                if (depth >= Config.GetConfig().MaxDepth)
                {
                    return;
                }
                DirectoryInfo myDir = new DirectoryInfo(startPath);
                FileSystemInfo[] fsItems = myDir.GetFileSystemInfos();
                if (depth == 0)
                {
                    ReportList.reportList.Add(Convert.ToString(myDir.Root));
                }
                foreach (FileSystemInfo fsItem in fsItems)
                {
                    FileSystemInfo lastItem = fsItems[fsItems.Length - 1];
                    if (fsItem != lastItem)
                    {
                        ReportList.reportList.Add(prefix + "├───" + fsItem.Name);
                        if (DirectoryInformation.IsDirectory(fsItem))
                        {
                            PrintTree(fsItem.FullName, prefix + "│   ", depth + 1);
                        }
                    }
                    if (fsItem == lastItem)
                    {
                        if (lastItem != null)
                        {
                            ReportList.reportList.Add(prefix + @"└───" + lastItem.Name);
                            if (DirectoryInformation.IsDirectory(lastItem))
                            {
                                PrintTree(lastItem.FullName, prefix + "    ", depth + 1);
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Отказано в доступе.");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка.");
            }
        }
    }
}
