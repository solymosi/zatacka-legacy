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
        public delegate void CollisionDelegate(object sender, CollisionEventArgs e);
        public event CollisionDelegate Collision = delegate { };

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
        public Point RandomLocation(int Margin, double Threshold)
        {
            Point P;
            do
            {
                P = new Point(Tools.Random(Margin, Size.Width - Margin), Tools.Random(Margin, Size.Height - Margin));
            } while (UnitsCollidingWith(new Target(null, P, 0), Threshold).Count > 0);
            return P;
        }

        public List<Unit> UnitsCollidingWith(Target Target) { return UnitsCollidingWith(Target, 0); }
        public List<Unit> UnitsCollidingWith(Target Target, double Threshold)
        {
            List<Unit> Result = new List<Unit>();
            foreach (Unit U in Units)
            {
                if (U.CollisionsWith(Target).Count > 0) { Result.Add(U); }
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

        public void CheckCollision()
        {
            foreach (Unit Source in Units)
            {
                foreach (Unit Target in Units)
                {
                    if (Game.Running && Source.EnableCollision && Target.EnableCollision)
                    {
                        List<Point> Collisions = Source.CollisionsWith(Target);
                        if (Collisions.Count > 0)
                        {
                            Collision(this, new CollisionEventArgs(Source, Target, Collisions));
                        }
                    }
                }
            }
        }
    }

    public class CollisionEventArgs : EventArgs
    {
        public Unit Source;
        public Unit Target;
        public List<Point> Collisions;

        public CollisionEventArgs(Unit Source, Unit Target, List<Point> Collisions)
        {
            this.Source = Source;
            this.Target = Target;
            this.Collisions = Collisions;
        }
    }
}