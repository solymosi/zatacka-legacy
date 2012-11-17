using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    class Ellipse : Shape
    {
        public Point Center { get; protected set; }
        public Size Size { get; protected set; }

        public Ellipse(Game Game, Point Center, Size Size, Brush Fill, Pen Stroke)
            : base(Game, new EllipseGeometry(Center, Size.Width / 2, Size.Height / 2), Fill, Stroke)
        {
            this.Center = Center;
            this.Size = Size;
            Targets.Add(new Target(this, Center, Size.Width / 2));
        }
    }
}
