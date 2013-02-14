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
        public Pen DefaultPen { get; private set; }
        public Bit Bit { get; private set; }
        public List<Bit> Bits { get; private set; }
        public int BitLength { get; private set; }
        public Target.Target Target { get; private set; }

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
            this.Heading = Heading;
            this.Color = Color;

            this.DefaultPen = new Pen(new SolidColorBrush(Color), Game.CurveRadius * 2);
            this.DefaultPen.StartLineCap = PenLineCap.Round;
            this.DefaultPen.EndLineCap = PenLineCap.Round;
            this.DefaultPen.Freeze();

            this.CacheMode = new BitmapCache();

            BitLength = 200;
            Add(new Bit(this));
            Add(Location);

            EnableCollisions = true;
            Targets.Clear();
            Add(new Target.Target(this, Location, Game.CurveRadius));
        }

        protected void Add(Bit Bit)
        {
            Bits.Add(Bit);
            Children.Add(Bit);
            this.Bit = Bit;
        }

        protected void Add(Point Location)
        {
            if (Bit.Points.Count >= BitLength)
            {
                Add(new Bit(this));
            }

            Bit.Add(Location);
        }

        protected void Add(Target.Target Target)
        {
            Targets.Add(Target);
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

            if (Head.DistanceFrom(Target.Location) >= Game.CurveRadius * 2)
            {
                Add(new Target.Target(this, Next, Game.CurveRadius));
            }
        }
    }
}