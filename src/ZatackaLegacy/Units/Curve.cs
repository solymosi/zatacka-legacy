using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZatackaLegacy
{
    public class Curve : Unit
    {
        public List<Unit> Units = new List<Unit>();

        public Curve(Pool Pool, Point Location, int Radius) : base(Pool, Location, Radius) { }
    }
}
