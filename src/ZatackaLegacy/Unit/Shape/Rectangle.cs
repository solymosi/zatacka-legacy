using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Unit.Shape
{
    class Rectangle : Shape
    {
        public Rect Rect { get; protected set; }

        public Rectangle(Canvas.Canvas Canvas, Rect Rectangle, Brush Fill, Pen Stroke)
            : base(Canvas, new RectangleGeometry(Rectangle), Fill, Stroke)
        {
            this.Rect = Rectangle;
        }
    }
}