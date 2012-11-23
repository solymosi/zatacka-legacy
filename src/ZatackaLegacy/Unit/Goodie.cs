using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;


namespace Zatacka.Unit
{
    class Goodie : Ellipse
    {
        public Zatacka.Goodie.Category Category { get; private set; }
        public Zatacka.Goodie.Type Type { get; private set; }

        public Goodie(Canvas.Game Canvas, Point Center, Zatacka.Goodie.Category Category, Zatacka.Goodie.Type Ty)
            : base(Canvas, Center, new Size(Canvas.State.GoodieIconRadius * 2, Canvas.State.GoodieIconRadius * 2), Brushes.White, null)
        {
            this.Category = Category;
            this.Type = Ty;
        }
    }
}
