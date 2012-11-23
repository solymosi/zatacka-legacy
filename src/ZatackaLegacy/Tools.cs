using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;

namespace Zatacka
{
    static public class Tools
    {
        static public Random Generator = new Random();

        static public double Random(double Min, double Max)
        {
            return Generator.NextDouble() * (Max - Min) + Min;
        }

        static public int Random(int Min, int Max)
        {
            return Generator.Next(Min, Max + 1);
        }

        static public double DegreeToRadian(double Degrees)
        {
            return Math.PI * Degrees / 180.0;
        }

        static public double Distance(Point First, Point Second)
        {
            return Math.Sqrt(Math.Pow(First.X - Second.X, 2) + Math.Pow(First.Y - Second.Y, 2));
        }

        static public long Measure(System.Action Action)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            Action.Invoke();
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
