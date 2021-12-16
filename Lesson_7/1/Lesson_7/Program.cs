using System;
using System.Text;
using MyHomeWork.Core;


namespace Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            //При кодировке буква 'ё' заменяется на 'е', а при декодировке обратно будет всегда 'е'

            ConsoleLogger mes = new ConsoleLogger();

            string test_String = "Привет, Медвед! Это простой текст для провреки правильности работы программы Антона Волощука.";

            mes.ShowMessage("-----=====ACoder=====-----");
            mes.SkippingLines(1);

            ACoder test_ACoder = new ACoder();

            mes.ShowMessage($"Кодируем текст ({test_String}) с помощью ACoder'a и получаем:");
            string str_1A = test_ACoder.Encode(test_String);
            mes.ShowMessage(str_1A);

            mes.SkippingLines(1);

            mes.ShowMessage($"Декодируем текст ({str_1A}) с помощью ACoder'a и получаем:");
            string str_2A = test_ACoder.Decode(str_1A);
            mes.ShowMessage(str_2A);
            mes.SkippingLines(1);
            mes.ShowMessage(str_2A == test_String ? "Вывод: ACoder работает правильно." : "Вывод: ACoder работает неправильно.");
            mes.SkippingLines(1);

            mes.ShowMessage("-----=====BCoder=====-----");
            mes.SkippingLines(1);

            BCoder test_BCoder = new BCoder();

            mes.ShowMessage($"Кодируем текст ({test_String}) с помощью BCoder'a и получаем:");
            string str_1B = test_BCoder.Encode(test_String);
            mes.ShowMessage(str_1B);

            mes.SkippingLines(1);

            mes.ShowMessage($"Декодируем текст ({str_1B}) с помощью BCoder'a и получаем:");
            string str_2B = test_BCoder.Decode(str_1B);
            mes.ShowMessage(str_2B);
            mes.SkippingLines(1);
            mes.ShowMessage(str_2B == test_String ? "Вывод: BCoder работает правильно." : "Вывод: BCoder работает неправильно.");

            Console.ReadKey();
        }
    }
}
