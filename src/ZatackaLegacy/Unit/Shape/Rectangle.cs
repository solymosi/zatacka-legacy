using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Unit.Shape
{
    /// <summary>
    /// Represents a rectangle on the screen.
    /// </summary>
    class Rectangle : Shape
    {
        /// <summary>
        /// A Rect instance describing the size and location of this Rectangle on the Canvas.
        /// </summary>
        public Rect Bounds
        {
            get { return Geometry.As<RectangleGeometry>().Bounds; }
            set { Geometry = new RectangleGeometry(Bounds); }
        }

        /// <summary>
        /// The location of the top left corner of this Rectangle.
        /// </summary>
        public Point Location
        {
            get { return Bounds.Location; }
            set { Bounds = new Rect(value, Bounds.Size); }
        }

        /// <summary>
        /// The size of this Rectangle.
        /// </summary>
        public Size Size
        {
            get { return Bounds.Size; }
            set { Bounds = new Rect(Bounds.Location, value); }
        }

        /// <summary>
        /// Creates a Rectangle with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas the Rectangle is displayed on.</param>
        /// <param name="Bounds">A Rect instance describing the size and location of this Rectangle on the Canvas.</param>
        /// <param name="Fill">The Brush used to fill this Rectangle. If it is null, no fill is drawn.</param>
        /// <param name="Border">The Pen used to draw the borders of this Rectangle. If it is null, no border is drawn.</param>
        public Rectangle(Canvas.Canvas Canvas, Rect Bounds, Brush Fill, Pen Border)
            : base(Canvas, new RectangleGeometry(Bounds), Fill, Border) { }
    }
}