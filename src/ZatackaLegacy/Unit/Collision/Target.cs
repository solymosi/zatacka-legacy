using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Collision
{
    class Target
    {
        public Unit Unit { get; private set; }
        public Geometry Geometry { get; private set; }

        public Target(Unit Unit, Rect Rect)
            : this(Unit, new RectangleGeometry(Rect)) { }
        public Target(Unit Unit, Point Center, double Radius)
            : this(Unit, new EllipseGeometry(Center, Radius, Radius)) { }
        public Target(Unit Unit, Geometry Geometry)
        {
            this.Unit = Unit;
            this.Geometry = Geometry;
            this.Geometry.Freeze();
        }

        public virtual bool CollidesWith(Target Target)
        {
            return Geometry.FillContainsWithDetail(Target.Geometry) != IntersectionDetail.Empty;
        }
    }
}