using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix A = new Matrix(new double[,]
                {
                    {1, 2},
                    {3, 4},
                    {5, 6}
                });
            Matrix B = new Matrix(new double[,]
                {
                    {7, 8},
                    {9, 10},
                    {11, 12}
                });
            Matrix C = new Matrix(new double[,]
                {
                    {-7, 8, 9},
                    {10, 11, 12}
                });
            Matrix D = new Matrix(new double[,]
                {
                    {-7, 8, 9},
                    {10, 11, 12},
                    {1, 2, -100}
                });

            Console.WriteLine("Исходная матрица A:");
            Console.WriteLine(A);

            Console.WriteLine("Матрица A + 3:");
            Console.WriteLine(A + 3);

            Console.WriteLine("Матрица A * 2:");
            Console.WriteLine(A * 2);

            Console.WriteLine("Матрица A транспонированная:");
            Console.WriteLine(A.GetTranspose());

            Console.WriteLine("Исходная матрица B:");
            Console.WriteLine(B);

            Console.WriteLine("Матрица A + B:");
            Console.WriteLine(A + B);

            Console.WriteLine("Исходная матрица C:");
            Console.WriteLine(C);

            Console.WriteLine("Матрица A * C:");
            Console.WriteLine(A * C);

            Console.WriteLine("Исходная матрица D:");
            Console.WriteLine(D);

            Console.WriteLine("Определитель матрицы D:");
            Console.Write(D.GetDeterminant() + "\n");

            Matrix tA = new ToeplitzMatrix(new double[] { 1, 2, 3, 4 }, new double[] { 5, 7, 9 });
            Matrix tB = new ToeplitzMatrix(new double[] { 5, 73, -9, 1 }, new double[] { -5, 57, -19 });

            Console.WriteLine("Матрица Тёплица tA:");
            Console.WriteLine(tA);

            Console.ReadLine();
        }

        //private Matrix CreateMatrix(bool isToeplitz)
        //{
        //    if (!isToeplitz)
        //    {
        //        double[,] matrix;
        //        uint rowsNum;
        //        if (Utils.Utils.TryGetUint(10, "Введите число строк", out rowsNum))
        //        {
        //            uint colsNum;
        //            if (Utils.Utils.TryGetUint(10, "Введите число столбцов", out colsNum))
        //            {
        //                matrix = new double[rowsNum, colsNum];

        //            }
        //        }
        //    }
        //    else
        //    {

        //    }
        //}

        static Random rndGen = new Random();
    }
}
