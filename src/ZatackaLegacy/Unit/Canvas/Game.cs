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

                    Result = U.CollisionsWith(this);
                    if (Result.Any)
                    {
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
                }
            }
        }
    }
}