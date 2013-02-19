using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;

namespace Zatacka.State
{
    class Dispatcher : State<Dispatcher.State>
    {
        public long Time { get; protected set; }
        public Size Size { get; private set; }
        public double Interval { get; private set; }
        public DispatcherTimer Timer { get; private set; }
        public Unit.Canvas.Dispatcher Canvas { get; private set; }
        public Unit.Log Log { get; protected set; }
        public event EventHandler Ended = delegate { };

        public Dispatcher(Size Size)
        {
            this.Size = Size;
            this.Interval = 20;

            this.Canvas = new Unit.Canvas.Dispatcher(this, Size);

            this.Log = new Unit.Log(Canvas);
            this.Canvas.Add(Log);

            this.Timer = new DispatcherTimer();
            this.Timer.Interval = TimeSpan.FromMilliseconds(Interval);
            this.Timer.Tick += new EventHandler(Tick);

            Initialize();
        }

        protected void Initialize()
        {
            /* Temporary entries, todo: implement final */
            Add(State.Menu, new Menu.Menu(this));
            Add(State.Game, new Game.Slayer(this));

            Player P = new Player(this[State.Game].As<Game.Game>(), "Player 1", System.Windows.Media.Colors.Red);
            P.Buttons.Add(Key.D1, Action.Left);
            P.Buttons.Add(Key.Q, Action.Right);
            P.Buttons.Add(Key.D2, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(P);

            Player Q = new Player(this[State.Game].As<Game.Game>(), "Player 2", System.Windows.Media.Colors.Green);
            Q.Buttons.Add(Key.M, Action.Left);
            Q.Buttons.Add(Key.OemComma, Action.Right);
            Q.Buttons.Add(Key.K, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(Q);

            Player R = new Player(this[State.Game].As<Game.Game>(), "Player 3", System.Windows.Media.Colors.Yellow);
            R.Buttons.Add(Key.Left, Action.Left);
            R.Buttons.Add(Key.Up, Action.Right);
            R.Buttons.Add(Key.Down, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(R);
            /* ---------- */
        }

        private void Tick(object sender, EventArgs e)
        {
            Execute();
            Canvas.Execute();
            Time++;
        }

        public override void Enter()
        {
            Change(State.Menu);
            Timer.Start();
        }

        public override void Exit()
        {
            Timer.Stop();
            Reset();
            Ended(this, new EventArgs());
        }

        public void Input(Key Button)
        {
            if (Active) { Current.As<Screen>().Input(Button); }
        }

        public void Input(MouseButton Button)
        {
            if (Active) { Current.As<Screen>().Input(Button); }
        }

        public enum State
        {
            Game = 1,
            Menu = 2
        }
    }
}
