using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Temperature
    {
        public static void Main1(){
            string s = Console.ReadLine();
            string[] NK = s.Split(' ');
            long days = long.Parse(NK[0]);
            long maxTempDiff = long.Parse(NK[1]);

            s = Console.ReadLine();
            string[] AB = s.Split(' ');
            long A = long.Parse(AB[0]);
            long B = long.Parse(AB[1]);

            long diff = Math.Abs(A - B);
            if (maxTempDiff != 0 || days == 2)
            {
                long temp = (long) Math.Floor((double) diff / (double) maxTempDiff);
                if (A < B)
                {
                    AddNewMax(A + maxTempDiff * temp, B, days - temp - 1, maxTempDiff);
                    AddNewMin(A, B - maxTempDiff * temp, days - temp - 1, maxTempDiff);
                }
                else
                {
                    AddNewMax(A, B + maxTempDiff * temp, days - temp - 1, maxTempDiff);
                    AddNewMin(A - maxTempDiff * temp, B, days - temp - 1, maxTempDiff);
                }
            }
            else
            {
                MaxTemp = Math.Max(A, B);
                MinTemp = Math.Min(A, B);
            }

            Console.WriteLine(MaxTemp + " "+ MinTemp);
            Console.ReadKey();
        }

        private static long MaxTemp = 0;

        public static void AddNewMax(long A, long B, long day, long step){
            if (day == 1)
            {
                MaxTemp = Math.Max(A, B);
                return;
            }

            if (A < B)
            {
                AddNewMax(A + step, B, day - 1, step);
            }
            else if (B < A)
            {
                AddNewMax(A, B + step, day - 1, step);
            }
            else
            {
                if (day % 2 == 0)
                {
                    long diff = day * step / 2;
                    MaxTemp = A + diff;
                    return;
                }
                else
                {
                    long diff = (day + 1) * step / 2;
                    MaxTemp = A + diff;
                    return;
                }
            }
        }

        private static long MinTemp = 0;

        public static void AddNewMin(long A, long B, long day, long step){
            if (day == 1)
            {
                MinTemp = Math.Min(A, B);
                return;
            }

            if (A < B)
            {
                AddNewMin(A, B - step, day - 1, step);
            }
            else if (B < A)
            {
                AddNewMin(A - step, B, day - 1, step);
            }
            else
            {
                if (day % 2 == 0)
                {
                    long diff = day * step / 2;
                    MinTemp = A - diff;
                    return;
                }
                else
                {
                    long diff = (day + 1) * step / 2;
                    MinTemp = A - diff;
                    return;
                }
            }
        }
    }
}
