using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ZatackaLegacy
{
    class UnitVisual : DrawingVisual
    {
        public Unit Unit { get; private set; }

        public UnitVisual(Unit Unit)
            : base()
        {
            this.Unit = Unit;
        }
    }
}
