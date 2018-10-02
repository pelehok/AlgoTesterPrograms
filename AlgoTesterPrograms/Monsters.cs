using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Monsters
    {
        public static void Problem(){
            int N = int.Parse(Console.ReadLine());
            string[] inputMas = "0 10 16 8 12".Split(' ');

            List<int> inputMasInt = new List<int>();
            for (int i = 0; i < inputMas.Length; i++)
            {
                inputMasInt.Add(int.Parse(inputMas[i]));
            }
            inputMasInt.Sort();
            int index = 1;
            bool t = true;

            while (inputMasInt.Count != 2)
            {
                if (index == inputMasInt.Count - 1)
                {
                    if (t)
                    {
                        t = false;
                        index = 1;
                    }
                    else
                    {
                        break;
                    }
                }
                int diff = inputMasInt[index] - inputMasInt[index - 1];
                if (diff == (inputMasInt[index + 1] - inputMasInt[index]))
                {
                    int nextIndex = index + 1;
                    if (nextIndex < inputMasInt.Count - 2 &&
                        (inputMasInt[nextIndex] - inputMasInt[nextIndex-1]) == (inputMasInt[nextIndex + 1] - inputMasInt[nextIndex]))
                    {
                        if ((inputMasInt[nextIndex] - inputMasInt[nextIndex - 1]) < diff)
                        {
                            index++;
                        }else
                        {
                            inputMasInt.RemoveAt(index);
                        }
                    }
                    else
                    {
                        inputMasInt.RemoveAt(index);
                        index--;
                        if(index!=0)
                        index--;
                    }
                }

                index++;
            }

            if (inputMasInt.Count == 2)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

            Console.ReadKey();
        }
    }
}
