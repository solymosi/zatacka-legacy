using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Zatacka.Menu
{
    class Menu : State.Screen
    {
        public Menu(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            using (DrawingContext DC = Canvas.RenderOpen())
            {
                DC.DrawRectangle(Brushes.DarkRed, null, new Rect(new Point(0, 0), Canvas.Size));
                DC.DrawText(new FormattedText("This is the MENU.\r\nPress ENTER to switch to GAME state.\r\nPress ESC to quit.", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial Black"), 40, Brushes.White), new Point(100, 100));
            }
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Enter)
            {
                Dispatcher.Change(State.Dispatcher.State.Game);
            }

            if (Button == Key.Escape)
            {
                Dispatcher.Exit();
            }
        }

        protected override void Update()
        {
            
        }
    }
}