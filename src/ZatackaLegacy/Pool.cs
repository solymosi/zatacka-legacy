using System;
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
        public List<Unit> Units = new List<Unit>();
        public DrawingVisual Visual = new DrawingVisual();

        public Pool(Game Game, Size Size)
        {
            this.Game = Game;
            this.Size = Size;
        }

        public void AddUnit(Unit Unit)
        {
            Units.Add(Unit);
            Unit.Pool = this;
            Visual.Children.Add(Unit.Visual);
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

        public void Draw(bool First)
        {
            foreach (Unit U in Units)
            {
                U.Draw(First);
            }
        }
    }
}