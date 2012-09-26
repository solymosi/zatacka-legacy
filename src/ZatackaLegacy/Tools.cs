using System;
using System.Collections.Generic;
using System.Text;

namespace ZatackaLegacy
{
    static public class Tools
    {
        static public Random R = new Random();

        static public int Random(int Min, int Max)
        {
            return R.Next(Min, Max + 1);
        }
    }
}
