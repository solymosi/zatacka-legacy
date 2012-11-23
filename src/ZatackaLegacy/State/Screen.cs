using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy
{
    abstract class Screen : State.State
    {
        public long Time { get; protected set; }
        public Unit.Pool Pool { get; protected set; }

        public Screen(Size Size)
        {
            Pool = new Unit.Pool(this, Size);
        }

        public override void Execute()
        {
            Time++;
            Update();
        }

        abstract protected void Update();
    }
}