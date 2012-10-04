using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    abstract class Unit
    {
        public Game Game { get; protected set; }
        public long Created { get; private set; }
        public bool EnableCollisions { get; protected set; }
        //public TargetCollection Targets { get; private set; }
        public Geometry CollisionGeometry { get; protected set; }
        public UnitVisual Visual { get; private set; }

        public Unit(Game Game)
        {
            EnableCollisions = false;

            this.Game = Game;
            this.Created = Game.Time;
            //this.Targets = new TargetCollection();
            this.Visual = new UnitVisual(this);
        }

        public abstract void Draw(long Lifetime);

        public virtual HashSet<Unit> TestCollision()
        {
            HashSet<Unit> Units = new HashSet<Unit>();
            Game.Pool.Visual.HitTest(new HitTestFilterCallback(delegate(DependencyObject Element)
            {
                if (Element == Game.Pool.Visual || Element is UnitVisual)
                {
                    Game.Log.Add(Element.GetType().Name);
                    return HitTestFilterBehavior.Continue;
                }
                return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
            }), new HitTestResultCallback(delegate(HitTestResult Result)
            {
                Unit Unit = ((UnitVisual)Result.VisualHit).Unit;
                if (Unit.EnableCollisions && Unit is Part && Unit != ((Curve)this).Part)
                {
                    Units.Add(Unit);
                }
                return HitTestResultBehavior.Continue;
            }), new GeometryHitTestParameters(CollisionGeometry));
            return Units;
        }
    }
}