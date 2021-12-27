using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_8_FileManager
{
    public sealed class CommandCount
    {
        public static void Count(string[] inputId)
        {
            try
            {
                string str = "";
                string[] textToCount;
                StreamReader sr = new StreamReader(inputId[1]);

                while (sr.EndOfStream != true)
                {
                    str += sr.ReadLine();
                }
                textToCount = str.Split(' ');
                Console.WriteLine($"Количество слов в файле {inputId[1]}:");
                Console.WriteLine(textToCount.Length);

                sr.Close();

                Info.OperationDoneSuccessfully();
            }
            catch (Exception)
            {
                Info.OperationInfo();
            }
        }
    }
}
