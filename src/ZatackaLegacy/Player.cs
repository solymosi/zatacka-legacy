using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace ZatackaLegacy
{
    class Player
    {
        public Game Game { get; private set; }
        public Curve Curve { get; private set; }
        public Color Color { get; private set; }
        public Dictionary<Key, Action> Buttons { get; private set; }
        public int Score { get; set; }

        public Player(Game Game, Color Color)
        {
            this.Game = Game;
            this.Color = Color;
            this.Buttons = new Dictionary<Key, Action>();

            this.Curve = new Curve(Game, Game.Pool.RandomLocation(), Tools.Random(0, 359), Color);
            Game.Pool.AddUnit(Curve);
        }

        public void Bind(Key Button, Action Action)
        {
            Buttons.Add(Button, Action);
        }
    }

    public enum Action { Left, Right, Shoot }
}