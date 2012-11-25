using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Unit.Game.Curve
{
    class Curve : Unit
    {
        public int PartLength { get; private set; }
        public double Heading { get; private set; }
        public Color Color { get; private set; }
        public Target.Target Target { get; private set; }
        public Part Part { get; private set; }
        public List<Part> Parts { get; private set; }
        public Zatacka.Game.Game Game { get { return Canvas.As<Canvas.Game>().State; } }

        public Point Head
        {
            get { return Part.Head; }
        }

        public Curve(Canvas.Canvas Canvas, Point Location, double Heading, Color Color)
            : base(Canvas)
        {
            PartLength = 250;
            this.Parts = new List<Part>();
            this.Heading = Heading;
            this.Color = Color;

            Add(new Part(this));
            Add(Location);

            EnableCollisions = true;
            Targets.Clear();
            Add(new Target.Target(this, Location, Game.CurveRadius));
        }

        protected void Add(Part Part)
        {
            base.Add(Part);
            this.Part = Part;
        }

        protected void Add(Point Location)
        {
            if (Part.Points.Count >= PartLength)
            {
                Add(new Part(this));
            }

            Part.Points.Add(Location);
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