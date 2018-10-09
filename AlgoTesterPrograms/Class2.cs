//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AlgoTesterPrograms
//{
//public class Main
//{

//    public static Integer[] lengths;

//    public static Integer n;
//    public static Integer m;

//    public static void main(String[] args) throws IOException
//    {
//        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
//    String[] nm = br.readLine().split("\\s+");
//    n = Integer.parseInt(nm[0]);
//    m = Integer.parseInt(nm[1]);
//    lengths = new Integer[m];

//    String[] temp = br.readLine().split("\\s+");
//        for(int i = 0; i<m; i++) {
//        lengths[i] = Integer.parseInt(temp[i]);
//    }

//    Arrays.sort(lengths);

//    Double left = 10e-10;
//    Integer right = lengths[m - 1];

//        if(freakingPossible(Double.valueOf(right))) {
//        System.out.println(right);
//    } else {
//doMegaSuperSearchBoy(left, Double.valueOf(right));
//}
//}

//private static void doMegaSuperSearchBoy(Double left, Double right)
//{
//Double seredinka = (right + left) / 2.0;

//boolean seredinkaPossibility = freakingPossible(seredinka);

//if (seredinkaPossibility && !freakingPossible(seredinka + 10e-10))
//{
//System.out.println(seredinka);
//System.exit(0);
//}

//if (seredinkaPossibility)
//{
//doMegaSuperSearchBoy(seredinka, right);
//}
//else
//{
//doMegaSuperSearchBoy(left, seredinka);
//}
//}

//public static boolean freakingPossible(Double kitty)
//{
//Integer result = 0;

//for (int i = 0; i < m; i++)
//{
//result += (int)Math.floor(lengths[i] / kitty);
//}

//return result >= n;
//}
//}

//}
