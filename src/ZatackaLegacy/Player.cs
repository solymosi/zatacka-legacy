using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace ZatackaLegacy
{
    public class Player
    {
        public Game Game;
        public Curve Curve;
        public Color Color;
        public Dictionary<Action, Key> Buttons;

        public Player(Game Game, Key[] Buttons, Color Color)
        {
            this.Game = Game;
            this.Curve = new Curve(Game.Pool.RandomLocation(), Color, Game.CurveRadius, Tools.Random(0, 359));
            Game.Pool.AddUnit(Curve);

            this.Buttons = new Dictionary<Action, Key>();
            this.Buttons.Add(Action.Left, Buttons[0]);
            this.Buttons.Add(Action.Right, Buttons[1]);
            this.Buttons.Add(Action.Shoot, Buttons[2]);

            Game.Players.Add(this);
        }
    }

    public enum Action { Left, Right, Shoot }
}
