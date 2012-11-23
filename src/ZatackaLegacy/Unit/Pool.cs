using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy.Unit
{
    class Pool : Unit
    {
        public Size Size { get; private set; }

        public Pool(Screen Screen, Size Size)
            : base(Screen)
        {
            this.Size = Size;
        }
    }
}