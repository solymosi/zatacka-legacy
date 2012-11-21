using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    class Area : Unit
    {
        public Size Size { get; private set; }

        public Area(Game Game, Size Size)
            : base(Game)
        {
            this.Size = Size;
        }
    }
}