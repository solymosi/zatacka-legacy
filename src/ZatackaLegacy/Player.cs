using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    class Player
    {
        public Game Game { get; private set; }
        public Curve Curve { get; private set; }
        public Color Color { get; private set; }
        public Dictionary<Key, Action> Buttons { get; private set; }
        public int Score { get; set; }
        public List<Goodie> Goodies { get; private set; }

        public Player(Game Game, Color Color)
        {
            this.Game = Game;
            this.Color = Color;
            this.Buttons = new Dictionary<Key, Action>();
            this.Goodies = new List<Goodie>();

            this.Curve = new Curve(Game, new Point(Tools.Random(0, 800), Tools.Random(0, 800)), Tools.Random(0, 359), Color);
            Game.Pool.Add(Curve);
        }

        public void Bind(Key Button, Action Action)
        {
            Buttons.Add(Button, Action);
        }
    }

    public enum Action { Left, Right, Shoot }
}