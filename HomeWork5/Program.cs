using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            uint userFaildAttempts;     // Число попыток неудачного ввода параметров
            if (!uint.TryParse(ConfigurationManager.AppSettings["UserAttempts"], out userFaildAttempts))
                throw new Exception("Неверные настройки программы!");

            Console.WriteLine("Создание автомобиля...");

            Console.Write("Введите название автомобиля: ");
            string carModelName = Console.ReadLine();

            uint carWheelsNum;
            if (TryGetUint(userFaildAttempts, "Введите число колес автомобиля: ", out carWheelsNum))
            {

            }
        }

        static bool TryGetUint(uint userAttempts, string message, out uint inputNumber)
        {
            inputNumber = 0;
            bool inputCorrect = false;
            do
            {
                Console.Write(message);
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
