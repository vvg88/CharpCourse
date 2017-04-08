using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Utils
    {
        /// <summary>
        /// Попытаться получить uint с консоли
        /// </summary>
        /// <param name="userAttempts"> Число неудачных попыток пользователя </param>
        /// <param name="message"> Сообщение о запросе </param>
        /// <param name="inputNumber"> Введенное значение </param>
        /// <returns> Результат ввода </returns>
        public static bool TryGetUint(uint userAttempts, string message, out uint inputNumber)
        {
            inputNumber = 0;
            bool inputCorrect = false;
            do
            {
                Console.Write(message + ": ");
                if (uint.TryParse(Console.ReadLine(), out inputNumber))
                {
                    inputCorrect = true;
                    break;
                }
                Console.WriteLine("Введено неверное значение! Попробуйте еще раз.");
            }
            while (userAttempts-- != 0);
            return inputCorrect;
        }
    }
}
