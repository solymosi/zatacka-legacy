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
            Canvas.Background = new SolidColorBrush(Colors.DarkRed);

            Canvas.Add(new Unit.Text(
                Canvas,
                "This is the MENU.\r\nPress ENTER to switch to GAME state.\r\nPress ESC to quit.",
                48,
                FontWeights.Bold,
                FontStyles.Normal,
                Brushes.LightYellow,
                new Point(0, 100),
                new Size(Canvas.Size.Width, 0),
                TextAlignment.Center
                ));
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