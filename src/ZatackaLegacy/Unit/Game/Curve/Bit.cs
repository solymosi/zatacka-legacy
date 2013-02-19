using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Zatacka.Unit.Game.Curve
{
    class Bit : Unit
    {
        public Curve Curve { get; private set; }
        public Brush GapFill { get; private set; }
        public List<Point> Points { get; private set; }
        public double Radius { get; private set; }
        public bool Gap { get; private set; }

        public Point Head
        {
            get { return Points.Last(); }
        }

        public Bit(Curve Curve, bool Gap)
            : base(Curve.Canvas)
        {
            this.Curve = Curve;
            this.Gap = Gap;
            this.Points = new List<Point>();
            this.Radius = Curve.Game.CurveRadius;
            this.GapFill = Curve.Fill.Clone();
            this.GapFill.Opacity = 0.2;
            this.GapFill.Freeze();
        }

        public void Add(Point Point)
        {
            Points.Add(Point);
            Draw();
        }

        public void Draw()
        {
            //if (Gap) { return; }

            using (DrawingContext Context = RenderOpen())
            {
                foreach (Point P in Points)
                {
                    //SolidColorBrush SCB = new SolidColorBrush(Color.FromArgb(255, (byte)Tools.Random(150, 250), (byte)Tools.Random(150, 250), (byte)Tools.Random(150, 250)));
                    //SCB.Freeze();
                    Context.DrawEllipse(Gap ? GapFill : Curve.Fill, null, P, Radius, Radius);
                }
            }
        }

        protected override void Update() { }
    }
}
