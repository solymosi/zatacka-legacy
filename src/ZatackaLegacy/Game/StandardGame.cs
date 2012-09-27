using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy
{
    public class StandardGame : Game
    {
        //public new double MovementSpeed = 0.03;
        public int Acc = 1;

        public StandardGame(Size Size) : base(Size) { }

        public override void Initialize()
        {

        }

        public override void Update()
        {
            foreach (Player P in Players)
            {
                for (int i = 0; i < Acc; i++)
                {
                    MovementSpeed = 3.0 / (double)Acc;
                    P.Curve.Advance();
                }
                //P.Curve.Advance();
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
