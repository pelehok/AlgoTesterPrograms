using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTesterPrograms
{
    class Class3
    {
        static char fire = '0';
        static char safe = '1';
        static int rikoStep = 4;
        static int kovalStep = 7;
        public static void Main1()
        {
            string s = Console.ReadLine();
            string[] RK = s.Split(' ');

            int riko = int.Parse(RK[1])-1;//4
            int koval = int.Parse(RK[2])-1;//7

            int N = int.Parse(RK[0]);
            s = Console.ReadLine();
            string woods = s;
            List<int> kovalPosition = new List<int>();
            List<int> rikoPosition = new List<int>();

            for (int i = koval; i < N; i += kovalStep)
            {
                if (woods[i] == fire) break;
                kovalPosition.Add(i);
            }

            for (int i = koval - kovalStep; i >= 0; i -= kovalStep)
            {
                if (woods[i] == fire) break;
                kovalPosition.Add(i);
            }

            for (int i = riko; i < N; i += rikoStep)
            {
                if (woods[i] == fire) break;
                rikoPosition.Add(i);
            }

            for (int i = riko - rikoStep; i >= 0; i -= rikoStep)
            {
                if (woods[i] == fire) break;
                rikoPosition.Add(i);
            }

            rikoPosition = rikoPosition.Intersect(kovalPosition).ToList();

            if (rikoPosition.Count == 0)
            {
                Console.WriteLine("-1");
                return;
            }

            int minStep = int.MaxValue;

            for (int i = 0; i < rikoPosition.Count; i++)
            {
                int steps = Math.Abs(rikoPosition[i] - koval) / kovalStep;
                steps += Math.Abs(rikoPosition[i] - riko) / rikoStep;
                if (minStep > steps) minStep = steps;
            }

            Console.WriteLine(minStep);
            Console.ReadKey();
        }
    }
}
