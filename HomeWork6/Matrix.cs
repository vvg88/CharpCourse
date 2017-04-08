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
        public int RowsNum { get; protected set; }
        public int ColumnsNum { get;  protected set;}

        public Matrix(double[,] inputMatrix)
        {
            if (inputMatrix.Rank != 2)
                throw new ArgumentException("Размерность переданной матрицы не равна 2!");

            RowsNum = inputMatrix.GetLength(0);
            ColumnsNum = inputMatrix.GetLength(1);
            matrix = new double[RowsNum, ColumnsNum];
            Array.Copy(inputMatrix, matrix, inputMatrix.Length);
        }

        public Matrix() { }

        public virtual Matrix GetTranspose()
        {
            double[,] transposedMtrx = new double[ColumnsNum, RowsNum];
            for (int i = 0; i < RowsNum; i++)
            {
                for (int j = 0; j < ColumnsNum; j++)
                {
                    transposedMtrx[j, i] = this[i, j];
                }
            }
            return new Matrix(transposedMtrx);
        }

        public virtual double GetDeterminant()
        {
            if (RowsNum != ColumnsNum)
                throw new ArgumentException("Матрица должна быть квадратной!");

            // Методом Гаусса привести матрицу к треугольной
            for (int k = 0; k < ColumnsNum - 1; k++)
            {
                for (int j = k + 1; j < RowsNum; j++)
                {
                    var divider = this[j, k] / this[k, k];
                    for (int i = 0; i < ColumnsNum; i++)
                    {
                        this[j, i] = this[j, i] - divider * this[k, i];
                    }
                }
            }
            double result = 1;
            for (int i = 0; i < RowsNum; i++)   // Вычислить определитель как произведение элементов на главной диагонали
            {
                result *= this[i, i];
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder matrixSb = new StringBuilder();

            for (int i = 0; i < RowsNum; i++)
            {
                for (int j = 0; j < ColumnsNum; j++)
                {
                    matrixSb.Append(this[i, j] + " ");
                }
                matrixSb.Append('\n');
            }

            return matrixSb.ToString();
        }

        /// <summary>
        /// Перемножение текущей матрицы с переданной
        /// </summary>
        /// <param name="rightMtrx"> Матрица-множитель </param>
        /// <returns> Произведение </returns>
        protected virtual Matrix multiplyWith(Matrix rightMtrx)
        {
            if (this.ColumnsNum != rightMtrx.RowsNum)
                throw new ArgumentException("Число столбцов множимого не совпадает с числом строк множителя!");

            double[,] resultMatrix = new double[this.RowsNum, rightMtrx.ColumnsNum];
            for (int m = 0; m < this.RowsNum; m++)
            {
                for (int k = 0; k < rightMtrx.ColumnsNum; k++)
                {
                    for (int i = 0; i < this.ColumnsNum; i++)
                        resultMatrix[m, k] += this[m, i] * rightMtrx[i, k];
                }
            }

            return new Matrix(resultMatrix);
        }

        /// <summary>
        /// Элемент матрицы
        /// </summary>
        /// <param name="i"> Номер строки </param>
        /// <param name="j"> Номер столбца </param>
        /// <exception cref="ArgumentOutOfRangeException"> Номер строки или столбца выходит за диапазон </exception>
        /// <returns></returns>
        public virtual double this[int i, int j]
        {
            get
            {
                if (i >= RowsNum)
                    throw new ArgumentOutOfRangeException("Индекс строки выходит за допустимый диапазон!");
                if (j >= ColumnsNum)
                    throw new ArgumentOutOfRangeException("Индекс столбца выходит за допустимый диапазон!");

                return matrix[i, j];
            }
            private set
            {
                if (i >= RowsNum)
                    throw new ArgumentOutOfRangeException("Индекс строки выходит за допустимый диапазон!");
                if (j >= ColumnsNum)
                    throw new ArgumentOutOfRangeException("Индекс столбца выходит за допустимый диапазон!");

                matrix[i, j] = value;
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
            return leftOp.multiplyWith(rightOp);
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
