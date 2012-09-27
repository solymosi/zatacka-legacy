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
        public Color Color;
        public Pool Pool;
        public DrawingVisual Visual = new DrawingVisual();

        public Unit(Point Location, Color Color, double Radius)
        {
            this.Location = Location;
            this.Color = Color;
            this.Radius = Radius;
        }

        public virtual void Draw(bool First)
        {
            if (First)
            {
                using (DrawingContext Context = Visual.RenderOpen())
                {
                    Context.DrawEllipse(new SolidColorBrush(Color), null, Location, Radius, Radius);
                }
            }
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