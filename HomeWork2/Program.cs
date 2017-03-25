using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите целое положительное число: ");
                uint number;
                if (!uint.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Введено некорректное значение!");
                    Console.ReadLine();
                    return;
                }
                int[] randomArray = new int[number];

                Console.Write("Произвольные числа: ");
                Random randomGen = new Random();

                for (int i = 0; i < randomArray.Length; i++)    // Заполнить массив случайными числами от -100 до 100
                {
                    randomArray[i] = randomGen.Next(-100, 100);
                    Console.Write(randomArray[i] + " ");
                }
                Console.Write('\n');

                SortArrWithBubbleSort(randomArray);
                Console.Write("Отсортированный массив: ");  // Вывести отсортированный массив
                foreach (var randomSbyte in randomArray)
                    Console.Write(randomSbyte + " ");
                Console.Write('\n');

                Console.WriteLine("Чтобы продолжить, введите любой символ. Для выхода введите q.");
            }
            while (Console.ReadLine() != "q");

            #region Уточнить
            /*byte[] randomBytes = new byte[number];
            randomGen.NextBytes(randomBytes);
            var randomSbytes = randomBytes.Cast<sbyte>();
            sbyte[] randomSbytesArr = (sbyte[])randomSbytes.ToArray();
            foreach (var randomSbyte in randomSbytes)
                Console.Write(randomSbyte + " ");
            Console.Write('\n');*/
            #endregion
        }

        /// <summary>
        /// Метод пузырьковой сортировки массива
        /// </summary>
        /// <typeparam name="T"> Тип передаваемого массива должен реализовывать <see cref="IComparable{T}"/></typeparam>
        /// <param name="inputArr"> Сортируемый массив </param>
        static void SortArrWithBubbleSort<T>(T[] inputArr) where T : IComparable<T>
        {
            int cnt = inputArr.Length - 1;  // Счетчик внутреннего цикла
            do
            {
                int newCnt = 0;
                for (int i = 0; i < cnt; i++)
                {

                    if (inputArr[i].CompareTo(inputArr[i + 1]) > 0)     // Если младший больше старшего эл-та
                    {
                        Swap(ref inputArr[i], ref inputArr[i + 1]);     // Поменять их местами и присвоить новый счетчик цикла
                        newCnt = i;
                    }
                }
                cnt = newCnt;
            }
            while (cnt != 0);   // Цикл, пока не будет произведена последняя сортировка
        }

        /// <summary>
        /// Метод, меняющий местами два значния, переданные по ссылке
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstItem"></param>
        /// <param name="secItem"></param>
        static void Swap<T>(ref T firstItem, ref T secItem)
        {
            var tmp = firstItem;
            firstItem = secItem;
            secItem = tmp;
        }
    }
}
