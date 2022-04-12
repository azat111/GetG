using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzatRequester
{
    public interface IRequestHandler
    {
        /// <summary>
        /// Обработать запрос.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="arguments">Аргументы запроса.</param>
        /// <returns>Результат выполнения запроса.</returns>
        string HandleRequest(string message, string[] arguments);
    }


    /// <summary>
    /// Тестовый обработчик запросов.
    /// </summary>
    public class DummyRequestHandler : IRequestHandler
    {
        /// <inheritdoc />
        public string HandleRequest(string message, string[] arguments)
        {
            // Притворяемся, что делаем что то.
            Thread.Sleep(10_000);
            if (message.Contains("упади"))
            {
                throw new Exception("Я упал, как сам просил");
            }
            return Guid.NewGuid().ToString("D");
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Приложение запущено");
            Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
           
            string message = Console.ReadLine();

            while (message != "/exit")
            {
                //ввод аргументов
                var arguments = new string[600];
                Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны, введите /end");
                var argument = Console.ReadLine();
                var h = 0;
                while (argument != "/end")
                {
                    arguments[h] = argument;
                    Console.WriteLine("Введите следующий аргумент сообщения. Для окончания добавления аргументов напишите /end");
                    argument = Console.ReadLine();
                    h += 1;
                }
                ThreadPool.QueueUserWorkItem(callBack => HandleRequest(message, arguments));
                Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
                message = Console.ReadLine();

            }
            Console.WriteLine("Приложение завершает работу.");
        }

        public static void HandleRequest(string message, string[] arguments)
        {
            var dummyReq = new DummyRequestHandler();
            var id = Guid.NewGuid().ToString("D");
            Console.WriteLine($"Было отправлено сообщение '{message}'. Присвоен идентификатор {id}");
            try
            {
                var answer = dummyReq.HandleRequest(message, arguments);
                Console.WriteLine($"Сообщение с идентификатором {id} получило ответ {answer}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Сообщение с индефикатором {id} упало с ошибкой: {e.Message} ");
            }
        }
    }
}