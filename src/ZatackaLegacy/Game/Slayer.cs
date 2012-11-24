using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Game
{
    class Slayer : Game
    {
        public Slayer(Zatacka.State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            using (DrawingContext DC = this.Canvas.RenderOpen())
            {
                DC.DrawRectangle(Brushes.DarkCyan, null, new Rect(new Point(0, 0), Canvas.Size));
                DC.DrawText(new FormattedText("This is the GAME.\r\nPress ESC to return to MENU.", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial Black"), 40, Brushes.White), new Point(100, 100));
            }
        }

        protected override void Update()
        {
            Dispatcher.Log.Measure(new System.Action(delegate
            {
                if (Time % 10 == 0)
                {
                    Unit.Game.Goodie.Goodie goodieIcon = new Unit.Game.Goodie.Goodie(Canvas, new Point(Tools.Random(0, Canvas.Size.Width), Tools.Random(0, Canvas.Size.Height)), Goodie.Category.Weapon, Goodie.Type.Bazooka);
                    goodieIcon.Opacity = 0.5;
                    Canvas.Add(goodieIcon);
                }
                foreach (Player P in Players)
                {
                    P.Curve.Advance();
                }
            }));
        }

        public override void Input(Player Player, Action Action)
        {
            switch (Action)
            {
                case Action.Left:
                    Player.Curve.Left();
                    break;
                case Action.Right:
                    Player.Curve.Right();
                    break;
                case Action.Shoot:
                    break;
            }
        }
    }
}
