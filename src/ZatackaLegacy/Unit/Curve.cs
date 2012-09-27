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
        public Unit Head;

        public Curve(Point Location, Color Color, double Radius, double Heading)
            : base(Location, Color, Radius)
        {
            this.Heading = Heading;
            this.Color = Color;

            Head = new Unit(Location, Color, Radius);
            Visual.Children.Add(Head.Visual);
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
            Head = new Unit(new Point(Head.Location.X + X, Head.Location.Y + Y), Color, Radius);
            Visual.Children.Add(Head.Visual);
        }
    }
}