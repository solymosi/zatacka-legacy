using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Unit.Shape
{
    class Button : Rectangle
    {
        public Zatacka.Unit.Text Text { get; set; }

        public Button(Canvas.Canvas Canvas, Rect Bounds, Brush Fill, Pen Border)
            : base(Canvas, Bounds, Fill, Border)
        {

        }

        public void CreateButton()
        {

        }
    }
}
