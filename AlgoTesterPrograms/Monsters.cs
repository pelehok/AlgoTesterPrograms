using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Monsters
    {
        public static bool DivArray(List<int> array)
        {
            if (array.Count == 2)
            {
                return true;
            }
            
            int mediumElement = array.First() + (array.Last() - array.First())/2;
            if (array.Contains(mediumElement))
            {
                int mediumIndex = array.IndexOf(mediumElement);
                return     DivArray(array.GetRange(0,mediumIndex+1)) &&
                            DivArray(array.GetRange(mediumIndex,array.Count-mediumIndex));
            }
            else
            {
                if (array.Count > 2)
                {
                    return false;
                }

                return true;
            }
        }
        
        static void Main1(string[] args)
        {
            Problem();
        }
        public static void Problem(){
            int N = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] inputMas = s.Split(' ');

            List<int> inputMasInt = new List<int>();
            for (int i = 0; i < inputMas.Length; i++)
            {    
                inputMasInt.Add(int.Parse(inputMas[i]));
            }
            inputMasInt.Sort();

            if ( DivArray(inputMasInt))
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
