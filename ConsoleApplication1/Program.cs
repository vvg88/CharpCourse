using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                uint[] numbers = GetThreeUints();   // Получить три числа

                Console.WriteLine("Наименьшее число: " + numbers.Min());    // Вывести наименьшее

                for (int i = 0; i < numbers.Length; i++)
                {
                    uint[] fibonachiLine = GetFibonachiLine(numbers[i]);    // Получить последовательность Фибоначи
                    
                    string fibStr = string.Empty;
                    for (int j = 0; j < fibonachiLine.Length; j++)          // Преобразовать посл-ть в строку чисел, разделенных пробелами
                    {
                        fibStr = fibStr + fibonachiLine[j].ToString() + " ";
                    }
                    if (fibStr != string.Empty)
                        Console.WriteLine(fibStr);      // Вывести на экран
                }
                Console.WriteLine("Чтобы продолжить, введите любой символ. Для выхода введите q.");
            }
            while (Console.ReadLine() != "q");
        }

        /// <summary>
        /// Метод получения трех неотрицательных чисел
        /// </summary>
        /// <returns> Массив значений </returns>
        static uint[] GetThreeUints()
        {
            while (true)
            {
                Console.WriteLine("Введите три целых неотрицательных числа.");
                string digitsLine = Console.ReadLine();
                string[] digitsArray = ParseString(digitsLine);     // Получить подстроки с числами

                if (digitsArray.Length == 3)
                {
                    uint[] numsArray = new uint[3];
                    bool parseIsBad = false;
                    for (int i = 0; i < digitsArray.Length; i++)    // Попробовать отпарсить полученные значения
                    {
                        uint digit;
                        if (uint.TryParse(digitsArray[i], out digit))
                        {
                            numsArray[i] = digit;
                        }
                        else
                        {
                            Console.WriteLine("Число " + digitsArray[i] + " введено неверно.");
                            parseIsBad = true;
                            break;
                        }
                    }
                    if (!parseIsBad)
                    {
                        return numsArray;       // При успешном парсинге вернуть результат
                    }
                }
                else
                {
                    Console.WriteLine("Количество чисел не равно трем!");
                }
            }
        }

        /// <summary>
        /// Из строки вернуть подстроки, разделенные любым числом пробелов
        /// </summary>
        /// <param name="inputStr"> Входная строка </param>
        /// <returns> Массив подстрок </returns>
        static string[] ParseString(string inputStr)
        {
            List<string> stringsList = new List<string>();
            bool isParseSpace = true;       // Признак, что парсятся пробелы
            string tmpStr = string.Empty;
            for (int i = 0; i < inputStr.Length; i++)       // Пройти по входной строке
            {
                if (inputStr[i] != ' ')
                {
                    isParseSpace = false;
                    tmpStr += inputStr[i].ToString()[0];
                    if (i == inputStr.Length - 1)       // На последнем элементе сохранить результат
                        stringsList.Add(tmpStr);
                }
                else
                {
                    if (!isParseSpace)      // Если пробел после любого другого символа
                    {
                        stringsList.Add(tmpStr);
                        tmpStr = string.Empty;
                        isParseSpace = true;
                    }
                }
            }

            return stringsList.ToArray();
        }

        /// <summary>
        /// Получить последовательность Фибоначи, последний элемент которой меньше переданного параметра
        /// </summary>
        /// <param name="lessThan"></param>
        /// <returns></returns>
        static uint[] GetFibonachiLine(uint lessThan)
        {
            uint fibIndx = 0;
            List<uint> fibList = new List<uint>();
            uint fibItem = 0;

            while ((fibItem = GetFibonachiNum(fibIndx++)) < lessThan) // Получать и сохранять числа из посл-ти Фибоначи, пока они меньше значения параметра
                fibList.Add(fibItem);
            return fibList.ToArray();
        }

        /// <summary>
        /// Получить число из последовательности Фибоначи по указанному индексу
        /// </summary>
        /// <param name="indx"> Индекс последовательности </param>
        /// <returns> Число из последовательности Фибоначи </returns>
        static uint GetFibonachiNum(uint indx)
        {
            if (indx == 0)
                return 0;
            else
            {
                if (indx == 1)
                    return 1;
                else
                    return GetFibonachiNum(indx - 1) + GetFibonachiNum(indx - 2);
            }
        }
    }
}
