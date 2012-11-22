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
        Dispatcher Game;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game = new Dispatcher(new Size(Width, Height));
            Game.StateChanged += new EventHandler<StateChangedEventArgs<Dispatcher.State, Screen>>(ScreenChanged);

            /*Player First = new Player(Game, Colors.Red);
            First.Bind(Key.D1, Action.Left);
            First.Bind(Key.Q, Action.Right);
            First.Bind(Key.D2,Action.Shoot);
            Game.Players.Add(First);

            Player Second = new Player(Game, Colors.Green);
            Second.Bind(Key.M, Action.Left);
            Second.Bind(Key.OemComma, Action.Right);
            Second.Bind(Key.K, Action.Shoot);
            Game.Players.Add(Second);

            Canvas.SetVisual(Game.Pool);*/

            
        }

        private void ScreenChanged(object Dispatcher, StateChangedEventArgs<Dispatcher.State, Screen> EventArgs)
        {
            Canvas.SetVisual(EventArgs.State);
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