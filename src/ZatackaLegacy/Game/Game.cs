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
        public new Unit.Canvas.Game Canvas { get; protected set; }
        public List<Player> Players { get; private set; }

        public Game(Size Size)
            : base(Size)
        {
            GoodieIconRadius = 10;
            Time = 0;
            CurveRadius = 3;
            SteeringSensitivity = 5;
            MovementSpeed = 3;

            Canvas = new Unit.Canvas.Game(this, Size);
            Players = new List<Player>();

            using (DrawingContext DC = this.Canvas.RenderOpen())
            {
                DC.DrawRectangle(Brushes.Blue, null, new Rect(new Point(0, 0), Canvas.Size));
            }
        }

        public override void Input(Key Key)
        {
            
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