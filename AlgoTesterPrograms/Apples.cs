using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Apples
    {
        public static void Problem(){
            int N = int.Parse("5");//Console.ReadLine());
            string s = "2 2 2 2 2";//Console.ReadLine();
            string[] applesNumber = s.Split(' ');

            long B = int.Parse("10");//Console.ReadLine());
            s = "3 7 2 5 4";//Console.ReadLine();
            string[] applesPrice = s.Split(' ');

            var backets = new List<Backet>();
            for (int i = 0; i < N; i++)
            {
                backets.Add(new Backet() {AppleCount = int.Parse(applesNumber[i]), Price = int.Parse(applesPrice[i])});
            }


            long minPrice = Int64.MaxValue;;
            for (int i = 0; i <N; i++)
            {
                long tempMin = GetPrice(backets, B, i);
                if (tempMin < minPrice)
                {
                    minPrice = tempMin;
                }
            }

            Console.WriteLine(minPrice);
            Console.ReadKey();
        }

        public static long GetPrice(List<Backet> brackets, long B, int CountShow){
            long sum = 0;

            for (int i = 0; i < brackets.Count; i++)
            {
                var range = GetRange(brackets, i, CountShow+1);
                var minPrice = range.Min((x) => x.Price);
                sum += (minPrice * brackets[i].AppleCount);
            }

            sum += B * CountShow;
            return sum;
        }

        public static List<Backet> GetRange(List<Backet> backets, int index, int count){
            if (index + count > backets.Count)
            {
                var res = backets.GetRange(index, backets.Count - index);
                res.AddRange(backets.GetRange(0, index + count - backets.Count));
                return res;
            }
            else
            {
                return backets.GetRange(index, count);
            }
        }

        public class Backet
        {
            public int Price { get; set; }
            public int AppleCount { get; set; }
        }
    }
}
