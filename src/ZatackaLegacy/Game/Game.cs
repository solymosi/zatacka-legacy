using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace Zatacka.Game
{
    abstract class Game : State.Screen
    {
        public double GoodieIconRadius { get; protected set; }
        public double CurveRadius { get; protected set; }
        public double SteeringSensitivity { get; protected set; }
        public double MovementSpeed { get; protected set; }
        public List<Player> Players { get; private set; }

        public new Unit.Canvas.Game Canvas
        {
            get { return base.Canvas.As<Unit.Canvas.Game>(); }
            protected set { base.Canvas = value; }
        }

        public Game(Zatacka.State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            GoodieIconRadius = 10;
            Time = 0;
            CurveRadius = 3;
            SteeringSensitivity = 5;
            MovementSpeed = 3;

            Canvas = new Unit.Canvas.Game(this, Dispatcher.Size);
            Players = new List<Player>();
        }

        public override void Execute()
        {
            base.Execute();
            this.Input();
        }

        public void Input()
        {
            foreach (Player Player in Players)
            {
                Player.Input();
            }
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Escape)
            {
                Dispatcher.Change(Zatacka.State.Dispatcher.State.Menu);
            }
        }

        abstract public void Input(Player Player, Action Action);

        public enum State
        {
            Start = 1,
            RoundStart,
            Playing,
            RoundEnd,
            End
        }
    }
}