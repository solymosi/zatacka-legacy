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

namespace Zatacka.Window
{
    public partial class Window : System.Windows.Window
    {
        State.Dispatcher Game;

        public Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game = new State.Dispatcher(new Size(Width, Height));
            Canvas.SetVisual(Game.Canvas);
            Game.Enter();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }

            if (e.Key == Key.F1)
            {
                Game.Change(State.Dispatcher.State.Menu);
            }

            if (e.Key == Key.F2)
            {
                Game.Change(State.Dispatcher.State.Game);
            }

            Game.Log.Add(e.Key.ToString());
        }
    }
}