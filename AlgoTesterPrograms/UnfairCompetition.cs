using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlgoTesterPrograms
{
	public class UnfairCompetition
	{
		public static void Main1()
		{
			Problem();
		}

		private const int noneNode = 1;
		
		public static void Problem()
		{
			string s = "5 5";//Console.ReadLine();
			string[] NM = s.Split(' ');
			int N = int.Parse(NM[0]);
			int M = int.Parse(NM[1]);

			var strings = new List<string>(){
				"1 2",
				"2 5",
				"5 1",
				"5 4",
				"4 3"
			};
			
			var pairs = new List<Pair>();
			for (int i = 0; i < M; i++)
			{
				string[] p = strings[i].Split(' ');//Console.ReadLine().Split(' ');
				pairs.Add(new Pair() {firstStudent = int.Parse(p[0]), secontStudent = int.Parse(p[1])});
			}

			for (int i = 0; i < M; i++)
			{
				var newNodes = new List<Pair>(pairs);
				newNodes.RemoveAt(i);
				if(IsHaveCircle(newNodes,noneNode))
			}
			
		}

		public bool IsHaveCircle(List<Pair> nodes, int firstNode, int lastNode)
		{
			while (true)
			{
				var firstPair = nodes.FirstOrDefault(x => x.IsHaveNode(firstNode));
				if (firstPair != null)
				{
					nodes.Remove(firstPair);
					return IsHaveCircle(nodes, firstPair.AnotherNode(firstNode), lastNode);
				}
			}
		}
	}

	public class Tree
	{
		
	}

	public class Pair
	{
		public int firstStudent { get; set; }
		public int secontStudent { get; set; }

		public bool IsHaveNode(int Node)
		{
			if (firstStudent == Node || secontStudent == Node)
			{
				return true;
			}

			return false;
		}

		public int AnotherNode(int Node)
		{
			if (firstStudent != Node)
			{
				return firstStudent;
			}

			return secontStudent;
		}
	}
}