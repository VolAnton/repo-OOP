using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class CommandDisk
    {
        public static void Disk(string input, ref string myPath)
        {
            string readCommandDisk = input.Substring(0, 2); ;
            int count = 0;
            string disk = readCommandDisk.ToUpper();
            disk = Pathes.CheckEndPath(disk);
            DriveInfo[] getDrives = DriveInfo.GetDrives();
            for (int i = 0; i < getDrives.Length; i++)
            {
                if (disk == getDrives[i].Name & getDrives[i].IsReady)
                {
                    myPath = disk;
                    count = 1;
                    break;
                }
                else if (disk == getDrives[i].Name & !getDrives[i].IsReady)
                {
                    Console.WriteLine($"Диск {disk} не готов.");
                    count = 1;
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"Диск {disk} не существует.");
            }
        }
    }
}
