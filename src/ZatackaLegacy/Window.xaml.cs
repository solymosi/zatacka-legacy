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
        new State.Dispatcher Dispatcher;

        public Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher = new State.Dispatcher(new Size(Width, Height));
            Dispatcher.Ended += new EventHandler(Game_Ended);
            Canvas.SetVisual(Dispatcher.Canvas);
            Dispatcher.Enter();
        }

        private void Game_Ended(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Dispatcher.Input(e.Key);
            Dispatcher.Log.Add(e.Key.ToString());
        }
    }
}