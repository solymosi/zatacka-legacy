using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZatackaLegacy
{
    public class Curve : Unit
    {
        public float Heading;
        public Color Color;
        public List<PointF> Points = new List<PointF>();
        public PointF Head { get { return Points[Points.Count - 1]; } }

        public Curve(Pool Pool, PointF Location, float Heading, float Radius, Color Color)
            : base(Pool, Location, Radius)
        {
            this.Heading = Heading;
            this.Color = Color;
            Points.Add(Location);
        }

        public override void Draw(Graphics GFX)
        {
            foreach (PointF P in Points)
            {
                GFX.FillEllipse(new SolidBrush(Color), P.X - Radius, P.Y - Radius, Radius * 2, Radius * 2);
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
            PointF Distance = new PointF((float)(Math.Sin(Tools.DegreeToRadian(Heading)) * Pool.Game.MovementSpeed), (float)(Math.Cos(Tools.DegreeToRadian(Heading)) * Pool.Game.MovementSpeed * -1));
            Location = new PointF(Head.X + Distance.X, Head.Y + Distance.Y);
            Points.Add(Location);
        }
    }
}