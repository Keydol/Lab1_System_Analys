using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1_System_Analys
{
    public class Matrix
    {
        public int m { set; get; }
        public int n { set; get; }
        public double[,] matrix; // матриця
        public double[,] extendedMatrix; //розширена матриця 

        public int rankMatrix;

        public Matrix(int numM, int numN)
        {
            m = numM;
            n = numN;
            matrix = new double[numM, numN];
        }

        
    }
}
