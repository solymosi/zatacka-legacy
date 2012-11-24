using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Shape
{
    class Ellipse : Shape
    {
        public Point Center { get; protected set; }
        public Size Size { get; protected set; }

        public Ellipse(Canvas.Canvas Canvas, Point Center, Size Size, Brush Fill, Pen Stroke)
            : base(Canvas, new EllipseGeometry(Center, Size.Width / 2, Size.Height / 2), Fill, Stroke)
        {
            this.Center = Center;
            this.Size = Size;
        }
    }
}
