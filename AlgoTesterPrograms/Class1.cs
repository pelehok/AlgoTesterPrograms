using System;
using System.Collections.Generic;

namespace AlgoTesterPrograms
{
    class Class1
    {
        public static int N;
        public static int M;
        static double step = 10e-8;

        public static void Main1(String[] args){
            string[] NK = Console.ReadLine().Split(' ');
            N = int.Parse(NK[0]);
            M = int.Parse(NK[1]);

            string[] l = Console.ReadLine().Split(' ');
            List<double> candels = new List<double>();
            for (int i = 0; i < l.Length; i++)
            {
                candels.Add(double.Parse(l[i]));
            }

            candels.Sort();


            double MaxCandle = candels[M - 1];

            if (isCanDiff(candels, MaxCandle))
            {
                Console.WriteLine(MaxCandle);
            }
            else
            {
                SearchMax(step, MaxCandle, candels);
            }

            Console.ReadKey();
        }

        public static bool isCanDiff(List<double> candels, double divider)
        {
            int result = 0;

            for (int i = 0; i < M; i++)
            {
                result += (int)Math.Floor(candels[i] / divider);
            }

            return result >= N;
        }

        private static void SearchMax(double left, double right,List<double> candles){
            double middle = (right + left) / 2.0;

            bool isMiddleCan = isCanDiff(candles,middle);

            if (isMiddleCan && !isCanDiff(candles,middle + 10e-8))
            {
                Console.WriteLine(middle);
                return;
            }

            if (isMiddleCan)
            {
                SearchMax(middle, right, candles);
            }
            else
            {
                SearchMax(left, middle, candles);
            }
        }
    }
}
