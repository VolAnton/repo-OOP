using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class PrintPaging
    {

        public static void GetPrintPaging(int printPages)
        {
            int counter = 0;
            int page = 0;
            Console.Clear();
            for (int i = 0; i < ReportList.reportList.Count; i++)
            {
                Console.WriteLine(ReportList.reportList[i]);
                counter++;
                if (counter % printPages == 0)
                {
                    page++;
                    Console.WriteLine();
                    Console.WriteLine("Распечатана " + page + " стр. из " + Math.Ceiling((double)(ReportList.reportList.Count) / printPages) + " страниц");
                    Console.WriteLine("Press Enter to continue, or type \"q\" to stop printing.");
                    string answer = Console.ReadLine();
                    if (answer == "q")
                    {
                        break;
                    }
                    Console.Clear();
                }
            }
            ReportList.reportList.Clear();
        }
    }
}
