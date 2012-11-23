using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy.Unit
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
            : base(Curve.Screen)
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
                    Context.DrawEllipse(new SolidColorBrush(Curve.Color), null, Point, Curve.Screen.As<Game>().CurveRadius, Curve.Screen.As<Game>().CurveRadius);
                }
            }
        }
    }
}