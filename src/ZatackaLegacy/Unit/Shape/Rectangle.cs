using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    class Rectangle : Shape
    {
        public Rectangle(Game Game, Rect Rectangle, Brush Fill, Pen Stroke)
            : base(Game, new RectangleGeometry(Rectangle), Fill, Stroke)
        {

        }
    }
}
