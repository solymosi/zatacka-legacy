using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZatackaLegacy
{
    public class Pool
    {
        public Game Game;
        public Size Dimensions;
        public List<Unit> Units;

        public Pool(Size Dimensions)
        {
            this.Dimensions = Dimensions;
            this.Units = new List<Unit>();
        }

        public Point RandomLocation() { return RandomLocation(100, 100); }
        public Point RandomLocation(int Margin, int CollisionThreshold)
        {
            Point P;
            do
            {
                P = new Point(Tools.Random(Margin, Dimensions.Width - Margin), Tools.Random(Margin, Dimensions.Height - Margin));
            } while (UnitsAt(P, CollisionThreshold).Count > 0);
            return P;
        }

        public List<Unit> UnitsAt(Point Point) { return UnitsAt(Point, 0); }
        public List<Unit> UnitsAt(Point Point, float Threshold)
        {
            List<Unit> Result = new List<Unit>();
            foreach (Unit U in Units)
            {
                if (U.CollidesWith(Point, Threshold)) { Result.Add(U); }
            }
            return Result;
        }

        public void Draw(Graphics GFX)
        {
            foreach (Unit U in Units)
            {
                U.Draw(GFX);
            }
        }
    }
}