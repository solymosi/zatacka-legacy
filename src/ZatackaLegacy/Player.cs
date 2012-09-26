using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ZatackaLegacy
{
    public class Player
    {
        public Game Game;
        public Curve Curve;
        public Color Color;
        public Dictionary<Action, Keys> Buttons;

        public Player(Game Game, Keys[] Buttons, Color Color)
        {
            this.Game = Game;
            this.Curve = new Curve(Game.Pool, Game.Pool.RandomLocation(), Tools.Random(0, 359), Game.CurveRadius, Color);

            this.Buttons = new Dictionary<Action, Keys>();
            this.Buttons.Add(Action.Left, Buttons[0]);
            this.Buttons.Add(Action.Right, Buttons[1]);
            this.Buttons.Add(Action.Shoot, Buttons[2]);

            Game.Players.Add(this);
        }
    }

    public enum Action { Left, Right, Shoot }
}
