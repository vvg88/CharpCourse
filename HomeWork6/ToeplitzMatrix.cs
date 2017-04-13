using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class ToeplitzMatrix : Matrix
    {
        private double[] firstRow;
        private double[] firstColumn;
        
        /// <summary>
        /// Если первый элемент строки и столбца совпадают, то их длины должны быть одинаковыми.
        /// В противном случае длина столбца должны быть на 1 меньше.
        /// В любом другом случае будет брошено <see cref="ArgumentException"/>
        /// </summary>
        /// <param name="firstRow"> Первая строка матрицы Тёплица </param>
        /// <param name="firstColumn"> Первая колонка матрицы Тёплица. </param>
        public ToeplitzMatrix(double[] firstRow, double[] firstColumn)
        {
            if ((firstRow[0] != firstColumn[0] && firstRow.Length != firstColumn.Length + 1)
                || (firstRow[0] == firstColumn[0] && firstRow.Length != firstColumn.Length))
                throw new ArgumentException("Неверные размеры инициализирующих массивов!");

            this.firstRow = new double[firstRow.Length];
            this.firstColumn = new double[firstRow.Length];
            Array.Copy(firstRow, this.firstRow, firstRow.Length);
            if (firstRow[0] == firstColumn[0])
                Array.Copy(firstColumn, 1, this.firstColumn, 1, firstColumn.Length - 1);
            else
                Array.Copy(firstColumn, 0, this.firstColumn, 1, firstColumn.Length);

            RowsNum = ColumnsNum = firstRow.Length;
        }

        public override double this[int i, int j]
        {
            get
            {
                var indx = i - j;
                if (indx <= 0)
                    return firstRow[Math.Abs(indx)];
                else
                    return firstColumn[indx];
            }
        }

        protected override Matrix multiplyWith(Matrix rightMtrx)
        {
            if (ColumnsNum != rightMtrx.RowsNum)
                throw new ArgumentException("Число столбцов множимого не совпадает с числом строк множителя!");

            double[,] resultMatrix = new double[this.RowsNum, rightMtrx.ColumnsNum];
            for (int m = 0; m < RowsNum; m++)
            {
                for (int k = 0; k < rightMtrx.ColumnsNum; k++)
                {
                    {
                        if (m == 0 || k == 0)   // Для нулевой строки/столбца алгоритм стандартен
                        {
                            for (int i = 0; i < this.ColumnsNum; i++)
                                resultMatrix[m, k] += this[m, i] * rightMtrx[i, k];
                        }
                        else                 
                        {
                            resultMatrix[m, k] = resultMatrix[m - 1, k - 1]                 // Иначе берется предыдущий по диагонали элемент,
                                                 + this[m, 0] * rightMtrx[0, k]             // прибавляется произведение нулевых элементов в текущей строке множимого и столбце множителя
                                                 - this[m - 1, ColumnsNum - 1] * rightMtrx[rightMtrx.RowsNum - 1, k - 1];       // и вычитается произведение последних элементов в текущей строке множимого и столбце множителя
                        }
                    }
                }
            }
            return new Matrix(resultMatrix);
        }

        protected override Matrix multiplyBy(double number)
        {
            var row = new double[firstRow.Length];
            firstRow.CopyTo(row, 0);
            var col = new double[firstColumn.Length - 1];
            firstColumn.CopyTo(col, 1);
            Array.ForEach(row, item => item *= number);
            Array.ForEach(col, item => item *= number);
            return new ToeplitzMatrix(row, col);
        }
    }
}
