using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Canvas
{
    class Canvas : Unit
    {
        public Size Size { get; private set; }

        public Canvas(Size Size)
            : base(null)
        {
            this.Size = Size;
        }

        public T As<T>() where T : Canvas
        {
            return (T)this;
        }

        protected override void Update() { }
    }
}