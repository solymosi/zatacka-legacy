using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    public class Unit
    {
        public double Radius;
        public Point Location;
        public Pool Pool;

        public Unit(Pool Pool, Point Location, double Radius)
        {
            this.Pool = Pool;
            this.Location = Location;
            this.Radius = Radius;

            Pool.Units.Add(this);
        }

        public virtual void Render(DrawingContext Context)
        {
            Context.DrawEllipse(Brushes.White, null, Location, Radius, Radius);
        }

        public bool CollidesWith(Unit Unit) { return CollidesWith(Unit, 0); }
        public bool CollidesWith(Point Point) { return CollidesWith(Point, 0); }
        public bool CollidesWith(Unit Unit, double Threshold) { return CollidesWith(Unit.Location, Threshold + Unit.Radius); }
        public bool CollidesWith(Point Point, double Threshold)
        {
            return Tools.Distance(Point, Location) <= Radius + Threshold;
        }
    }
}
