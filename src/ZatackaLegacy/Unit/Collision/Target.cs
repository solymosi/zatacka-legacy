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
        public bool Inverse { get; private set; }

        public Target(Unit Unit, Rect Rect)
            : this(Unit, Rect, false) { }
        public Target(Unit Unit, Rect Rect, bool Inverse)
            : this(Unit, new RectangleGeometry(Rect), Inverse) { }

        public Target(Unit Unit, Point Center, double Radius)
            : this(Unit, Center, Radius, false) { }
        public Target(Unit Unit, Point Center, double Radius, bool Inverse)
            : this(Unit, new EllipseGeometry(Center, Radius, Radius), Inverse) { }

        public Target(Unit Unit, Geometry Geometry)
            : this(Unit, Geometry, false) { }
        public Target(Unit Unit, Geometry Geometry, bool Inverse)
        {
            this.Unit = Unit;
            this.Geometry = Geometry;
            this.Geometry.Freeze();
            this.Inverse = Inverse;
        }

        public virtual bool CollidesWith(Target Target)
        {
            return Geometry.FillContainsWithDetail(Target.Geometry) != (Target.Inverse ? IntersectionDetail.FullyInside : IntersectionDetail.Empty);
        }
    }
}