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
            foreach (Player P in Players)
            {
                P.Curve = new Curve(Pool, Pool.RandomLocation(), CurveRadius);
            }
        }

        public override void Tick()
        {
            
        }

        public override void Input(Keys Button)
        {
            
        }
    }
}
