using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace ZatackaLegacy
{
    class Dispatcher : StateMachine<Dispatcher.State, State<Dispatcher.State>>
    {
        public Size Size { get; protected set; }
        public DispatcherTimer Timer { get; private set; }
        public event EventHandler<ScreenEventArgs> ScreenChanged = delegate { };

        public Dispatcher(Size Size)
            : base(State.Menu)
        {
            this.Size = Size;
            this.Timer = new DispatcherTimer();

            InitializeTimer();
            Add(State.Game, new Menu());
        }

        private void InitializeTimer()
        {
            Timer.Interval = TimeSpan.FromMilliseconds(20);
            Timer.Tick += new EventHandler(Tick);
            Timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            Execute();
        }

        public override void Exit()
        {
            Timer.Stop();
        }

        public enum State
        {
            Game = 1,
            Menu = 2
        }
    }

    class ScreenEventArgs : EventArgs
    {
        public Area Screen { get; private set; }
        public ScreenEventArgs(Area Screen) { this.Screen = Screen; }
    }
}
