using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Unit.Canvas
{
    class Game : Screen
    {
        public delegate void CollisionEvent(Unit From, Unit To, List<Collision.Target> Colliders, List<Collision.Target> Targets);
        public event CollisionEvent Collision = delegate { };

        public new Zatacka.Game.Game State
        {
            get { return base.State.As<Zatacka.Game.Game>(); }
        }

        public Game(Zatacka.Game.Game Game, Size Size) : this(Game, Size.ToRect()) { }
        public Game(Zatacka.Game.Game Game, Rect Bounds)
            : base(Game, Bounds)
        {
            this.EnableCollisions = false;
        }

        public void CheckCollisions()
        {
            if (!EnableCollisions)
            {
                //throw new InvalidOperationException("Collisions are not enabled for this Canvas.");
            }

            Collision.Result Result = null;
            List<Collision.Result> Collisions = new List<Collision.Result>();

            foreach (Unit U in Units)
            {
                if (!U.EnableCollisions) { continue; }

                Result = CollisionsWith(U);
                if (Result.Any) { Collisions.Add(Result); }

                Result = U.CollisionsWith(this);
                if (Result.Any) { Collisions.Add(Result); }
            }

            foreach (Collision.Result R in Collisions)
            {
                Collision(R.From, R.To, R.Colliders, R.Targets);
            }

            foreach (Unit Unit in Units)
            {
                if (Unit is Game && Unit.EnableCollisions)
                {
                    Unit.As<Game>().CheckCollisions();
                }
            }
        }
    }
}