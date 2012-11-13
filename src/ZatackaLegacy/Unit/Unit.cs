using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    abstract class Unit : DrawingVisual
    {
        public Game Game { get; protected set; }
        public long Created { get; private set; }
        public bool EnableCollisions { get; protected set; }
        public TargetCollection Targets { get; private set; }

        public Unit(Game Game)
        {
            EnableCollisions = false;

            this.Game = Game;
            this.Created = Game.Time;
            this.Targets = new TargetCollection();
        }

        public abstract void Draw(long Lifetime);

        public List<Point> CollisionsWith(Target Target) { return CollisionsWith(Target, 0); }
        public virtual List<Point> CollisionsWith(Target Target, double Threshold)
        {
            List<Point> Result = new List<Point>();
            foreach (Target T in Targets)
            {
                if (T.CollidesWith(Target)) { Result.Add(T.Location); }
            }
            return Result;
        }
        public List<Point> CollisionsWith(Unit Unit) { return CollisionsWith(Unit, 0); }
        public virtual List<Point> CollisionsWith(Unit Unit, double Threshold)
        {
            List<Point> Result = new List<Point>();
            foreach (Target T in Targets)
            {
                Result.AddRange(Unit.CollisionsWith(T, Threshold));
            }
            return Result;
        }
    }
}