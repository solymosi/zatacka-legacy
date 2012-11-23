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

            using (DrawingContext DC = this.Canvas.RenderOpen())
            {
                DC.DrawRectangle(Brushes.DarkCyan, null, new Rect(new Point(0, 0), Canvas.Size));
                DC.DrawText(new FormattedText("This is the GAME.\r\nPress ESC to return to MENU.", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial Black"), 40, Brushes.White), new Point(100, 100));
            }
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Escape)
            {
                Dispatcher.Change(Zatacka.State.Dispatcher.State.Menu);
            }
        }

        public override void Input(MouseButton Button)
        {
            
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