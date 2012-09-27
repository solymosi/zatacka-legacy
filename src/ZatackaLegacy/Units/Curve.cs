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
        public double Heading;
        public Color Color;
        public List<Point> Points = new List<Point>();
        public Point Head { get { return Points.Last(); } }

        public Curve(Pool Pool, Point Location, double Heading, double Radius, Color Color)
            : base(Pool, Location, Radius)
        {
            this.Heading = Heading;
            this.Color = Color;
            Points.Add(Location);
        }

        public override void Render(DrawingContext Context)
        {
            foreach (Point P in Points)
            {
                Context.DrawEllipse(new SolidColorBrush(Color), null, P, Radius, Radius);
            }
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
            Point Distance = new Point((float)(Math.Sin(Tools.DegreeToRadian(Heading)) * Pool.Game.MovementSpeed), (float)(Math.Cos(Tools.DegreeToRadian(Heading)) * Pool.Game.MovementSpeed * -1));
            Location = new Point(Head.X + Distance.X, Head.Y + Distance.Y);
            Points.Add(Location);
            //Program.Form.Print(Points.Count.ToString() + ": " + System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime.ToString());
        }
    }
}