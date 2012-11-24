using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Canvas
{
    class Dispatcher : Canvas
    {
        public State.Dispatcher State { get; protected set; }
        public Screen Current { get; protected set; }

        public Dispatcher(State.Dispatcher Dispatcher, Size Size) : this(Dispatcher, Size.ToRect()) { }
        public Dispatcher(State.Dispatcher Dispatcher, Rect Bounds)
            : base(Bounds)
        {
            this.State = Dispatcher;
            this.State.Changed += new EventHandler(Changed);
            this.State.Deactivated += new EventHandler(Deactivated);
        }

        private void Changed(object sender, EventArgs e)
        {
            if (Current != null)
            {
                Remove(Current);
            }

            Current = State.Current.As<State.Screen>().Canvas;

            Add(Current, RelativePosition.Below, State.Log);
        }

        private void Deactivated(object sender, EventArgs e)
        {
            if (Current != null)
            {
                Remove(Current);
            }
        }
    }
}