using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_System_Analys
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===Дослiдження систем лiнiйних алгебраїчних рiвнянь===\n");

            int m; //кількість рівнянь
            int n; //кільклість невідомих

            Console.Write("Введiть кiлькiсть рiвнянь: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введiть кiлькiсть невiдомих: ");
            n = Convert.ToInt32(Console.ReadLine());

            Equation equation = setMatrix(m, n);
            equation.vectorB = setVector(m);

            showEquation(equation);
            showMatrix(equation);
            showExtendedMatrix(equation);

            int extendedMatrixRank = equation.calculateExtendedMatrixRank();
            int matrixRank = equation.calculateMatrixRank();

            Console.WriteLine($"\n===Методом мiнорiв===");
            Console.WriteLine($"Ранг основної матрицi: {matrixRank}");
            Console.WriteLine($"Ранг розширеної матрицi: {extendedMatrixRank}");

            Console.WriteLine($"\n===За теоремою Кронекера-Капеллi===");
            Console.Write("Система лiнiйних рiвнянь ");

            if (matrixRank == extendedMatrixRank) Console.WriteLine("СУМIСНА ");
            else Console.WriteLine("НЕ СУМIСНА ");

            if(matrixRank == extendedMatrixRank && matrixRank == n) Console.WriteLine("МАЄ ОДИН ЄДИНИЙ РОЗВ\'ЯЗОК");
            else if (matrixRank == extendedMatrixRank && matrixRank < n) Console.WriteLine("МАЄ БЕЗЛIЧ РОЗВ\'ЯЗКIВ");
            else Console.WriteLine("НЕ МАЄ РОЗВ\'ЯЗКIВ");

            Console.ReadLine();
        }

        private static void showExtendedMatrix(Equation equation)
        {
            Console.WriteLine("\n===Розширена матриця===");
            for (int i = 0; i < equation.m; i++)
            {
                for (int j = 0; j < equation.n; j++)
                {
                    Console.Write($"{equation.matrix[i, j]} ");
                }
                Console.WriteLine($"| {equation.vectorB.elements[i]}");
            }
        }

        private static void showEquation(Equation equation)
        {
            Console.WriteLine("\n===Система рiвнянь===");
            for(int i = 0; i < equation.m; i++)
            {
                for(int j = 0; j < equation.n; j++)
                {
                    Console.Write($"{equation.matrix[i, j]}*x{j}");
                    if(j != equation.n - 1)
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.Write($" = {equation.vectorB.elements[i]}\n");
                    }
                }
            }
        }

        private static VectorB setVector(int m)
        {
            VectorB vector = new VectorB(m);
            Console.WriteLine();
            for(int i = 0; i < m; i++)
            {
                Console.Write($"Елемент вектора {i + 1}: ");
                vector.elements[i] = Convert.ToDouble(Console.ReadLine());
            }

            return vector;
        }

        private static Equation setMatrix(int m, int n)
        {
            Equation equation = new Equation(m, n);
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент матрицi a({i + 1} {j + 1}): ");
                    equation.matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            return equation;
        }

        private static void showMatrix(Equation equation)
        {
            Console.WriteLine("\n===Матриця===");
            for(int i = 0; i < equation.m; i++)
            {
                for(int j = 0; j < equation.n; j++)
                {
                    Console.Write($"{equation.matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
