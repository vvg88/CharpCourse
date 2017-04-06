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
            uint userFaildAttempts;     // Число попыток неудачного ввода параметров получить из настроек
            if (!uint.TryParse(ConfigurationManager.AppSettings["UserAttempts"], out userFaildAttempts))
            {
                Console.WriteLine("Неверные настройки программы!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Создание автомобиля...");
            Console.Write("Введите название автомобиля: ");
            string carModelName = Console.ReadLine();

            uint carWheelsNum;
            if (TryGetUint(userFaildAttempts, "Введите число колес автомобиля: ", out carWheelsNum))
            {
                uint carDoorsNum;
                if (TryGetUint(userFaildAttempts, "Введите число дверей автомобиля: ", out carDoorsNum))
                {
                    Car car = new Car(carModelName, carWheelsNum, carDoorsNum);
                    do
                    {
                        Console.Write("\nВыберите действие: M - Move, O - Open door: ");
                        switch (Console.ReadLine())
                        {
                            case "M":
                                foreach (var detail in car.carDetailsArray)
                                {
                                    (detail as IRotatable)?.Move(car.Model);
                                }
                                break;
                            case "O":
                                uint doorNum;
                                if (TryGetUint(userFaildAttempts, "Введите номер двери или 0 для рамы: ", out doorNum))
                                {
                                    IDoor openableDetail = car.carDetailsArray.Where(detail => detail is IDoor)
                                                              .Cast<IDoor>()
                                                              .SingleOrDefault(idoorItem => doorNum == 0 ? idoorItem is Body : (idoorItem as Door)?.Number == doorNum);
                                    if (openableDetail == null)
                                    {
                                        Console.WriteLine("Введен неверный номер двери!");
                                        break;
                                    }
                                    openableDetail.Open(car.Model);
                                }
                                break;
                            default:
                                Console.WriteLine("Введено неверное действие!");
                                break;
                        }
                        Console.Write("Для повтора введите 'r', для выхода - любой символ : ");
                    }
                    while (Console.ReadLine() == "r");
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Попытаться получить uint с консоли
        /// </summary>
        /// <param name="userAttempts"> Число неудачных попыток пользователя </param>
        /// <param name="message"> Сообщение о запросе </param>
        /// <param name="inputNumber"> Введенное значение </param>
        /// <returns> Результат ввода </returns>
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
