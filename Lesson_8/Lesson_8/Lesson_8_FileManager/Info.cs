using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class Info
    {
        public static void OperationInfo()
        {
            Console.WriteLine("Для выполнения операции воспользуйтесь справкой --help");
        }
        
        public static void OperationDoneSuccessfully()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("*** Операция завершена успешно ***");
            Console.WriteLine(Environment.NewLine);
        }

        public static void OperationUnknown()
        {
            Console.WriteLine("Команда не определена. Для вывода списка команд можете вызвать справку --help.");
        }

        public static void OperationError()
        {
            Console.WriteLine("Ошибка ввода. Для вывода списка команд можете вызвать справку --help.");
        }        
    }
}
