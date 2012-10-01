using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    class Part
    {
        public Curve Curve { get; private set; }
        public List<Point> Points { get; private set; }
        public DrawingVisual Visual { get; private set; }

        public Point Head
        {
            get { return Points.Last(); }
        }

        public Part(Curve Curve)
        {
            this.Curve = Curve;
            this.Points = new List<Point>();
            this.Visual = new DrawingVisual();
        }

        public void Draw(long Lifetime)
        {
            using (DrawingContext Context = Visual.RenderOpen())
            {
                foreach (Point Point in Points)
                {
                    Context.DrawEllipse(Curve.Fill, null, Point, Curve.Game.CurveRadius, Curve.Game.CurveRadius);
                }
            }
        }
    }
}