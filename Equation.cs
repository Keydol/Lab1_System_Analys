using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_System_Analys
{
    public class Equation : Matrix // рівняння
    {
        public VectorB vectorB { set; get; }
        public Equation(int m, int n) : base(m, n)
        {
            vectorB = new VectorB(m);
        }

        public int calculateExtendedMatrixRank()
        {
            extendedMatrix = new double[m, n + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (j == n)
                    {
                        extendedMatrix[i, j] = vectorB.elements[i];  
                    }
                    else
                    {
                        extendedMatrix[i, j] = matrix[i, j];
                    }

                }
            }
            return Rank(extendedMatrix);
        }

        public int calculateMatrixRank()
        {
            return Rank(matrix);
        }

        public int Rank(double[,] matrix) // Метод мінорів
        {
            int rang = 0;
            int q = 1;

            while (q <= MinValue(matrix.GetLength(0), matrix.GetLength(1)))
            {
                double[,] matbv = new double[q, q];
                for (int i = 0; i < (matrix.GetLength(0) - (q - 1)); i++)
                {
                    for (int j = 0; j < (matrix.GetLength(1) - (q - 1)); j++)
                    {
                        for (int k = 0; k < q; k++)
                        {
                            for (int c = 0; c < q; c++)
                            {
                                matbv[k, c] = matrix[i + k, j + c];
                            }
                        }

                        if (Determ(matbv) != 0)
                        {
                            rang = q;
                        }
                    }
                }
                q++;
            }

            return rang;
        }

        private double Determ(double[,] matbv) //Метод Гаусса
        {
            double det = 1; // Хранит определитель, который вернёт функция
            int n = matbv.GetLength(0); // Размерность матрицы
            int k = 0;
            const double E = 1E-9; // Погрешность вычислений

            for (int i = 0; i < n; i++)
            {
                k = i;
                for (int j = i + 1; j < n; j++)
                    if (Math.Abs(matbv[j,i]) > Math.Abs(matbv[k, i]))
                        k = j;

                if (Math.Abs(matbv[k, i]) < E)
                {
                    det = 0;
                    break;
                }
                Swap(ref matbv, i, k);

                if (i != k) det *= -1;

                det *= matbv[i, i];

                for (int j = i + 1; j < n; j++)
                    matbv[i, j] /= matbv[i, i];

                for (int j = 0; j < n; j++)
                    if ((j != i) && (Math.Abs(matbv[j, i]) > E))
                        for (k = i + 1; k < n; k++)
                            matbv[j, k] -= matbv[i, k] * matbv[j, i];
            }
            return det;

        }

        public void Swap(ref double[,] M, int row1, int row2)
        {
            double s;

            for (int i = 0; i < M.GetLength(1); i++)
            {
                s = M[row1,i];
                M[row1, i] = M[row2, i];
                M[row2, i] = s;
            }
        }

        private int MinValue(int a, int b)
        {
            if (a >= b)
                return b;
            else
                return a;
        }

    }
}
