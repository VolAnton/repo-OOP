using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandFind
    {
        public static void Find(string inputId_1, string inputId_2)
        {
            try
            {
                DirectoryInfo myDir = new DirectoryInfo(inputId_1);
                FileInfo[] fsItems = myDir.GetFiles($"*.{inputId_2}");

                foreach (FileInfo fsItem in fsItems)
                {
                    ReportList.reportList.Add(fsItem.FullName);
                    if (DirectoryInformation.IsDirectory(fsItem))
                    {
                        Find(fsItem.FullName, inputId_2);
                    }
                }

                PrintPaging.GetPrintPaging(Config.GetConfig().PrintPages);

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
