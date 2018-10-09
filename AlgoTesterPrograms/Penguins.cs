using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTesterPrograms
{
    class Penguins
    {
        public static void Problem(){
            var s = Console.ReadLine();
            int N = int.Parse(s);


            var points = new List<Point>();
            for (int i = 0; i < N; i++)
            {
                var pointsString = Console.ReadLine().Split(' ');
                points.Add(new Point(int.Parse(pointsString[0]), int.Parse(pointsString[1])));
            }

            points.Sort((x, y) => x.X.CompareTo(y.X));
            var maxToX = points.Last().X;

            points.Sort((x, y) => x.Y.CompareTo(y.Y));
            var maxToY = points.Last().Y;

            var mainPoint = new Point(maxToX, maxToY);
            int counter = 0;
            for (int i = 0; i < N; i++)
            {
                counter += points[i].GetLenghtToPoint(mainPoint);
            }

            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int GetLenghtToPoint(Point p)
        {
            int lenghtToX = p.X - this.X;
            int lenghtToY = p.Y - this.Y;
            return lenghtToX + lenghtToY;
        }
    }
}
