using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Temp
    {
        //static void Main(string[] args)
        //{
        //    Problem();
        //}
        public static void Problem()
        {
            string[] NK = Console.ReadLine().Split(' ');
            int N = int.Parse(NK[0]);
            int K = int.Parse(NK[1]);

            char[,] matrix = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            //List<string> s = new List<string>()
            //{
            //    "10100",
            //    "00000",
            //    "00010",
            //    "00000",
            //    "10001"
            //};
            //for (int i = 0; i < N; i++)
            //{
            //    string row = s[i];
            //    for (int j = 0; j < N; j++)
            //    {
            //        matrix[i, j] = row[j];
            //    }
            //}

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Program(i, j, matrix, N, K);
                }
            }

            Console.WriteLine(tempMax);
            Console.ReadKey();
        }
        private static int tempMax = 0;
        private static int iIndexMax = 0;
        private static int jIndexMax = 0;
        private const char fullCeil = '1';
        private const char emptyCeil = '0';

        public static void Program(int iIndex, int jIndex, char[,] matrix, int n, int k)
        {
            int maxsize = Math.Min(n - jIndex, n - iIndex);
            for (int i = 1; i <= maxsize; i++)
            {
                var resMatrix = GetMatrix(matrix, iIndex, jIndex, i);
                if (IsSquareHaveValueOne(resMatrix, i, k))
                {
                    if (tempMax < i)
                    {
                        tempMax = i;
                        iIndexMax = iIndex;
                        jIndexMax = jIndex;
                    }
                }
            }
        }

        public static bool IsSquareHaveValueOne(char[,] matrix, int n, int k)
        {
            int couter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == fullCeil) couter++;
                }
            }

            if (couter == k) return true;

            return false;
        }

        public static char[,] GetMatrix(char[,] matrix, int iIndex, int jIndex, int size)
        {
            char[,] resMatrix = new char[size, size];
            int iIndexResMatrix = 0;
            for (int i = iIndex; i < iIndex + size; i++)
            {
                var jIndexResMatrix = 0;
                for (int j = jIndex; j < jIndex + size; j++)
                {
                    resMatrix[iIndexResMatrix, jIndexResMatrix] = matrix[i, j];
                    jIndexResMatrix++;
                }

                iIndexResMatrix++;
            }
            return resMatrix;
        }
    }
}
