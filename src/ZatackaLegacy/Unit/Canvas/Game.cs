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
<<<<<<< HEAD
            else
            {

                Collision.Result Result = null;
                foreach (Unit U in Units)
                {
                    Result = CollisionsWith(U);
                    if (Result.Any)
                    {
                        Collision(this, U, Result.Colliders, Result.Targets);
                    }
=======

            Collision.Result Result = null;
            List<Collision.Result> Collisions = new List<Collision.Result>();

            foreach (Unit U in Units)
            {
                if (!U.EnableCollisions) { continue; }

                Result = CollisionsWith(U);
                if (Result.Any) { Collisions.Add(Result); }

                Result = U.CollisionsWith(this);
                if (Result.Any) { Collisions.Add(Result); }
>>>>>>> de6cc0ad03c6671a1ef6a465f8b37e2c2c550487

                    Result = U.CollisionsWith(this);
                    if (Result.Any)
                    {
<<<<<<< HEAD
                        Collision(U, this, Result.Colliders, Result.Targets);
                    }

                    foreach (Unit V in Units)
                    {
                        if (U != V || U.SelfCollision)
                        {
                            Result = U.CollisionsWith(V);
                            if (Result.Any)
                            {
                                Collision(U, V, Result.Colliders, Result.Targets);
                            }
                        }
                    }

                    if (U is Game)
                    {
                        U.As<Game>().CheckCollisions();
                    }
=======
                        Result = U.CollisionsWith(V);
                        if (Result.Any) { Collisions.Add(Result); }
                    }
                }
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
>>>>>>> de6cc0ad03c6671a1ef6a465f8b37e2c2c550487
                }
            }
        }
    }
}