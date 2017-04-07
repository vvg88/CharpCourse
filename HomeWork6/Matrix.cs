using System;
using System.Collections;
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
            Array.Copy(inputMatrix, matrix, inputMatrix.Length);
        }

        public Matrix GetTranspose()
        {
            throw new NotImplementedException();
        }

        public double GetDeterminant()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder matrixSb = new StringBuilder();

            for (int i = 0; i < RowsNum; i++)
            {
                for (int j = 0; j < ColumnsNum; j++)
                {
                    matrixSb.Append(matrix[i, j] + " ");
                }
                matrixSb.Append('\n');
            }

            return matrixSb.ToString();
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

        #region Operators

        public static Matrix operator +(Matrix leftOp, Matrix rightOp)
        {
            if ((leftOp.RowsNum != rightOp.RowsNum) || (leftOp.ColumnsNum != rightOp.ColumnsNum))
                throw new ArgumentException("Размеры матриц не совпадают!");

            double[,] resultMatrix = new double[leftOp.RowsNum, leftOp.ColumnsNum];
            for (int i = 0; i < leftOp.RowsNum; i++)
                for (int j = 0; j < leftOp.ColumnsNum; j++)
                    resultMatrix[i, j] = leftOp[i, j] + rightOp[i, j];

            return new Matrix(resultMatrix);
        }

        public static Matrix operator +(Matrix leftOp, double rightOp)
        {
            double[,] resultMatrix = new double[leftOp.RowsNum, leftOp.ColumnsNum];

            for (int i = 0; i < leftOp.RowsNum; i++)
                for (int j = 0; j < leftOp.ColumnsNum; j++)
                    resultMatrix[i, j] = leftOp[i, j] + rightOp;

            return new Matrix(resultMatrix);
        }

        public static Matrix operator *(Matrix leftOp, Matrix rightOp)
        {
            if (leftOp.ColumnsNum != rightOp.RowsNum)
                throw new ArgumentException("Число столбцов множимого не совпадает с числом строк множителя!");

            double[,] resultMatrix = new double[leftOp.RowsNum, rightOp.ColumnsNum];
            for (int m = 0; m < leftOp.RowsNum; m++)
            {
                for (int k = 0; k < rightOp.ColumnsNum; k++)
                {
                    for (int i = 0; i < leftOp.ColumnsNum; i++)
                        resultMatrix[m, k] += leftOp[m, i] + rightOp[i, k];
                }
            }

            return new Matrix(resultMatrix);
        }

        public static Matrix operator *(Matrix leftOp, double rightOp)
        {
            double[,] resultMatrix = new double[leftOp.RowsNum, leftOp.ColumnsNum];

            for (int i = 0; i < leftOp.RowsNum; i++)
                for (int j = 0; j < leftOp.ColumnsNum; j++)
                    resultMatrix[i, j] = leftOp[i, j] * rightOp;

            return new Matrix(resultMatrix);
        }

        #endregion
    }
}
