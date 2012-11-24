using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Unit.Shape
{
    /// <summary>
    /// Represents a shape on the screen.
    /// </summary>
    class Shape : Unit
    {
        /// <summary>
        /// The Geometry instance defining the appearance of this Shape.
        /// </summary>
        public Geometry Geometry { get; protected set; }

        /// <summary>
        /// The Brush used to fill this Shape. If it is null, no fill is drawn.
        /// </summary>
        public Brush Fill { get; protected set; }

        /// <summary>
        /// The Pen used to draw the borders of this Shape. If it is null, no border is drawn.
        /// </summary>
        public Pen Border { get; protected set; }

        /// <summary>
        /// Creates a Shape with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas the Shape is displayed on.</param>
        /// <param name="Geometry">The Geometry instance defining the appearance of this Shape.</param>
        /// <param name="Fill">The Brush used to fill this Shape. If it is null, no fill is drawn.</param>
        /// <param name="Border">The Pen used to draw the borders of this Shape. If it is null, no border is drawn.</param>
        public Shape(Canvas.Canvas Canvas, Geometry Geometry, Brush Fill, Pen Border)
            : base(Canvas)
        {
            this.Geometry = Geometry;
            this.Fill = Fill;
            this.Border = Border;
        }

        /// <summary>
        /// Renders this Shape on the screen.
        /// </summary>
        protected override void Update()
        {
            if (Time > 0) { return; }
            using (DrawingContext Context = RenderOpen())
            {
                Context.DrawGeometry(Fill, Border, Geometry);
            }
        }
    }
}
