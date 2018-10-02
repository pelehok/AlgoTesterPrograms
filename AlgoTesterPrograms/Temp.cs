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

            GetLargeSquareKStep(matrix, N, K, 0, 0);

            Console.WriteLine(tempMax);
            Console.ReadKey();
        }

        private static int tempMax = 0;

        public static void GetLargeSquareKStep(char[,] matrix, int n, int k, int indexI, int indexJ)
        {
            if (k == 0)
            {
                int t = GetLargeSquare(matrix, n);
                if (tempMax < t)
                {
                    tempMax = t;
                }
            }
            else
            {
                int nextIIndex = 0;
                int nextJIndex = 0;
                if (GetNextFullCeil(matrix, n, indexI, indexJ, out nextIIndex, out nextJIndex))
                {
                    matrix[nextIIndex, nextJIndex] = emptyCeil;
                    GetLargeSquareKStep(matrix, n, k - 1, nextIIndex, nextJIndex);
                    matrix[nextIIndex, nextJIndex] = fullCeil;
                    if (GetNextCeil(n, nextIIndex, nextJIndex, out nextIIndex, out nextJIndex))
                        GetLargeSquareKStep(matrix, n, k, nextIIndex, nextJIndex);

                }
            }
        }
        public static bool GetNextCeil(int n, int iIndexStart, int jIndexStart, out int iIndex, out int jIndex)
        {
            if (jIndexStart + 1 < n)
            {
                iIndex = iIndexStart;
                jIndex = jIndexStart + 1;
                return true;
            }
            else if (iIndexStart + 1 < n)
            {
                iIndex = iIndexStart + 1;
                jIndex = 0;
                return true;
            }

            iIndex = 0;
            jIndex = 0;
            return false;
        }

        private const char fullCeil = '1';
        private const char emptyCeil = '0';

        public static int GetLargeSquare(char[,] matrix, int n)
        {

            int maxSquare = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != fullCeil)
                    {
                        for (int k = 1; k < n - j; k++)
                        {
                            if (i + k < n && matrix[i + k, j] != fullCeil && j + k < n && matrix[i, j + k] != fullCeil &&
                                IsSquareHave(matrix, i, j, k + 1))
                            {
                                int currentMax = k + 1;
                                if (maxSquare < currentMax)
                                {
                                    maxSquare = currentMax;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return maxSquare;
        }

        public static bool IsSquareHave(char[,] matrix, int iIndexStart, int jIndexStart, int size)
        {

            for (int i = iIndexStart; i < iIndexStart + size; i++)
            {
                for (int j = jIndexStart; j < iIndexStart + size; j++)
                {
                    if (matrix[i, j] != emptyCeil)
                        return false;
                }
            }

            return true;
        }

        public static bool GetNextFullCeil(char[,] matrix, int n, int iIndexStart, int jIndexStart, out int iIndex, out int jIndex)
        {
            for (int i = iIndexStart; i < n; i++)
            {
                if (i != iIndexStart) jIndexStart = 0;
                for (int j = jIndexStart; j < n; j++)
                {
                    if (matrix[i, j] == fullCeil)
                    {
                        iIndex = i;
                        jIndex = j;
                        return true;
                    }
                }
            }
            iIndex = 0;
            jIndex = 0;
            return false;
        }
    }
}
