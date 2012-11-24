using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Unit.Shape
{
    class Shape : Unit
    {
        public Geometry Geometry { get; protected set; }
        public Brush Fill { get; protected set; }
        public Pen Stroke { get; protected set; }

        public Shape(Canvas.Canvas Canvas, Geometry Geometry, Brush Fill, Pen Stroke)
            : base(Canvas)
        {
            this.Geometry = Geometry;
            this.Fill = Fill;
            this.Stroke = Stroke;
        }

        protected override void Update()
        {
            if (Time > 0) { return; }
            using (DrawingContext Context = RenderOpen())
            {
                Context.DrawGeometry(Fill, Stroke, Geometry);
            }
        }
    }
}
