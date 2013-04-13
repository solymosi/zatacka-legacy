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

        private IrrKlang.ISoundEngine Player { get; set; }
        private IrrKlang.ISound Music { get; set; }

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
            Add(State.Main, new Menu.Main(this));
        }

        private void Tick(object sender, EventArgs e)
        {
            Execute();
            Canvas.Execute();
            Time++;
        }

        public override void Enter()
        {
            Change(State.Main);
            Timer.Start();
            StartMusic();
        }

        public override void Exit()
        {
            Timer.Stop();
            StopMusic();
            Reset();
            Ended(this, new EventArgs());
        }

        public void Input(Key Button)
        {
            if (Button == Key.F11)
            {
                Music.Volume = Math.Max(0.0F, Music.Volume - 0.01F);
            }

            if (Button == Key.F12)
            {
                Music.Volume = Math.Min(1.0F, Music.Volume + 0.01F);
            }

            if (Active) { Current.As<Screen>().Input(Button); }
        }

        public void Input(MouseButton Button)
        {
            if (Active) { Current.As<Screen>().Input(Button); }
        }

        private void StartMusic()
        {
            Player = new IrrKlang.ISoundEngine();
            Music = Player.Play2D(Player.AddSoundSourceFromMemory(Zatacka.Properties.Resources.Music, "Music"), true, true, false);
            Music.Volume = 0.5f;
            Music.Paused = false;
        }

        private void StopMusic()
        {
            Music.Stop();
            Music.Dispose();
        }

        public enum State
        {
            Game = 1,
            Main,
            Create
        }
    }
}
