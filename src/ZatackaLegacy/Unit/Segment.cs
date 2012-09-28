﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    public class Segment : Unit
    {
        public Curve Curve;
        public List<Point> Points = new List<Point>();
        public new Point Location { get { return Points.Last(); } }

        public Segment(Color Color, double Radius)
            : base(new Point(0, 0), Color, Radius) { }

        public override void Draw(bool First)
        {
            using (DrawingContext Context = Visual.RenderOpen())
            {
                foreach (Point P in Points)
                {
                    Context.DrawEllipse(new SolidColorBrush(Color), null, P, Radius, Radius);
                }
            }
        }
    }
}