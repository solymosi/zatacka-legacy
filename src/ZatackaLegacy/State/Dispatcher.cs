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
        public Size Size { get; private set; }
        public DispatcherTimer Timer { get; private set; }
        public Unit.Canvas.Dispatcher Canvas { get; private set; }
        public Unit.Log Log { get; protected set; }

        public Dispatcher(Size Size)
        {
            this.Size = Size;

            this.Canvas = new Unit.Canvas.Dispatcher(this, Size);

            this.Log = new Unit.Log(Canvas);
            this.Canvas.Add(Log);

            this.Timer = new DispatcherTimer();
            this.Timer.Interval = TimeSpan.FromMilliseconds(20);
            this.Timer.Tick += new EventHandler(Tick);

            Add(State.Menu, new Menu.Menu(Size));
            Add(State.Game, new Game.Slayer(Size));
            this[State.Game].As<Game.Slayer>().Players.Add(new Player(this[State.Game].As<Game.Game>(), System.Windows.Media.Colors.AliceBlue));
        }

        private void Tick(object sender, EventArgs e)
        {
            Execute();
        }

        public override void Enter()
        {
            Change(State.Menu);

            Timer.Start();
        }

        public override void Exit()
        {
            Timer.Stop();
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
