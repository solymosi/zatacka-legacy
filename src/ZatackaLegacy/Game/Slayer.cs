using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Game
{
    class Slayer : Game
    {
        public Slayer(Zatacka.State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            
        }

        protected override void Update()
        {
            foreach (Player P in Players)
            {
                P.Curve.Advance();
            }

            Dispatcher.Log.Add((Players[0].Curve.Bits.Count * Players.Count).ToString());
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
