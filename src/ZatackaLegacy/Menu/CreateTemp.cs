using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Zatacka.Menu
{
    class CreateTemp : Menu
    {
        public Unit.Text Title { get; private set; }
        public Unit.Text Statusbar { get; private set; }
        public int NumberOfPlayers { get; private set; }

        public CreateTemp(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Title = new Unit.Text(Canvas, "CHOOSE PLAYERS", 72, FontWeights.Bold, FontStyles.Normal, Brushes.White, null, new Point(0, Canvas.Size.Height * 0.05), new Size(Canvas.Size.Width, 0), TextAlignment.Left);
            Canvas.Add(Title);

            StatusBarUpdate("Press F13 to restart your life");
            Canvas.Add(Statusbar);

            NumberOfPlayers = Player.Template.Templates.Count;

            for (int i = 1; i <= NumberOfPlayers; i++)
            {
                Player.Template T = Player.Template.Templates[i];
            }
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Enter /*&& Start_button_active*/)
            {
                Dispatcher.Game = new Game.Slayer(Dispatcher);
                /*foreach (Player.Template T in /* activated_players --- temp:*//*)
                {
                    Dispatcher.Game.Players.Add(new Player.Player(Dispatcher.Game, T));
                }*/
                Dispatcher.Remove(State.Dispatcher.State.Game);
                Dispatcher.Add(State.Dispatcher.State.Game, Dispatcher.Game);
                Dispatcher.Change(State.Dispatcher.State.Game);
                return;
            }

            if (Button == Key.Enter /*&& AddPlayer_button_active*/)
            {
                return;
            }

            if (Button == Key.Enter /*&& One_of_PlayerRows_is_active*/)
            {
                return;
            }

            if (Button == Key.Escape)
            {
                Dispatcher.Change(State.Dispatcher.State.Main);
                return;
            }

            if (Button == Key.Up)
            {
                return;
            }

            if (Button == Key.Down)
            {
                return;
            }
        }

        public void StatusBarUpdate(String DescriptionOfTheStatus)
        {
            Statusbar = new Unit.Text(Canvas, DescriptionOfTheStatus, 15, FontWeights.Normal, FontStyles.Normal, Brushes.White, null, new Point(0, Canvas.Size.Height * 0.9), new Size(Canvas.Size.Width, 0), TextAlignment.Left);
            
        }

        protected override void Update() { }
    }
}