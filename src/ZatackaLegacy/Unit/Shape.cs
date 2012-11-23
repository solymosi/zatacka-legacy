using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy.Unit
{
    class Shape : Unit
    {
        public Geometry Geometry { get; protected set; }
        public Brush Fill { get; protected set; }
        public Pen Stroke { get; protected set; }

        public Shape(Game Game, Geometry Geometry, Brush Fill, Pen Stroke)
            : base(Game)
        {
            this.Geometry = Geometry;
            this.Fill = Fill;
            this.Stroke = Stroke;
        }

        public override void Draw(long Lifetime)
        {
            if (Lifetime > 0) { return; }
            using (DrawingContext Context = RenderOpen())
            {
                Context.DrawGeometry(Fill, Stroke, Geometry);
            }
        }
    }
}
