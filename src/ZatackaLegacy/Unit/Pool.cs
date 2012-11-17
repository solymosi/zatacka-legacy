using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    class Pool : Unit
    {
        public event EventHandler<CollisionEventArgs> Collision = delegate { };

        public Size Size { get; private set; }
        public HashSet<Unit> Units { get; private set; }

        public Pool(Game Game, Size Size)
            : base(Game)
        {
            this.Size = Size;
            this.Units = new HashSet<Unit>();
        }

        public void AddUnit(Unit Unit)
        {
            Units.Add(Unit);
            Children.Add(Unit);
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

        public override void Draw(long Lifetime)
        {
            foreach (Unit Unit in Units)
            {
                Unit.Draw(Game.Time - Unit.Created);
            }
        }

        public void CheckCollision()
        {
            HashSet<Unit> Units = new HashSet<Unit>();
            foreach (Unit Unit in this.Units) { Units.Add(Unit); }

            foreach (Unit Source in Units)
            {
                foreach (Unit Target in Units)
                {
                    if (Game.Running && Source.EnableCollisions && Target.EnableCollisions)
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

    class CollisionEventArgs : EventArgs
    {
        public Unit Source { get; private set; }
        public Unit Target { get; private set; }
        public List<Point> Collisions { get; private set; }

        public CollisionEventArgs(Unit Source, Unit Target, List<Point> Collisions)
        {
            this.Source = Source;
            this.Target = Target;
            this.Collisions = Collisions;
        }
    }
}