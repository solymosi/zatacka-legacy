using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Zatacka.State
{
    abstract class Screen : State
    {
        public long Time { get; protected set; }
        public Unit.Canvas.Screen Canvas { get; protected set; }

        public Dispatcher Dispatcher
        {
            get { return Parent.As<Dispatcher>(); }
        }

        public Screen(Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Canvas = new Unit.Canvas.Screen(this, Dispatcher.Size);
        }

        public override void Execute()
        {
            Time++;
            Update();
        }

        abstract protected void Update();

        public virtual void Input(Key Button) { }
        public virtual void Input(MouseButton Button) { }
    }
}