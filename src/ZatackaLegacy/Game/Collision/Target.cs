using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Game.Collision
{
    class Target
    {
        public Unit.Unit Unit { get; private set; }
        public Point Location { get; private set; }
        public double Radius { get; private set; }

        public Target(Unit.Unit Unit, Point Location, double Radius)
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