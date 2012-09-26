using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ZatackaLegacy
{
    public class Player
    {
        public Keys LeftButton;
        public Keys RightButton;
        public Keys ActionButton;

        public Curve Curve;

        public Player(Keys LeftButton, Keys RightButton, Keys ActionButton)
        {
            this.LeftButton = LeftButton;
            this.RightButton = RightButton;
            this.ActionButton = ActionButton;
        }
    }
}
