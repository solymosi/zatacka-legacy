using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace ZatackaLegacy.State
{
    class Dispatcher : State<Dispatcher.State>
    {
        public Size Size { get; protected set; }
        public DispatcherTimer Timer { get; private set; }

        public Dispatcher(Size Size)
        {
            this.Size = Size;

            this.Timer = new DispatcherTimer();
            this.Timer.Interval = TimeSpan.FromMilliseconds(20);
            this.Timer.Tick += new EventHandler(Tick);
        }

        private void Tick(object sender, EventArgs e)
        {
            Execute();
        }

        public override void Enter()
        {
            Slayer Game = new Slayer(Size);
            /*Player First = new Player(Game, System.Windows.Media.Colors.Red);
            First.Bind(System.Windows.Input.Key.D1, Action.Left);
            First.Bind(System.Windows.Input.Key.Q, Action.Right);
            First.Bind(System.Windows.Input.Key.D2, Action.Shoot);
            Game.Players.Add(First);

            Player Second = new Player(Game, System.Windows.Media.Colors.Green);
            Second.Bind(System.Windows.Input.Key.M, Action.Left);
            Second.Bind(System.Windows.Input.Key.OemComma, Action.Right);
            Second.Bind(System.Windows.Input.Key.K, Action.Shoot);
            Game.Players.Add(Second);*/

            Add(State.Game, Game);
            Change(State.Game);

            Timer.Start();
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
}
