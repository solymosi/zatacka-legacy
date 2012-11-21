using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy
{
    class Slayer : Game
    {
        public Slayer(Size Size)
            : base(Size)
        {
            TestUnit U = new TestUnit(this);
            Pool.Add(U);
        }

        protected override void Update()
        {
            //GoodieIcon goodieIcon=new GoodieIcon(this,Pool.RandomLocation(),GoodieCategory.Weapon,GoodieType.Bazooka);
            //Pool.Add(goodieIcon);
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
