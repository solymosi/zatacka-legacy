using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Game
{
    class Slayer : Game
    {
        public Slayer(Size Size)
            : base(Size)
        {
            Unit.TestUnit U = new Unit.TestUnit(Canvas);
            Canvas.Add(U);
        }

        protected override void Update()
        {
            Unit.Goodie goodieIcon = new Unit.Goodie(Canvas, new Point(Tools.Random(0, 500), Tools.Random(0, 500)), Goodie.Category.Weapon, Goodie.Type.Bazooka);
            Canvas.Add(goodieIcon);
            foreach (Player P in Players)
            {
                P.Curve.Advance();
            }

            //Canvas.Draw();
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
