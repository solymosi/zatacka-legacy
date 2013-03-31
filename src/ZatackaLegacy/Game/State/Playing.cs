using System;
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

            foreach (Player.Player P in Game.Players)
            {
                if (P.Curve == From)
                {
                    Game.Dispatcher.Log.Add("Bukta: " + P.Name);
                    P.Curve.Kill();
                }
                else
                {
                    if (P.Curve.Alive)
                    {
                        P.Score += 1;
                    }
                }
            }


            if (Game.PlayersAlive.Count() == 1)
            {
                foreach (Player.Player P in Game.PlayersAlive)
                {
                    if (P.Curve.Alive)
                    {
                        P.Score += 2;
                        P.Curve.Kill();
                    }
                }
            }

            Player.Player FirstPlayer = null;
            Player.Player SecondPlayer = null;

            foreach (Player.Player P in Game.Players)
            {
                if (FirstPlayer == null || P.Score > FirstPlayer.Score)
                {
                    FirstPlayer = P;
                }
            }
            foreach (Player.Player P in Game.Players)
            {
                if (P != FirstPlayer && (SecondPlayer == null || P.Score > SecondPlayer.Score))
                {
                    SecondPlayer = P;
                }
            }

            if (FirstPlayer.Score >= (Game.Players.Count * 10) && (SecondPlayer.Score + 2) <= FirstPlayer.Score)
            {
                foreach (Player.Player P in Game.Players)
                {
                    P.Curve.Kill();
                }

                Game.Manager.Change(Zatacka.Game.Game.State.End);
                return;
            }



            if (Game.PlayersAlive.Count() == 0)
            {
                Game.Dispatcher.Log.Add("=== FINAL SCORE ===");
                foreach (Player.Player P in Game.Players)
                {
                    Game.Dispatcher.Log.Add(P.Name + ": " + P.Score);
                }
                Game.Manager.Change(Zatacka.Game.Game.State.RoundEnd);
                return;
            }
        }



        public override void Execute()
        {
            foreach (Player.Player P in Game.PlayersAlive)
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

        public override void Input(Player.Player Player, Player.Action Action)
        {
            switch (Action)
            {
                case Zatacka.Player.Action.Left:
                    Player.Curve.Left();
                    break;
                case Zatacka.Player.Action.Right:
                    Player.Curve.Right();
                    break;
                case Zatacka.Player.Action.Trigger:
                    break;
            }
        }
    }
}