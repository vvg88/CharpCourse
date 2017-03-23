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
            Console.Write("Введите целое положительное число: ");
            //string numAsStr = Console.ReadLine();

            //uint number;
            if (!uint.TryParse(Console.ReadLine(), out uint number))
            {
                Console.WriteLine("Введено некорректное значение!");
                Console.ReadLine();
                return;
            }
            int[] randomArray = new int[number];

            Console.Write("Произвольные числа: ");
            Random randomGen = new Random();

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = randomGen.Next(-100, 100);
                Console.Write(randomArray[i] + " ");
            }
            Console.Write('\n');

            /*byte[] randomBytes = new byte[number];
            randomGen.NextBytes(randomBytes);
            var randomSbytes = randomBytes.Cast<sbyte>();
            sbyte[] randomSbytesArr = (sbyte[])randomSbytes.ToArray();
            foreach (var randomSbyte in randomSbytes)
                Console.Write(randomSbyte + " ");
            Console.Write('\n');*/

            SortArrWithBubbleSort(randomArray);
            Console.Write("Отсортированный массив: ");
            foreach (var randomSbyte in randomArray)
                Console.Write(randomSbyte + " ");
            Console.Write('\n');

            Console.ReadLine();
        }

        static void SortArrWithBubbleSort<T>(T[] inputArr) where T : IComparable<T>
        {
            bool wasSorted;
            do
            {
                wasSorted = false;
                for (int i = 0; i < inputArr.Length - 1; i++)
                {

                    if (inputArr[i].CompareTo(inputArr[i + 1]) > 0)
                    {
                        T tmp = inputArr[i + 1];
                        inputArr[i + 1] = inputArr[i];
                        inputArr[i] = tmp;
                        wasSorted = true;
                    }

                }
            }
            while (wasSorted);
        }
    }
}
