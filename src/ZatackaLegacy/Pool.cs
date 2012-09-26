using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZatackaLegacy
{
    public class Pool
    {
        public Size Dimensions;
        public List<Unit> Units;

        public Pool(Size Dimensions)
        {
            this.Dimensions = Dimensions;
            this.Units = new List<Unit>();
        }

        public Point RandomLocation()
        {
            return new Point(Tools.Random(0, Dimensions.Width), Tools.Random(0, Dimensions.Height));
        }

        public Unit RegisterUnit(Unit Unit)
        {
            if (!Units.Contains(Unit))
            {
                Units.Add(Unit);
            }
            return Unit;
        }

        public void Draw(Graphics GFX)
        {
            foreach (Unit U in Units)
            {
                U.Draw(GFX);
            }
        }
    }
}