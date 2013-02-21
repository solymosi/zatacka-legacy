using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace Zatacka.Game
{
    abstract class Game : Zatacka.State.Screen
    {
        public double GoodieIconRadius { get; protected set; }
        public double CurveRadius { get; protected set; }
        public double SteeringSensitivity { get; protected set; }
        public double MovementSpeed { get; protected set; }
        public List<Player.Player> Players { get; private set; }
        public Zatacka.State.State<State> Manager { get; private set; }
        public Unit.Canvas.Game Arena { get; private set; }        
        public Dictionary<string, Unit.Text> ScoreLabels { get; private set; }

         public IEnumerable<Player.Player> PlayersAlive
        {
            get { return Players.Where((Player.Player P) => { return P.Curve.Alive; }); }
        }

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
            SteeringSensitivity = 4;
            MovementSpeed = 3;

            Players = new List<Player.Player>();
            ScoreLabels = new Dictionary<string, Unit.Text>();
        }

        public override void Enter()
        {
            Canvas = new Unit.Canvas.Game(this, Dispatcher.Size);

            Arena = new Unit.Canvas.Game(this, new Size(Canvas.Size.Width - 250, Canvas.Size.Height));
            Arena.Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            Arena.EnableCollisions = true;
            Arena.Targets.Add(new Unit.Collision.Target(Arena, Arena.Bounds, true));
            Canvas.Add(Arena);

            for (int i = 0; i < Players.Count; i++)
            {
                Player.Player P = Players[i];
                ScoreLabels.Add(P.Name, new Unit.Text(Canvas, P.Name + " : " + P.Score.ToString(), 30, new SolidColorBrush(P.Color), new Point(Canvas.Size.Width - 250, i * 30)));
                Canvas.Add(ScoreLabels[P.Name]);
            }

            Manager = new Zatacka.State.State<State>();

            Manager.Add(State.Playing, new Zatacka.Game.State.Playing(this));
            Manager.Add(State.Paused, new Zatacka.Game.State.Paused(this));
            Manager.Add(State.RoundEnd, new Zatacka.Game.State.RoundEnd(this));
            Manager.Add(State.End, new Zatacka.Game.State.End(this));
            Manager.Add(State.RoundStart, new Zatacka.Game.State.RoundStart(this));
            Manager.Add(State.Start, new Zatacka.Game.State.Start(this));

            Manager.Change(State.Start);
        }

        public override void Execute()
        {
            base.Execute();
            this.Input();
            Manager.Execute();

            foreach (Player.Player P in this.Players)
            {
                ScoreLabels[P.Name].Label = P.Name + " : " + P.Score.ToString();
            }
        }

        public void Input()
        {
            foreach (Player.Player Player in Players)
            {
                Player.Input();
            }
        }

        public override void Input(Key Button)
        {
            Manager.Current.As<Zatacka.Game.State.State>().Input(Button);
        }

        public void Input(Player.Player Player, Player.Action Action)
        {
            Manager.Current.As<Zatacka.Game.State.State>().Input(Player, Action);
        }

        public void NextRound()
        {
            foreach (Player.Player P in Players)
            {
                P.CreateCurve();
                P.Curve.Alive = true;
            }
        }

        public enum State
        {
            Start = 1,
            RoundStart,
            Playing,
            Paused,
            RoundEnd,
            End
        }
    }
}