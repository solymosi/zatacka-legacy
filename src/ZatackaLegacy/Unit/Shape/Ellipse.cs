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
        public Point Center { get; protected set; }

        /// <summary>
        /// A Size instance describing the horizontal (width) and vertical (height) diameters of the Ellipse.
        /// </summary>
        public Size Size { get; protected set; }

        /// <summary>
        /// Creates an Ellipse with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas the Ellipse is displayed on.</param>
        /// <param name="Center">Position of the center of this Ellipse on the Canvas.</param>
        /// <param name="Size">A Size instance describing the horizontal (width) and vertical (height) diameters of the Ellipse.</param>
        /// <param name="Fill">The Brush used to fill this Ellipse. If it is null, no fill is drawn.</param>
        /// <param name="Border">The Pen used to draw the borders of this Ellipse. If it is null, no border is drawn.</param>
        public Ellipse(Canvas.Canvas Canvas, Point Center, Size Size, Brush Fill, Pen Border)
            : base(Canvas, new EllipseGeometry(Center, Size.Width / 2, Size.Height / 2), Fill, Border)
        {
            this.Center = Center;
            this.Size = Size;
        }
    }
}
