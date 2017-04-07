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
                    {7, 8, 9},
                    {10, 11, 12}
                });

            Console.WriteLine("Исходная матрица A:");
            Console.Write(A + "\n");

            //Console.WriteLine("Матрица A + 3:");
            //Console.Write(A + 3 + "\n");

            //Console.WriteLine("Матрица A * 2:");
            //Console.Write(A * 2 + "\n");

            //Console.WriteLine("Исходная матрица B:");
            //Console.Write(B + "\n");

            //Console.WriteLine("Матрица A + B:");
            //Console.Write(A + B + "\n");

            Console.WriteLine("Исходная матрица C:");
            Console.Write(C + "\n");
            Console.WriteLine("Матрица A * C:");
            Console.Write(A * C);

            Console.ReadLine();
        }
    }
}
