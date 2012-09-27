using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZatackaLegacy
{
    static public class Tools
    {
        static public Random R = new Random();

        static public int Random(int Min, int Max)
        {
            return R.Next(Min, Max + 1);
        }

        static public double DegreeToRadian(double Degrees)
        {
            return Math.PI * Degrees / 180.0;
        }

        static public float Distance(PointF First, PointF Second)
        {
            return (float)Math.Sqrt(Math.Pow(First.X - Second.X, 2) + Math.Pow(First.Y - Second.Y, 2));
        }
    }
}