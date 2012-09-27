using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZatackaLegacy
{
    public class Unit
    {
        public float Radius;
        public PointF Location;
        public Pool Pool;

        public Unit(Pool Pool, PointF Location, float Radius)
        {
            this.Pool = Pool;
            this.Location = Location;
            this.Radius = Radius;

            Pool.Units.Add(this);
        }

        public virtual void Draw(Graphics GFX)
        {
            GFX.FillEllipse(Brushes.White, Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);
        }

        public bool CollidesWith(Unit Unit) { return CollidesWith(Unit, 0); }
        public bool CollidesWith(PointF Point) { return CollidesWith(Point, 0); }
        public bool CollidesWith(Unit Unit, float Threshold) { return CollidesWith(Unit.Location, Threshold + Unit.Radius); }
        public bool CollidesWith(PointF Point, float Threshold)
        {
            return Tools.Distance(Point, Location) <= Radius + Threshold;
        }
    }
}
