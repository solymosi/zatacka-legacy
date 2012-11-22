using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZatackaLegacy
{
    class Screen : State<Dispatcher>
    {
        public Pool Pool { get; protected set; }

        public Screen(Size Size)
            : base()
        {
            Pool = new Pool(this, Size);
        }

        public override void Execute()
        {
            
        }
    }
}
