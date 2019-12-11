using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Dayofcode3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filedata = File.ReadAllLines("input.txt");

            string dataX = filedata[0];
            string dataY = filedata[1];

            string[] x = dataX.Split(",");
            string[] y = dataY.Split(",");

            Console.WriteLine($"length x: {x.Length}");
            Console.WriteLine($"length y: {y.Length}");

            List<Point> xpoints = new List<Point>();
            List<Point> ypoints = new List<Point>();

            Program p = new Program();

            foreach (var item in x)
            {
                int numbers = int.Parse(item.Substring(1));
                xpoints = p.addPointsUntilNumber(xpoints, item[0].ToString(), numbers);
            }
            foreach (var item in y)
            {
                int numbers = int.Parse(item.Substring(1));
                ypoints = p.addPointsUntilNumber(ypoints, item[0].ToString(), numbers);
            }

            foreach (var item in xpoints)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            foreach (var item in ypoints)
            {
                Console.WriteLine(item);
            }

            p.checkdoubles(xpoints, ypoints);

        }

       public void checkdoubles(List<Point> xpoints, List<Point> ypoints)
        {
            int lowest = int.MaxValue;
            foreach (var itemx in xpoints)
            {
                foreach (var itemy in ypoints)
                {
                    if(itemx.X== itemy.X && itemx.Y == itemy.Y)
                    {
                        Console.WriteLine($"Match!: x: {itemx.X} y: {itemx.Y} dist: {Math.Abs(itemx.X) + Math.Abs(itemx.Y)}");
                        if (Math.Abs(itemx.X) + Math.Abs(itemx.Y) < lowest)
                            lowest = Math.Abs(itemx.X) + Math.Abs(itemx.Y);
                    }
                }
            }
            Console.WriteLine($"LOWEST: {lowest}");
        }

        public List<Point> addPointsUntilNumber(List<Point> list, string direction, int number)
        {

            int startx = 0, starty = 0;

            for (int i = 1; i <= number; i++)
            {
                if (list.Count > 0)
                {
                    startx = list.LastOrDefault().X;
                    starty = list.LastOrDefault().Y;
                }
                switch (direction)
                {
                    case "U":
                        list.Add(new Point(startx, starty + 1));
                        break;
                    case "D":
                        list.Add(new Point(startx, starty - 1));
                        break;
                    case "L":
                        list.Add(new Point(startx - 1, starty));
                        break;
                    case "R":
                        list.Add(new Point(startx + 1, starty));
                        break;

                }
            }
            return list;
        }
    }
}
