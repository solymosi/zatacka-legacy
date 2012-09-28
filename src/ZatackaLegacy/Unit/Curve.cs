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
        public int SegmentCapacity = 250;

        public double Heading;
        public List<Segment> Segments = new List<Segment>();
        public List<Point> Targets = new List<Point>();
        public Segment Head { get { return Segments.Count > 0 ? Segments.Last() : null; } }

        public Curve(Point Location, Color Color, double Radius, double Heading)
            : base(Location, Color, Radius)
        {
            this.Heading = Heading;
            this.Color = Color;

            AddItem(Location);
        }

        public void AddItem(Point Location)
        {
            if (Head == null || Head.Points.Count >= SegmentCapacity)
            {
                Segment Next = new Segment(Color.FromRgb((byte)Tools.Random(128, 255), (byte)Tools.Random(128, 255), (byte)Tools.Random(128, 255)), Radius);
                Segments.Add(Next);
                Visual.Children.Add(Next.Visual);
                Next.Curve = this;
            }

            Head.Points.Add(Location);
        }

        public override void Draw(bool First)
        {
            Head.Draw(true);
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
            AddItem(new Point(Head.Location.X + X, Head.Location.Y + Y));
        }
    }
}