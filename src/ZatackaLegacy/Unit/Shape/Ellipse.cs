using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Shape
{
    /// <summary>
    /// Represents an ellipse or circle on the screen.
    /// </summary>
    class Ellipse : Shape
    {
        /// <summary>
        /// Position of the center of this Ellipse on the Canvas.
        /// </summary>
        public Point Center
        {
            get { return Geometry.As<EllipseGeometry>().Center; }
            set { Geometry = new EllipseGeometry(value, Geometry.Bounds.Width / 2, Geometry.Bounds.Height / 2); }
        }

        /// <summary>
        /// A Size instance describing the horizontal (width) and vertical (height) diameters of the Ellipse.
        /// </summary>
        public Size Size
        {
            get { return Geometry.As<EllipseGeometry>().Bounds.Size; }
            set { Geometry = new EllipseGeometry(new Point(Geometry.Bounds.X + Geometry.Bounds.Width / 2, Geometry.Bounds.Y + Geometry.Bounds.Height / 2), value.Width / 2, value.Height / 2); }
        }

        /// <summary>
        /// Creates an Ellipse with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas the Ellipse is displayed on.</param>
        /// <param name="Center">Position of the center of this Ellipse on the Canvas.</param>
        /// <param name="Size">A Size instance describing the horizontal (width) and vertical (height) diameters of the Ellipse.</param>
        /// <param name="Fill">The Brush used to fill this Ellipse. If it is null, no fill is drawn.</param>
        /// <param name="Border">The Pen used to draw the borders of this Ellipse. If it is null, no border is drawn.</param>
        public Ellipse(Canvas.Canvas Canvas, Point Center, Size Size, Brush Fill, Pen Border)
            : base(Canvas, new EllipseGeometry(Center, Size.Width / 2, Size.Height / 2), Fill, Border) { }
    }
}