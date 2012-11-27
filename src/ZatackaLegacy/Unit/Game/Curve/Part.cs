using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Unit.Game.Curve
{
    class Part : Unit
    {
        public Curve Curve { get; private set; }
        public List<Point> Points { get; private set; }
        protected Pen Pen { get; set; }

        public Point Head
        {
            get { return Points.Last(); }
        }

        public Part(Curve Curve)
            : base(Curve.Canvas)
        {
            this.Curve = Curve;
            this.Points = new List<Point>();
            this.Pen = new Pen(new SolidColorBrush(Curve.Color), Curve.Game.CurveRadius * 2);
            this.Pen.StartLineCap = PenLineCap.Round;
            this.Pen.EndLineCap = PenLineCap.Round;
            this.Pen.Freeze();
        }

        protected override void Update()
        {
            using (DrawingContext Context = RenderOpen())
            {
                foreach (Point Point in Points)
                {
                    Context.DrawLine(Pen, Point, Point);
                }
            }
        }
    }
}