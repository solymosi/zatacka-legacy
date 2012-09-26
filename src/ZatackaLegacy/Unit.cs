using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ZatackaLegacy
{
    public class Unit
    {
        public int Size;
        public Point Location;
        public Pool Pool;

        public Unit(Pool Pool, Point Location, int Size)
        {
            this.Pool = Pool;
            this.Location = Location;
            this.Size = Size;

            Pool.RegisterUnit(this);
        }

        public virtual void Draw(Graphics GFX)
        {
            GFX.FillEllipse(Brushes.White, Location.X - Size / 2, Location.Y - Size / 2, Size, Size);
        }
    }
}
