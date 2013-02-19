using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Zatacka.Game.State
{
    class Playing : State
    {
        public bool IsEveryBodyDead { get; private set; }/* BarnaBalu */
        public Playing(Zatacka.Game.Game Game)
            : base(Game)
        {
            Game.Arena.Collision += new Unit.Canvas.Game.CollisionEvent(Collision);
            IsEveryBodyDead = false;/* BarnaBalu */
        }

        public void Collision(Unit.Unit From, Unit.Unit To, List<Unit.Collision.Target> Colliders, List<Unit.Collision.Target> Targets)
        {
            Game.Dispatcher.Log.Add("COLLISION: " + From.ToString() + " ==> " + To.ToString());
            /* BarnaBalu */
            int NumberOfAlivePlayers = 0;
            foreach (Player P in Game.Players)
            {
                if (P.Curve == From && P.IsAlive == true)
                {
                    Game.Dispatcher.Log.Add("Bukta: " + P.Color);
                    P.IsAlive = false;
                    P.Curve.EnableCollisions = false;
                }
                else
                {
                    if (P.IsAlive == true)
                    {
                        P.Score += 1;//itt kéne beolvasni a Slayer-hez tartozó pontszámokat
                        NumberOfAlivePlayers += 1;
                    }
                }
                Game.Dispatcher.Log.Add("COLLISION: " + From.ToString() + " pontszám: " + P.Score);
            }
            if (NumberOfAlivePlayers == 1)
            {
                foreach (Player P in Game.Players)
                {
                    if (P.IsAlive == true)
                    {
                        P.Score += 2;
                        P.IsAlive = false;
                        IsEveryBodyDead = true;
                    }
                }
                
            }
            /* -- BarnaBalu */
        }

        public override void Execute()
        {
            foreach (Player P in Game.Players)
            {
                /* BarnaBalu if köret */
                if(P.IsAlive == true)
                    P.Curve.Advance();
            }
            /* BarnaBalu */
            if (IsEveryBodyDead == false)
            {
                Game.Arena.CheckCollisions();//eredeti
            }
            else
            {
                Game.Dispatcher.Log.Add("Final Score:");
                foreach (Player P in Game.Players)
                {
                    Game.Dispatcher.Log.Add(P.Color + ": " + P.Score);
                }
                Game.Manager.Change(Zatacka.Game.Game.State.RoundEnd);
            }
            /* -- BarnaBalu */
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
