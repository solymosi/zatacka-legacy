using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Canvas
{
    /// <summary>
    /// Represents a canvas on the screen.
    /// </summary>
    class Canvas : Shape.Rectangle
    {
        /// <summary>
        /// The Brush used to fill the background of the Canvas.
        /// </summary>
        public Brush Background
        {
            get { return Fill; }
            set { Fill = value; }
        }

        /// <summary>
        /// Creates a Canvas with the specified size in the top left corner of the screen
        /// </summary>
        /// <param name="Size">The size of the Canvas.</param>
        public Canvas(Size Size)
            : this(Size.ToRect())
        { }

        /// <summary>
        /// Creates a Canvas with the specified size and location on the screen.
        /// </summary>
        /// <param name="Bounds">A Rect instance describing the size and location of the Canvas on the screen.</param>
        public Canvas(Rect Bounds)
            : base(null, Bounds, null, null)
        {
            this.Bounds = Bounds;
            this.Fill = Background;
            this.Border = Border;
            this.Clip = new RectangleGeometry(Bounds);
        }

        /// <summary>
        /// Triggers the update of the underlying Rectangle.
        /// </summary>
        protected override void Update()
        {
            base.Update();
        }
    }
}