﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    public class Pool
    {
        public Game Game;
        public Size Size;
        public List<Unit> Units;

        public Pool(Size Dimensions)
        {
            this.Size = Dimensions;
            this.Units = new List<Unit>();
        }

        public Point RandomLocation() { return RandomLocation(100, 100); }
        public Point RandomLocation(int Margin, int CollisionThreshold)
        {
            Point P;
            do
            {
                P = new Point(Tools.Random(Margin, Size.Width - Margin), Tools.Random(Margin, Size.Height - Margin));
            } while (UnitsAt(P, CollisionThreshold).Count > 0);
            return P;
        }

        public List<Unit> UnitsAt(Point Point) { return UnitsAt(Point, 0); }
        public List<Unit> UnitsAt(Point Point, double Threshold)
        {
            List<Unit> Result = new List<Unit>();
            foreach (Unit U in Units)
            {
                if (U.CollidesWith(Point, Threshold)) { Result.Add(U); }
            }
            return Result;
        }

        public void Render(DrawingContext Context)
        {
            foreach (Unit U in Units)
            {
                U.Render(Context);
            }
        }
    }
}
