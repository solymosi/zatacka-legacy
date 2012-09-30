using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    class Curve : Ellipse
    {
        public int PartLength { get; private set; }
        public double Heading { get; private set; }
        public Target Target { get; private set; }
        public List<Part> Parts { get; private set; }
        public Part Part { get; private set; }

        public Point Head
        {
            get { return Part != null ? Part.Head : Center; }
        }

        public Curve(Game Game, Point StartLocation, double StartHeading, Brush Fill)
            : base(Game, StartLocation, new Size(Game.CurveRadius * 2, Game.CurveRadius * 2), Fill, null)
        {
            PartLength = 250;

            Heading = StartHeading;

            Parts = new List<Part>();
            AddPart(new Part(this));
            AddItem(StartLocation);

            EnableCollisions = true;
            AddTarget(new Target(this, Center, Game.CurveRadius));
        }

        protected void AddPart(Part Part)
        {
            this.Part = Part;
            Parts.Add(Part);
            Visual.Children.Add(Part.Visual);
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

        public override List<Point> CollisionsWith(Target Target, double Threshold)
        {
            List<Point> Result = new List<Point>();
            foreach (HashSet<Target> Set in Targets.Near(Target.Location, Target.Radius * 2 + Threshold))
            {
                foreach (Target T in Set)
                {
                    if (T.CollidesWith(Target, -1)) { Result.Add(T.Location); }
                }
            }
            return Result;
        }

        public override List<Point> CollisionsWith(Unit Unit, double Threshold)
        {
            return Unit.CollisionsWith(Target);
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

            if (Tools.Distance(Head, Target.Location) >= Game.CurveRadius * 2)
            {
                AddTarget(new Target(this, Next, Game.CurveRadius));
            }
        }
    }
}