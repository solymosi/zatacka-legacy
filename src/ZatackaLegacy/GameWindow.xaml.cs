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
        DispatcherTimer Timer;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game = new StandardGame(new Size(Width, Height));

            new Player(Game, new Key[] { Key.D1, Key.Q, Key.D2 }, Colors.Red);
            new Player(Game, new Key[] { Key.M, Key.OemComma, Key.K }, Colors.Green);

            Game.Initialize();

            Canvas.SetVisual(Game.Pool.Visual);
            Game.Pool.Draw(true);

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(20);
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Player P in Game.Players)
            {
                foreach (KeyValuePair<Action, Key> Item in P.Buttons)
                {
                    if (Keyboard.IsKeyDown(Item.Value))
                    {
                        Game.Input(P, Item.Key);
                    }
                }
            }

            Game.Tick();
            Game.Pool.Draw(false);
            Canvas.InvalidateVisual();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }

            if (e.Key == Key.F1) { Game.Acc = 1; }
            if (e.Key == Key.F2) { Game.Acc = 1000; }
        }
    }
}