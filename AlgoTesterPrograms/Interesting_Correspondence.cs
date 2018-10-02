using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Interesting_Correspondence
    {
        public static void Problem(){
            int N = int.Parse(Console.ReadLine());
            string inputMessage = Console.ReadLine();

            int matrixSize = (int)Math.Sqrt(N);
            char[,] matrix = new char[matrixSize, matrixSize];
            int counter = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = inputMessage[counter];
                    counter++;
                }
            }

            string[] res = new string[(matrixSize - 1) * 2 + 1];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    res[i + j] += matrix[i, j];
                }
            }

            string outputMessage = "";
            for (int i = 0; i < res.Length; i++)
            {
                outputMessage += res[i];
            }

            Console.WriteLine(outputMessage);
            Console.ReadKey();
        }
    }
}
