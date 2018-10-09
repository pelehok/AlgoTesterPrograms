using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Talent_Contest
    {
        public static void Problem(){
            //string[] NK = Console.ReadLine().Split(' ');
            int N = 5;//int.Parse(NK[0]);
            int K = 2;//int.Parse(NK[1]);

            char[,] matrix = new char[N,N];
            //for (int i = 0; i < N; i++)
            //{
            //    string row = Console.ReadLine();
            //    for (int j = 0; j < N; j++)
            //    {
            //        matrix[i, j] = row[j];
            //    }
            //}

            List<string> s = new List<string>()
            {
                "10110",
                "10101",
                "01000",
                "11010",
                "10001"
            };
            for (int i = 0; i < N; i++)
            {
                string row = s[i];
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

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


        public static void Program(int iIndex,int jIndex,char[,] matrix,int n,int k ){
            int maxsize = Math.Min(n - jIndex,n-iIndex);
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

        public static bool IsSquareHaveValueOne(char[,] matrix,int n, int k){
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

        public static char[,] GetMatrix(char[,] matrix, int iIndex, int jIndex, int size){
            char[,] resMatrix= new char[size,size];
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


        public static void GetLargeSquareKStep(char[,] matrix, int n, int k,int indexI,int indexJ){
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
        public static bool GetNextCeil( int n, int iIndexStart, int jIndexStart, out int iIndex, out int jIndex)
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
        public static int GetLargeSquare(char[,] matrix,int n){

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
                                IsSquareHave(matrix,i,j,k+1))
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
        public static bool IsSquareHave(char[,] matrix, int iIndexStart, int jIndexStart, int size){

            for (int i = iIndexStart; i < iIndexStart+size; i++)
            {
                for (int j = jIndexStart; j < iIndexStart + size; j++)
                {
                    if (matrix[i, j] != emptyCeil)
                        return false;
                }
            }

            return true;
        }
        public static bool GetNextFullCeil(char[,] matrix,int n,int iIndexStart,int jIndexStart, out int iIndex,out int jIndex)
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
