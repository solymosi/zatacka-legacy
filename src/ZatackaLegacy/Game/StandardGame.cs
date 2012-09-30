using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy
{
    class StandardGame : Game
    {
        public StandardGame(Size Size) : base(Size) { }

        public override void Initialize()
        {
            Pool.Collision += new ZatackaLegacy.Pool.CollisionDelegate(Pool_Collision);
            Start();
        }

        void Pool_Collision(object sender, CollisionEventArgs e)
        {
            Log.Add("Collision: source " + e.Source.GetHashCode().ToString() + "; target " + e.Target.GetHashCode().ToString() + "; collisions " + e.Collisions.Count.ToString() + "; location " + e.Collisions[0].ToString());
            if (e.Source == Players[0].Curve) { Log.Add("GAME OVER."); }
            //if (e.Source == Players[1].Curve) { Log.Add("Piros nyert."); }
            Stop();
        }

        protected override void Update()
        {
            Log.Add(((((Players[0].Curve.Parts.Count - 1) * Players[0].Curve.PartLength) + Players[0].Curve.Parts.Last().Points.Count) * Players.Count).ToString() + " - " + Players[0].Curve.Targets.Count.ToString());
            foreach (Player P in Players)
            {
                P.Curve.Advance();
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
