using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Temperature
    {
        public static void Main(){
            string s = "2 7"; //Console.ReadLine();
            string[] NK = s.Split(' ');
            int days = int.Parse(NK[0]);
            int maxTempDiff = int.Parse(NK[1]);

            s = "-3 1"; //Console.ReadLine();
            string[] AB = s.Split(' ');
            int A = int.Parse(AB[0]);
            int B = int.Parse(AB[1]);

            int diff = Math.Abs(A - B);
            if (maxTempDiff != 0 || days == 2)
            {
                int temp = (int) Math.Floor((double) diff / (double) maxTempDiff);
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

            Console.WriteLine(MaxTemp);
            Console.WriteLine(MinTemp);
            Console.ReadKey();
        }

        private static int MaxTemp = 0;

        public static void AddNewMax(int A, int B, int day, int step){
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
                    int diff = day * step / 2;
                    MaxTemp = A + diff;
                    return;
                }
                else
                {
                    int diff = (day + 1) * step / 2;
                    MaxTemp = A + diff;
                    return;
                }
            }
        }

        private static int MinTemp = 0;

        public static void AddNewMin(int A, int B, int day, int step){
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
                    int diff = day * step / 2;
                    MinTemp = A - diff;
                    return;
                }
                else
                {
                    int diff = (day + 1) * step / 2;
                    MinTemp = A - diff;
                    return;
                }
            }
        }
    }
}
