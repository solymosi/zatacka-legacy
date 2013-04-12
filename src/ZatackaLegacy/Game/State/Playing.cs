using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Game.State
{
    class Playing : State
    {
        public long NextGoodie { get; private set; }

        public Playing(Zatacka.Game.Game Game)
            : base(Game)
        {
            Game.Arena.Collision += new Unit.Canvas.Game.CollisionEvent(Collision);
        }

        public void Collision(Unit.Unit From, Unit.Unit To, List<Unit.Collision.Target> Colliders, List<Unit.Collision.Target> Targets)
        {
            if (!Game.Manager.Is(Zatacka.Game.Game.State.Playing)) { return; }

            Game.Dispatcher.Log.Add("COLLISION: " + From.ToString() + " ==> " + To.ToString());

            if (To is Unit.Game.Curve.Curve || To is Unit.Canvas.Game)
            {

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
            else if (To is Unit.Game.Goodie.Icon)
            {
                Zatacka.Goodie.Goodie g = (Zatacka.Goodie.Goodie)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("Zatacka.Goodie.Weapon." + To.As<Unit.Game.Goodie.Icon>().Type.ToString());
                foreach (Player.Player p in Game.Players)  //DG
                {
                    if (p.Curve == From)
                    {
                        p.Goodies.Add(g);
                        g.Player = p;
                        this.Game.Arena.Remove(To.As<Unit.Shape.Ellipse>());

                        foreach (Goodie.Goodie item in p.Goodies)
                        {
                            Game.Dispatcher.Log.Add(p.Color.ToString() + " " + item.ToString() + " " + item.Active.ToString());
                        }
                    }
                }
                //From.As<Zatacka.Player.Player>();
                //To.As<Zatacka.Goodie.Goodie>().Player = From.As<Zatacka.Player.Player>();
                //From.As<Zatacka.Player.Player>().Goodies.Add(To.As<Zatacka.Goodie.Goodie>());
                //this.Game.Arena.Remove(To.As<Unit.Shape.Ellipse>());

                //object goodie = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("Zatacka.Goodie.Weapon.Bazooka");
                
                //Game.Dispatcher.Log.Add(From.As<Zatacka.Player.Player>().Goodies[0].ToString());
                
                //Game.Dispatcher.Log.Add("COLLIDED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                //To.EnableCollisions = false;
                //To.As<Unit.Shape.Ellipse>().Fill = Brushes.Gray;
            }
        }

        private void SetNextGoodie()
        {
            NextGoodie = Game.Time + Tools.Random(50, 100);
        }

        private void GenerateRandomGoodie()
        {
            Unit.Game.Goodie.Icon Icon = new Unit.Game.Goodie.Icon(Game.Arena, new Point(Tools.Random(0, Game.Arena.Size.Width), Tools.Random(0, Game.Arena.Size.Height)), Goodie.Category.Weapon, Goodie.Type.Bazooka);
            Game.Arena.Add(Icon);
        }

        public override void Enter()
        {
            SetNextGoodie();
        }

        public override void Execute()
        {
            foreach (Player.Player P in Game.PlayersAlive)
            {
                P.Curve.Advance();
            }
            Game.Arena.CheckCollisions();

            if (Game.Time == NextGoodie)
            {
                GenerateRandomGoodie();
                SetNextGoodie();
            }
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
                    Game.Dispatcher.Log.Add("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    foreach (Goodie.Goodie g in Player.Goodies) //DG
                    {
                        if (g.Active == false)
                        {
                            g.Active = true;
                            break;
                        }
                    }
                    break;
            }
        }
    }
}