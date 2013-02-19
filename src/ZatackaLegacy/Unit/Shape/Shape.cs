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
        protected Geometry _Geometry { get; set; }

        /// <summary>
        /// The Geometry instance defining the appearance of this Shape.
        /// </summary>
        public Geometry Geometry
        {
            get { return _Geometry; }
            set
            {
                if (_Geometry != value)
                {
                    _Geometry = value;
                    Draw();
                }
            }
        }

        protected Brush _Fill { get; set; }

        /// <summary>
        /// The Brush used to fill this Shape. If it is null, no fill is drawn.
        /// </summary>
        public Brush Fill
        {
            get { return _Fill; }
            set
            {
                if (_Fill != value)
                {
                    _Fill = value;
                    Draw();
                }
            }
        }

        protected Pen _Pen { get; set; }

        /// <summary>
        /// The Pen used to draw the borders of this Shape. If it is null, no border is drawn.
        /// </summary>
        public Pen Border
        {
            get { return _Pen; }
            set
            {
                if (_Pen != value)
                {
                    _Pen = value;
                    Draw();
                }
            }
        }

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

            Draw();
        }

        /// <summary>
        /// Implements the abstract Update method.
        /// </summary>
        protected override void Update() { }

        /// <summary>
        /// Renders this Shape on the screen.
        /// </summary>
        protected virtual void Draw()
        {
            using (DrawingContext Context = RenderOpen())
            {
                Context.DrawGeometry(Fill, Border, Geometry);
            }
        }
    }
}
