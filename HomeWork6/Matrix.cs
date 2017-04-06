using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Matrix
    {
        private double[,] matrix;
        private int RowsNum { get; }
        private int ColumnsNum { get; }

        public Matrix(double[,] inputMatrix)
        {
            if (inputMatrix.Rank != 2)
                throw new ArgumentException("Размерность переданной матрицы не равна 2!");

            RowsNum = inputMatrix.GetLength(0);
            ColumnsNum = inputMatrix.GetLength(1);
            matrix = new double[RowsNum, ColumnsNum];
            inputMatrix.CopyTo(matrix, 0);
        }

        public Matrix GetTranspose()
        {
            throw new NotImplementedException();
        }

        public double GetDeterminant()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get
            {
                if (i >= RowsNum)
                    throw new ArgumentOutOfRangeException("Индекс строки выходит за допустимый диапазон!");
                if (j >= ColumnsNum)
                    throw new ArgumentOutOfRangeException("Индекс столбца выходит за допустимый диапазон!");

                return matrix[i,j];
            }
        }

        public static Matrix operator +(Matrix leftOp, Matrix rightOp)
        {

            throw new NotImplementedException();
        }

        public static Matrix operator +(Matrix leftOp, double rightOp)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator *(Matrix leftOp, Matrix rightOp)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator *(Matrix leftOp, double rightOp)
        {
            throw new NotImplementedException();
        }
    }
}
