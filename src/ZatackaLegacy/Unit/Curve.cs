using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Effects;

namespace ZatackaLegacy
{
    class Curve : Ellipse
    {
        public int PartLength { get; private set; }
        public int HeadLength { get; private set; }
        public double Heading { get; private set; }
        public List<Part> Parts { get; private set; }
        public Part Part { get; private set; }

        public Point Head
        {
            get { return Part.Head; }
        }

        public Curve(Game Game, Point StartLocation, double StartHeading, Brush Fill)
            : base(Game, StartLocation, new Size(Game.CurveRadius * 2, Game.CurveRadius * 2), Fill, null)
        {
            PartLength = 50;
            HeadLength = 10;

            Heading = StartHeading;
            Fill.Freeze();

            Parts = new List<Part>();
            Part = new Part(this);
            Visual.Children.Add(Part.Visual);
            AddItem(StartLocation);

            EnableCollisions = true;
        }

        protected void AddPart(Part Part)
        {
            Parts.Add(Part);
            Visual.Children.Add(Part.Visual);
        }

        protected void AddItem(Point Location)
        {
            Part.Points.Add(Location);
            if(Part.Points.Count > HeadLength)
            {
                Point Move = Part.Points.First();
                Part.Points.Remove(Move);
                if(!Parts.Any() || Parts.Last().Points.Count >= PartLength)
                {
                    Part New = new Part(this);
                    AddPart(New);
                }
                Parts.Last().Points.Add(Move);
            }
            CollisionGeometry = new EllipseGeometry(Location, Size.Width / 2, Size.Height / 2);
        }

        public override void Draw(long Lifetime)
        {
            Part.Draw(Lifetime);
            if (Parts.Any()) { Parts.Last().Draw(Lifetime); }
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
            double X = Math.Sin(Tools.DegreeToRadian(Heading)) * Game.MovementSpeed  / ((StandardGame)Game).Acc;
            double Y = Math.Cos(Tools.DegreeToRadian(Heading)) * Game.MovementSpeed * -1 / ((StandardGame)Game).Acc;

            Point Next = new Point(Head.X + X, Head.Y + Y);
            AddItem(Next);
        }
    }
}