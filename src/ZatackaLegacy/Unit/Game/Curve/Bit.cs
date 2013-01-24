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
        public Point Location { get; private set; }

        public Bit(Curve Curve, Point Location)
            : base(Curve.Canvas)
        {
            this.Location = Location;
            this.CacheMode = new BitmapCache();
            //this.Effect = new BlurEffect { Radius = 20 };
            //this.Effect.Freeze();

            using (DrawingContext Context = RenderOpen())
            {
                Context.DrawLine(Curve.DefaultPen, Location, Location);
            }
        }

        protected override void Update() { }
    }
}
