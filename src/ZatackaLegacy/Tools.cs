using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;

namespace Zatacka
{
    /// <summary>
    /// Static class for miscellaneous support methods.
    /// </summary>
    static public class Tools
    {
        /// <summary>
        /// An instance of System.Random used to generate random numbers.
        /// </summary>
        static public Random Generator = new Random();

        /// <summary>
        /// Generates a random floating-point number within the specified range.
        /// </summary>
        /// <param name="Min">Lowest possible return value.</param>
        /// <param name="Max">Highest possible return value.</param>
        /// <returns>The generated number as a double.</returns>
        static public double Random(double Min, double Max)
        {
            return Generator.NextDouble() * (Max - Min) + Min;
        }

        /// <summary>
        /// Generates an integer number within the specified range, including the lowest and highest values.
        /// </summary>
        /// <param name="Min">Lowest possible return value.</param>
        /// <param name="Max">Highest possible return value.</param>
        /// <returns>The generated integer.</returns>
        static public int Random(int Min, int Max)
        {
            return Generator.Next(Min, Max + 1);
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="Degrees">The degree to convert.</param>
        /// <returns>The value in radians.</returns>
        static public double DegreeToRadian(double Degrees)
        {
            return Math.PI * Degrees / 180.0;
        }

        /// <summary>
        /// Calculates the distance of two points on the 2D plane.
        /// </summary>
        /// <param name="First">The first point.</param>
        /// <param name="Second">The second point.</param>
        /// <returns>The calculated distance.</returns>
        static public double Distance(Point First, Point Second)
        {
            return Math.Sqrt(Math.Pow(First.X - Second.X, 2) + Math.Pow(First.Y - Second.Y, 2));
        }

        /// <summary>
        /// Executes and measures the specified System.Action and returns its run time in milliseconds.
        /// </summary>
        /// <param name="Action">The System.Action to measure. Possible usage: new System.Action( delegate { ... } )</param>
        /// <returns>The elapsed time in milliseconds.</returns>
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
