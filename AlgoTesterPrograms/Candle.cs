using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Candle
    {
        public static void Problem(){
            string[] NK = Console.ReadLine().Split(' ');
            int N = int.Parse(NK[0]);
            int K = int.Parse(NK[1]);

            string[] l = Console.ReadLine().Split(' ');
            List<double> candels = new List<double>();
            for (int i = 0; i < l.Length; i++)
            {
                candels.Add(double.Parse(l[i]));
            }

            candels.Sort();

            double maxLenght = 0.0;
            for (int i = 0; i < candels.Count; i++)
            {
                double tempLength = candels[i];
                int counter = 1;
                for (int j = i; j < candels.Count; j++)
                {
                    int currentCounter = (int)(Math.Floor(candels[j] / tempLength));
                    counter += currentCounter;
                }

                if (counter == K)
                {
                    if (maxLenght < tempLength)
                    {
                        maxLenght = tempLength;
                    }
                }
            }


        }
    }
}
