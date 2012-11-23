using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy.Unit.Target
{
    class Target
    {
        public Unit Unit;
        public Point Location;
        public double Radius;

        public Target(Unit Unit, Point Location, double Radius)
        {
            this.Unit = Unit;
            this.Location = Location;
            this.Radius = Radius;
        }

        public bool CollidesWith(Target Target) { return CollidesWith(Target, 0); }
        public bool CollidesWith(Target Target, double Threshold)
        {
            return this != Target && Tools.Distance(Location, Target.Location) <= Radius + Target.Radius + Threshold;
        }
    }
}