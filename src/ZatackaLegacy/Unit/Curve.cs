using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    public class Curve : Unit
    {
        public int PartLength = 250;

        public double Heading;
        public Target Target;
        public List<Part> Parts = new List<Part>();

        public Part Head
        {
            get { return Parts.Count > 0 ? Parts.Last() : null; }
        }

        public Curve(Point Location, Color Color, double Radius, double Heading)
            : base(Location, Color, Radius)
        {
            this.Heading = Heading;
            this.Color = Color;

            AddItem(Location);
            Target = Targets.First();
            EnableCollision = true;
        }

        public void AddItem(Point Location)
        {
            if (Head == null || Head.Points.Count >= PartLength)
            {
                Part Next = new Part(Color, Radius);
                Parts.Add(Next);
                Visual.Children.Add(Next.Visual);
                Next.Curve = this;
            }
            Head.Points.Add(Location);
        }

        public override void Draw(bool First)
        {
            Head.Draw(true);
        }

        public override List<Point> CollisionsWith(Target Target, double Threshold)
        {
            List<Point> Result = new List<Point>();
            foreach (HashSet<Target> Set in Targets.Near(Target.Location, Target.Radius * 2 + Threshold))
            {
                foreach (Target T in Set)
                {
                    if (T.CollidesWith(Target, -1))
                    {
                        Result.Add(T.Location);
                    }
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
            Heading -= Pool.Game.SteeringSensitivity;
            if (Heading < 0) { Heading = 360 + Heading; }
        }

        public void Right()
        {
            Heading += Pool.Game.SteeringSensitivity;
            if (Heading >= 360) { Heading = 360 - Heading; }
        }

        public void Advance()
        {
            double X = Math.Sin(Tools.DegreeToRadian(Heading)) * Pool.Game.MovementSpeed;
            double Y = Math.Cos(Tools.DegreeToRadian(Heading)) * Pool.Game.MovementSpeed * -1;
            Point Next = new Point(Head.Location.X + X, Head.Location.Y + Y);
            AddItem(Next);

            if (Tools.Distance(Head.Location, Target.Location) >= Radius * 2)
            {
                Target = new Target(this, Next, Radius);
                Targets.Add(Target);
            }
        }
    }
}