using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy
{
    public class StandardGame : Game
    {
        public StandardGame(Size Size) : base(Size) { }

        public override void Initialize()
        {
            Pool.Collision += new ZatackaLegacy.Pool.CollisionDelegate(Pool_Collision);
            Running = true;
        }

        void Pool_Collision(object sender, CollisionEventArgs e)
        {
            Log.Messages.Add("Collision: source " + e.Source.GetHashCode().ToString() + "; target " + e.Target.GetHashCode().ToString() + "; collisions " + e.Collisions.Count.ToString() + "; location " + e.Collisions[0].ToString());
            if (e.Source == Players[0].Curve) { Log.Messages.Add("Zöld nyert."); }
            if (e.Source == Players[1].Curve) { Log.Messages.Add("Piros nyert."); }
            Running = false;
        }

        public override void Update()
        {
            if (Running)
            {
                //Log.Messages.Add(((((Players[0].Curve.Parts.Count - 1) * Players[0].Curve.PartLength) + Players[0].Curve.Head.Points.Count) * Players.Count).ToString() + " - " + Players[0].Curve.Targets.Count.ToString());
                foreach (Player P in Players)
                {
                    P.Curve.Advance();
                }
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
                case Action.Shoot:
                    break;
            }
        }
    }
}
