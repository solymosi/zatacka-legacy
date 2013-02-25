using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Zatacka.Menu
{
    abstract class Menu : State.Screen
    {
        public Menu(State.Dispatcher Dispatcher)
            : base(Dispatcher) { }
    }
}