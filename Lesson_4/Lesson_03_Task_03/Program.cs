using System;
using System.IO;
using System.Text;

namespace Lesson_4
{
    class Program
    {
        public static void SearchMail(ref string s)
        {
            string[] temp = s.Split(new char[] { '&', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                int a = temp[i].IndexOf('@');
                if (a != -1)
                {
                    sb.AppendLine(temp[i]);
                }
                else
                {
                    continue;
                }
            }
            s = sb.ToString();            
        }

        static void Main(string[] args)
        {

            string readPath = @"D:\Task_3_3_Read.txt";
            string writePath = @"D:\Task_3_3_Write.txt";
            string s = "";

            try
            {                
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    s = sr.ReadToEnd();
                }

                Console.WriteLine($"Чтение исходного файла прошло успешно. ({readPath})");                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Было до выполненя метода Searchmail:");
            Console.WriteLine();
            Console.WriteLine(s);
            Console.WriteLine();

            //Выполняем метод, выделяющий из строки адрес почты
            SearchMail(ref s);

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(s);
                }

                Console.WriteLine($"Запись нового файла, который содержит адреса почты прошла успешно. ({writePath})");                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Результат работы метода Searchmail:");
            Console.WriteLine();
            Console.WriteLine(s);

            Console.ReadKey();
        }
    }

}
