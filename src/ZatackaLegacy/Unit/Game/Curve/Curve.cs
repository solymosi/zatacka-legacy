using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Effects;

namespace Zatacka.Unit.Game.Curve
{
    class Curve : Unit
    {
        public double Heading { get; private set; }

        public Color Color { get; private set; }
        public Brush Fill { get; private set; }

        public Bit Bit { get; private set; }
        public List<Bit> Bits { get; private set; }
        /* public int BitLength { get; private set; } */

        /// <summary>
        /// Specifies whether this Curve is still alive.
        /// </summary>
        public bool Alive { get; set; }

        public Target Target { get; private set; }
        public Collision.Field Field { get; private set; } 

        public int GapSize { get; private set; }
        public int GapDistance { get; private set; }

        public int GapPeriod
        {
            get { return (int)(Time % (long)GapDistance); }
        }

        public bool Gap
        {
            get { return GapPeriod >= GapDistance - GapSize; }
        }

        public Zatacka.Game.Game Game
        {
            get { return Canvas.As<Canvas.Game>().State; }
        }

        public Point Head
        {
            get { return Bit.Head; }
        }

        public Curve(Canvas.Canvas Canvas, Point Location, double Heading, Color Color)
            : base(Canvas)
        {
            this.Bits = new List<Bit>();
            this.Field = new Collision.Field(this);
            this.Heading = Heading;
            this.Color = Color;
            this.Fill = new SolidColorBrush(Color);
            this.Fill.Freeze();
            this.GapSize = 6;
            this.GapDistance = 150;

            /* BitLength = 100; */
            Add(new Bit(this, false));
            Add(Location);

            EnableCollisions = true;
            SelfCollision = true;
            Add(new Target(this, Location, Game.CurveRadius, null));
        }

        /// <summary>
        /// Kills this Curve and prevents it from moving or colliding with others.
        /// </summary>
        public void Kill()
        {
            Alive = false;
            Colliders.Clear();
        }

        protected override HashSet<Collision.Target> TargetsWithin(Rect Bounds)
        {
            return Field.Within(Bounds);
        }

        protected void Add(Bit Bit)
        {
            Bits.Add(Bit);
            Children.Add(Bit);
            this.Bit = Bit;
        }

        protected void Add(Point Location)
        {
            if (Gap ^ Bit.Gap)
            {
                Add(new Bit(this, Gap));
            }

            Bit.Add(Location);
        }

        protected void Add(Target Target)
        {
            Field.Add(Target);
            Colliders.Clear();
            Colliders.Add(Target);
            this.Target = Target;
        }

        protected override void Update() { }

        public void Left()
        {
            Heading -= Game.SteeringSensitivity;

            if (Heading < 0)
            {
                Heading = 360 + Heading;
            }
        }

        public void Right()
        {
            Heading += Game.SteeringSensitivity;

            if (Heading >= 360)
            {
                Heading = 360 - Heading;
            }
        }

        public void Advance()
        {
            double X = Math.Sin(Heading.ToRadians()) * Game.MovementSpeed;
            double Y = Math.Cos(Heading.ToRadians()) * Game.MovementSpeed * -1;

            Point Next = new Point(Head.X + X, Head.Y + Y);
            Add(Next);

            if (!Gap && Head.DistanceFrom(Target.Location) >= Game.CurveRadius * 2)
            {
                Add(new Target(this, Next, Game.CurveRadius, Target));

                /*DrawingVisual V = new DrawingVisual();
                using (DrawingContext C = V.RenderOpen())
                {
                    C.DrawEllipse(Brushes.Yellow, null, Next, 1, 1);
                }
                this.Children.Add(V);*/
            }
        }
    }
}