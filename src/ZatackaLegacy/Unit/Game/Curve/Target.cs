using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Game.Curve
{
    class Target : Collision.Target
    {
        public Curve Curve { get; private set; }
        public Point Location { get; private set; }
        public double Radius { get; private set; }
        public int Serial { get; private set; }

        public Target(Curve Curve, Point Location, double Radius, Target Previous)
            : base(Curve, Location, Radius)
        {
            this.Curve = Curve;
            this.Location = Location;
            this.Radius = Radius;
            this.Serial = Previous == null ? 0 : Previous.Serial + 1;
        }

        public override bool CollidesWith(Collision.Target Target)
        {
            return Target.Unit == Unit && Target.As<Target>().Serial >= Curve.Target.Serial - 2 ? false : base.CollidesWith(Target);
        }
    }
}