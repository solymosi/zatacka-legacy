using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    class Curve : Unit
    {
        public int PartLength { get; private set; }
        public double Heading { get; private set; }
        public Color Color { get; private set; }
        public Target Target { get; private set; }
        public Part Part { get; private set; }
        public List<Part> Parts { get; private set; }

        public Point Head
        {
            get { return Part.Head; }
        }

        public Curve(Game Game, Point Location, double Heading, Color Color)
            : base(Game)
        {
            PartLength = 250;
            this.Parts = new List<Part>();
            this.Heading = Heading;
            this.Color = Color;

            AddPart(new Part(this));
            AddItem(Location);

            EnableCollisions = true;
            Targets.Clear();
            AddTarget(new Target(this, Location, Game.CurveRadius));
        }

        protected void AddPart(Part Part)
        {
            this.Part = Part;
            Parts.Add(Part);
            Children.Add(Part);
        }

        protected void AddItem(Point Location)
        {
            if (Part.Points.Count >= PartLength) { AddPart(new Part(this)); }
            Part.Points.Add(Location);
        }

        protected void AddTarget(Target Target)
        {
            this.Target = Target;
            Targets.Add(Target);
        }

        public override void Draw(long Lifetime)
        {
            Part.Draw(Lifetime);
        }

        public void Left()
        {
            Heading -= Game.SteeringSensitivity;
            if (Heading < 0) { Heading = 360 + Heading; }
        }

        public void Right()
        {
            Heading += Game.SteeringSensitivity;
            if (Heading >= 360) { Heading = 360 - Heading; }
        }

        public void Advance()
        {
            
                double X = Math.Sin(Tools.DegreeToRadian(Heading)) * Game.MovementSpeed;
                double Y = Math.Cos(Tools.DegreeToRadian(Heading)) * Game.MovementSpeed * -1;

                Point Next = new Point(Head.X + X, Head.Y + Y);
                AddItem(Next);

            /*if (Tools.Distance(Head, Target.Location) >= Game.CurveRadius * 2)
            {
                AddTarget(new Target(this, Next, Game.CurveRadius));
            }*/
        }
    }
}