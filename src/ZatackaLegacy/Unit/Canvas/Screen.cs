using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Unit.Canvas
{
    class Screen : Canvas
    {
        public State.Screen State { get; protected set; }

        public Screen(State.Screen Screen, Size Size) : this(Screen, Size.ToRect()) { }
        public Screen(State.Screen Screen, Rect Bounds)
            : base(Bounds)
        {
            State = Screen;
        }
    }
}