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
            Pool.Collision += new EventHandler<CollisionEventArgs>(Pool_Collision);
            Start();
        }

        void Pool_Collision(object sender, CollisionEventArgs e)
        {
            Log.Add("COLLISION -- SOURCE " + e.Source.ToString() + " -- TARGET " + e.Target.ToString() + " -- COUNT " + e.Collisions.Count.ToString() + " -- LOCATION " + e.Collisions[0].ToString());
            if (e.Source == Players[0].Curve) { Log.Add("Zöld nyert."); }
            if (e.Source == Players[1].Curve) { Log.Add("Piros nyert."); }
            Stop();
        }

        protected override void Update()
        {
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
