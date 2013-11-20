using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Menu
{
    class TestMenu : Menu
    {
        public TestMenu(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            this.Canvas.Add(new Unit.Text(this.Canvas, "PRESS ENTER TO RETURN", 30, new Point(100, 100)));

            this.Canvas.Add(new Unit.Shape.Rectangle(this.Canvas, new Rect(200, 200, 300, 400), Brushes.LightGreen, new Pen(Brushes.Yellow, 10)));
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Enter)
            {
                Dispatcher.Change(State.Dispatcher.State.Main);
            }
        }

        protected override void Update()
        {
            
        }
    }
}
