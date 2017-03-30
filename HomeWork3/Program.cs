using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите строку: ");
                string inputString = Console.ReadLine();
                if (inputString != string.Empty)
                {
                    StringHandler strHandler = new StringHandler(inputString);
                    //Console.WriteLine("Строка " + (strHandler.IsStrPalindrome() ? "является" : "не является") + " палиндромом.");
                    Console.WriteLine($"Строка {(strHandler.IsStrPalindrome() ? "является" : "не является")} палиндромом.");
                    Console.WriteLine($"Число слов в строке: {strHandler.NumberOfWords}");
                    Console.WriteLine($"Перевернутая строка: {strHandler.GetReversedString()}");
                }
                else
                {
                    Console.WriteLine("Пустая строка!");
                }
                Console.WriteLine("Чтобы продолжить, введите любой символ. Для выхода введите q.");
            }
            while (Console.ReadLine() != "q");
        }
    }
}
