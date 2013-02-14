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
        public List<Point> Points { get; private set; }

        public Point Head
        {
            get { return Points.Last(); }
        }

        public Bit(Curve Curve)
            : base(Curve.Canvas)
        {
            this.Curve = Curve;
            this.Points = new List<Point>(Curve.BitLength);
            this.CacheMode = new BitmapCache();
        }

        public void Add(Point Point)
        {
            Points.Add(Point);
            Draw();
        }

        public void Draw()
        {
            using (DrawingContext Context = RenderOpen())
            {
                foreach (Point P in Points)
                {
                    Context.DrawLine(Curve.DefaultPen, P, P);
                }
            }
        }

        protected override void Update() { }
    }
}
