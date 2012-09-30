using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ZatackaLegacy
{
    public partial class GameWindow : Window
    {
        StandardGame Game;
        public DispatcherTimer Timer;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game = new StandardGame(new Size(Width, Height));

            Player First = new Player(Game, new SolidColorBrush(Colors.Red));
            First.Bind(Key.D1, Action.Left);
            First.Bind(Key.Q, Action.Right);
            First.Bind(Key.D2,Action.Shoot);
            Game.Players.Add(First);

            Player Second = new Player(Game, new SolidColorBrush(Colors.Green));
            Second.Bind(Key.M, Action.Left);
            Second.Bind(Key.OemComma, Action.Right);
            Second.Bind(Key.K, Action.Shoot);
            Game.Players.Add(Second);

            Game.Initialize();
            Canvas.SetVisual(Game.Pool.Visual);

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(20);
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Player P in Game.Players)
            {
                foreach (KeyValuePair<Key, Action> Item in P.Buttons)
                {
                    if (Keyboard.IsKeyDown(Item.Key))
                    {
                        Game.Input(P, Item.Value);
                    }
                }
            }

            Game.Tick();
            Game.Pool.Draw();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}