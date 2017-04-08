using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

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
            if (Utils.Utils.TryGetUint(userFaildAttempts, "Введите число колес автомобиля: ", out carWheelsNum))
            {
                uint carDoorsNum;
                if (Utils.Utils.TryGetUint(userFaildAttempts, "Введите число дверей автомобиля: ", out carDoorsNum))
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
                                if (Utils.Utils.TryGetUint(userFaildAttempts, "Введите номер двери или 0 для рамы: ", out doorNum))
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
    }
}
