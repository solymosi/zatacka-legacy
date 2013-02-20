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
        public Game.Game Game { get; set; }

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
<<<<<<< HEAD
            //Add(State.Game, Game); - error


            /*Player One = new Player(this[State.Game].As<Game.Game>(), System.Windows.Media.Colors.Red);
            One.Buttons.Add(Key.D1, Action.Left);
            One.Buttons.Add(Key.Q, Action.Right);
            One.Buttons.Add(Key.D2, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(One);

            Player Two = new Player(this[State.Game].As<Game.Game>(), System.Windows.Media.Colors.Green);
            Two.Buttons.Add(Key.M, Action.Left);
            Two.Buttons.Add(Key.OemComma, Action.Right);
            Two.Buttons.Add(Key.K, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(Two);

            Player Three = new Player(this[State.Game].As<Game.Game>(), System.Windows.Media.Colors.Yellow);
            Three.Buttons.Add(Key.Left, Action.Left);
            Three.Buttons.Add(Key.Up, Action.Right);
            Three.Buttons.Add(Key.Down, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(Three);

            Player Four = new Player(this[State.Game].As<Game.Game>(), System.Windows.Media.Colors.Blue);
            Four.Buttons.Add(Key.Y, Action.Left);
            Four.Buttons.Add(Key.X, Action.Right);
            Four.Buttons.Add(Key.C, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(Four);

            Player Five = new Player(this[State.Game].As<Game.Game>(), System.Windows.Media.Colors.Cyan);
            Five.Buttons.Add(Key.D4, Action.Left);
            Five.Buttons.Add(Key.D5, Action.Right);
            Five.Buttons.Add(Key.R, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(Five);

            Player Six = new Player(this[State.Game].As<Game.Game>(), System.Windows.Media.Colors.Pink);
            Six.Buttons.Add(Key.NumPad6, Action.Left);
            Six.Buttons.Add(Key.NumPad9, Action.Right);
            Six.Buttons.Add(Key.Add, Action.Trigger);
            this[State.Game].As<Game.Slayer>().Players.Add(Six);*/
=======

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
>>>>>>> 8010fdced13fb431e16284ac9167a740c6cf1ac0
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
