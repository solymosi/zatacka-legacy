﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Zatacka.Game.State
{
    class Playing : State
    {
        public Playing(Zatacka.Game.Game Game)
            : base(Game)
        {
            Game.Arena.Collision += new Unit.Canvas.Game.CollisionEvent(Collision);
        }

        public void Collision(Unit.Unit From, Unit.Unit To, List<Unit.Collision.Target> Colliders, List<Unit.Collision.Target> Targets)
        {
            if (!Game.Manager.Is(Zatacka.Game.Game.State.Playing)) { return; }

            Game.Dispatcher.Log.Add("COLLISION: " + From.ToString() + " ==> " + To.ToString());
            foreach (Player P in Game.Players)
            {
                if (P.Curve == From)
                {
                    Game.Dispatcher.Log.Add("Bukta: " + P.Color);
                    P.Curve.IsAlive = false;
                    P.Curve.EnableCollisions = false;
                }
                else
                {
                    if (P.Curve.IsAlive)
                    {
                        P.Score += 1;//itt kéne beolvasni a Slayer-hez tartozó pontszámokat
                    }
                }
                Game.Dispatcher.Log.Add("COLLISION: " + From.ToString() + " pontszám: " + P.Score);
            }
            if (Game.PlayersAlive.Count() == 1)
            {
                foreach (Player P in Game.PlayersAlive)
                {
                    if (P.Curve.IsAlive)
                    {
                        P.Score += 2;
                        P.Curve.IsAlive = false;
                    }
                }

            }
            if (Game.PlayersAlive.Count() == 0)
            {
                Game.Dispatcher.Log.Add("=== FINAL SCORE ===");
                foreach (Player P in Game.Players)
                {
                    Game.Dispatcher.Log.Add(P.Color + ": " + P.Score);
                }
                Game.Manager.Change(Zatacka.Game.Game.State.RoundEnd);
            }
        }

        public override void Execute()
        {
            foreach (Player P in Game.PlayersAlive)
            {
                P.Curve.Advance();
            }
            Game.Arena.CheckCollisions();
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Escape)
            {
                Game.Manager.Change(Zatacka.Game.Game.State.Paused);
            }

            /* TEMP FOR TESTING */
            if (Button == Key.Insert)
            {
                Game.Manager.Change(Zatacka.Game.Game.State.RoundEnd);
            }
            if (Button == Key.PageUp)
            {
                Game.Manager.Change(Zatacka.Game.Game.State.End);
            }
        }

        public override void Input(Player Player, Action Action)
        {
            switch (Action)
            {
                case Action.Left:
                    Player.Curve.Left();
                    break;
                case Action.Right:
                    Player.Curve.Right();
                    break;
                case Action.Trigger:
                    break;
            }
        }
    }
}
