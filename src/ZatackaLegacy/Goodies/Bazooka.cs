using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy.Goodie
{
    class Bazooka : Goodie
    {
        public State.State<bool> State { get; set; }

        public Bazooka()
        {
            State = new State.State<bool>();
            State.Change(true);
        }
    }
}