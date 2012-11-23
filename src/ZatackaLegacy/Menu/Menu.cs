using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Zatacka.Menu
{
    class Menu : State.Screen
    {
        public Menu(Size Size)
            : base(Size)
        {
            using (DrawingContext DC = Canvas.RenderOpen())
            {
                DC.DrawRectangle(Brushes.DarkRed, null, new Rect(new Point(0, 0), Canvas.Size));
            }
        }

        protected override void Update()
        {
            
        }
    }
}