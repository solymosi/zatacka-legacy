using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ZatackaLegacy
{
    public class StandardGame : Game
    {
        public StandardGame(Pool Pool) : base(Pool) { }

        public override void Initialize()
        {

        }

        public override void Update()
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
                default:
                    break;
            }
        }
    }
}
