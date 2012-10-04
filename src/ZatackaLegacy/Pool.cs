using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    class Pool
    {
        public event EventHandler<CollisionEventArgs> Collision = delegate { };

        public Game Game { get; private set; }
        public Size Size { get; private set; }
        public HashSet<Unit> Units { get; private set; }
        public ContainerVisual Visual { get; private set; }

        public Pool(Game Game, Size Size)
        {
            this.Game = Game;
            this.Size = Size;
            this.Units = new HashSet<Unit>();
            this.Visual = new ContainerVisual();
        }

        public void AddUnit(Unit Unit)
        {
            Units.Add(Unit);
            Visual.Children.Add(Unit.Visual);
        }

        public Point RandomLocation() { return RandomLocation(100, 100); }
        public Point RandomLocation(int Margin, double Threshold)
        {
            Point P;
            do
            {
                P = new Point(Tools.Random(Margin, Size.Width - Margin), Tools.Random(Margin, Size.Height - Margin));
            } while (UnitsCollidingWith(P).Count > 0);
            return P;
        }

        public HashSet<Unit> UnitsCollidingWith(Point Point) { return UnitsCollidingWith(Point, 0); }
        public HashSet<Unit> UnitsCollidingWith(Point Point, double Threshold)
        {
            HashSet<Unit> Result = new HashSet<Unit>();
            Game.Pool.Visual.HitTest(new HitTestFilterCallback(delegate(DependencyObject D)
            {
                return D.DependencyObjectType.Name == "UnitVisual" ? HitTestFilterBehavior.Continue : HitTestFilterBehavior.ContinueSkipSelfAndChildren;
            }), new HitTestResultCallback(delegate(HitTestResult R)
            {
                Result.Add(((UnitVisual)R.VisualHit).Unit);
                return HitTestResultBehavior.Continue;
            }), new PointHitTestParameters(Point));
            return Result;
        }

        public void Draw()
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
                if (Source is Curve)
                {
                    Curve C = (Curve)Source;
                    if (C.Head.X < 0 || C.Head.Y < 0) { Collision(this, new CollisionEventArgs(Source, Source)); }
                    if (C.Head.X > Size.Width || C.Head.Y > Size.Height) { Collision(this, new CollisionEventArgs(Source, Source)); }
                }

                if (!Game.Running || !Source.EnableCollisions) { continue; }
                foreach (Unit Target in Source.TestCollision())
                {
                    Collision(this, new CollisionEventArgs(Source, Target));
                }
            }
        }
    }

    class CollisionEventArgs : EventArgs
    {
        public Unit Source { get; private set; }
        public Unit Target { get; private set; }

        public CollisionEventArgs(Unit Source, Unit Target)
        {
            this.Source = Source;
            this.Target = Target;
        }
    }
}