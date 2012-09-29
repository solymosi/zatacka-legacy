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
        public bool EnableCollision = false;

        public double Radius;
        public Point Location;
        public Color Color;
        public Pool Pool;
        public TargetCollection Targets = new TargetCollection();
        public DrawingVisual Visual = new DrawingVisual();

        public Unit(Point Location, Color Color, double Radius)
        {
            this.Location = Location;
            this.Color = Color;
            this.Radius = Radius;
            Targets.Add(new Target(this, Location, Radius));
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

        public List<Point> CollisionsWith(Target Target) { return CollisionsWith(Target, 0); }
        public virtual List<Point> CollisionsWith(Target Target, double Threshold)
        {
            List<Point> Result = new List<Point>();
            foreach (Target T in Targets)
            {
                if (T.CollidesWith(Target)) { Result.Add(T.Location); }
            }
            return Result;
        }
        public List<Point> CollisionsWith(Unit Unit) { return CollisionsWith(Unit, 0); }
        public virtual List<Point> CollisionsWith(Unit Unit, double Threshold)
        {
            List<Point> Result = new List<Point>();
            foreach (Target T in Targets)
            {
                Result.AddRange(Unit.CollisionsWith(T, Threshold));
            }
            return Result;
        }
    }
}