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
        public Brush Fill { get; private set; }
        public Dictionary<Key, Action> Buttons { get; private set; }

        public Player(Game Game, Brush Fill)
        {
            this.Game = Game;
            this.Fill = Fill;
            this.Buttons = new Dictionary<Key, Action>();

            this.Curve = new Curve(Game, Game.Pool.RandomLocation(), Tools.Random(0, 359), Fill);
            Game.Pool.AddUnit(Curve);
        }

        public void Bind(Key Button, Action Action)
        {
            Buttons.Add(Button, Action);
        }
    }

    public enum Action { Left, Right, Shoot }
}