using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy
{
    class Slayer : Game
    {
        public Slayer(Size Size) : base(Size) { }

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
            Ellipse E = new Ellipse(this, e.Collisions.First(), new Size(10, 10), new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Yellow), null);
            Pool.AddUnit(E);
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
