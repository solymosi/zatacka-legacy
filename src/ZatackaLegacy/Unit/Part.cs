using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    class Part : Unit
    {
        public Curve Curve { get; private set; }
        public List<Point> Points { get; private set; }

        public Point Head
        {
            get { return Points.Last(); }
        }

        public Part(Curve Curve)
            : base(Curve.Game)
        {
            this.Curve = Curve;
            this.Points = new List<Point>();
        }

        public override void Draw(long Lifetime)
        {
            using (DrawingContext Context = RenderOpen())
            {
                foreach (Point Point in Points)
                {
                    Context.DrawEllipse(Curve.Fill, null, Point, Curve.Game.CurveRadius, Curve.Game.CurveRadius);
                }
            }
        }
    }
}