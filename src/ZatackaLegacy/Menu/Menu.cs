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

        List<string> Actions = new List<string>();
        List<Unit.Text> Textes = new List<Unit.Text>();
        List<Player.Player> SelectedPlayers = new List<Player.Player>();

        Player.Player P, Q, R, S, T, Z;

        public Menu(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Canvas.Background = new SolidColorBrush(Colors.DarkRed);

            Actions.Add("2 1 Q");
            Actions.Add("K M ,");
            Actions.Add("Down Left Up");
            Actions.Add("C Y X");
            Actions.Add("R 4 5");
            Actions.Add("+ 6 9");

            /*Canvas.Add(new Unit.Text(
                Canvas,
                "This is the MENU.\r\nPress ENTER to switch to GAME state.\r\nPress ESC to quit.",
                48,
                FontWeights.Bold,
                FontStyles.Normal,
                Brushes.LightYellow,
                new Point(0, 100),
                new Size(Canvas.Size.Width, 0),
                TextAlignment.Center
                ));*/

            int startPos = 200;
            int fontSize = 48;

            for (int i = 1; i <7 ; i++) 
            {
                Unit.Text TextTmp = new Unit.Text(Canvas, "Player" + i + "  " + Actions[i-1], fontSize, FontWeights.Normal, FontStyles.Normal, Brushes.Gray, new Point(startPos, startPos / 2 + i * fontSize), new Size(0, 0));
                Textes.Add(TextTmp);
                Canvas.Add(TextTmp);
            }

            Dispatcher.Game = new Game.Slayer(Dispatcher);

            P = new Player.Player(Dispatcher.Game, Player.Player.Templates[1]);
            Q = new Player.Player(Dispatcher.Game, Player.Player.Templates[4]);
            R = new Player.Player(Dispatcher.Game, Player.Player.Templates[7]);
            S = new Player.Player(Dispatcher.Game, Player.Player.Templates[4]);
            T = new Player.Player(Dispatcher.Game, Player.Player.Templates[5]);
            Z = new Player.Player(Dispatcher.Game, Player.Player.Templates[6]);

        }

        public override void Input(Key Button)
        {
            if (Button == Key.Enter)
            {
                if (SelectedPlayers.Count >= 2)
                {
                    foreach (Player.Player selected in SelectedPlayers)
                    {
                        Dispatcher.Game.Players.Add(selected);
                    }
                    Dispatcher.Change(State.Dispatcher.State.Game);
                }
            }

            if (Button == Key.Escape)
            {
                Dispatcher.Exit();
            }

            SolidColorBrush tmp;
            switch (Button) 
            {
                case Key.D2:
                    tmp = new SolidColorBrush(P.Color);
                    Textes[0].Fill = Textes[0].Fill == Brushes.Gray ? tmp : Brushes.Gray;
                    if (Textes[0].Fill == tmp)
                    {
                        SelectedPlayers.Add(P);
                    }
                    else
                    {
                        SelectedPlayers.Remove(P);
                    }
                    break;
                case Key.K:
                    tmp = new SolidColorBrush(Q.Color);
                    Textes[1].Fill = Textes[1].Fill == Brushes.Gray ? tmp : Brushes.Gray;
                    if (Textes[1].Fill == tmp)
                    {
                        SelectedPlayers.Add(Q);
                    }
                    else
                    {
                        SelectedPlayers.Remove(Q);
                    }
                    break;
                case Key.Down:
                    tmp = new SolidColorBrush(R.Color);
                    Textes[2].Fill = Textes[2].Fill == Brushes.Gray ? tmp : Brushes.Gray;
                    if (Textes[2].Fill == tmp)
                    {
                        SelectedPlayers.Add(R);
                    }
                    else
                    {
                        SelectedPlayers.Remove(R);
                    }
                    break;
                case Key.C:
                    tmp = new SolidColorBrush(S.Color);
                    Textes[3].Fill = Textes[3].Fill == Brushes.Gray ? tmp : Brushes.Gray;
                    if (Textes[3].Fill == tmp)
                    {
                        SelectedPlayers.Add(S);
                    }
                    else
                    {
                        SelectedPlayers.Remove(S);
                    }
                    break;
                case Key.R:
                    tmp = new SolidColorBrush(T.Color);
                    Textes[4].Fill = Textes[4].Fill == Brushes.Gray ? tmp : Brushes.Gray;
                    if (Textes[4].Fill == tmp)
                    {
                        SelectedPlayers.Add(T);
                    }
                    else
                    {
                        SelectedPlayers.Remove(T);
                    }
                    break;
                case Key.Add:
                    tmp = new SolidColorBrush(Z.Color);
                    Textes[5].Fill = Textes[5].Fill == Brushes.Gray ? tmp : Brushes.Gray;
                    if (Textes[5].Fill == tmp)
                    {
                        SelectedPlayers.Add(Z);
                    }
                    else
                    {
                        SelectedPlayers.Remove(Z);
                    }
                    break;
            }

            Unit.Text TextTmp = new Unit.Text(Canvas, "Press Enter to start", 48, FontWeights.Normal, FontStyles.Normal, Brushes.White, new Point(600, 200), new Size(0, 0));
            Textes.Add(TextTmp);
            if (SelectedPlayers.Count >= 2)
            {
                Canvas.Add(TextTmp);
            }
            else
            {
                Canvas.Remove(TextTmp);
            }
        }

        protected override void Update()
        {

        }
    }
}