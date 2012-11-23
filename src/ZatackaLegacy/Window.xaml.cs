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
            Game.StateChanged += new State.State<State.Dispatcher.State>.StateChangeDelegate(ScreenChanged);
            Game.Enter();
        }

        private void ScreenChanged(object sender, State.StateChangeEventArgs<State.Dispatcher.State> e)
        {
            Canvas.SetVisual(e.State.As<Screen>().Pool);
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