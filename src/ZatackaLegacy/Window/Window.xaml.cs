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
    /// <summary>
    /// The main Window of the application.
    /// </summary>
    public partial class Window : System.Windows.Window
    {
        /// <summary>
        /// The Dispatcher instance that manages the internals of the application.
        /// </summary>
        private new State.Dispatcher Dispatcher;

        /// <summary>
        /// Default constructor that initializes the window and its contents.
        /// </summary>
        public Window()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executed when this Window has successfully been initialized. Creates and initializes the Dispatcher, assigns event handlers and sets the Visual hosted by the Canvas on the window.
        /// </summary>
        private void Load(object sender, RoutedEventArgs e)
        {
            Dispatcher = new State.Dispatcher(new Size(Width, Height));
            Dispatcher.Ended += new EventHandler(Ended);
            Canvas.SetVisual(Dispatcher.Canvas);
            Dispatcher.Enter();
        }

        /// <summary>
        /// Executed when the application should quit. Closes this Window.
        /// </summary>
        private void Ended(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Executed when a button is pressed on the keyboard. Forwards the input to the Dispatcher.
        /// </summary>
        private void Input(object sender, KeyEventArgs e)
        {
            Dispatcher.Input(e.Key);
        }

        /// <summary>
        /// Executed when a mouse button is pressed. Forwards the input to the Dispatcher.
        /// </summary>
        private void Input(object sender, MouseButtonEventArgs e)
        {
            Dispatcher.Input(e.ChangedButton);
        }
    }
}