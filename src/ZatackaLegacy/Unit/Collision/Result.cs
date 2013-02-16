using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zatacka.Unit.Collision
{
    class Result
    {
        public Unit From { get; private set; }
        public Unit To { get; private set; }
        public List<Target> Colliders { get; private set; }
        public List<Target> Targets { get; private set; }

        public bool Any
        {
            get { return Colliders.Any(); }
        }

        public Result(Unit From, Unit To)
        {
            this.From = From;
            this.To = To;

            this.Colliders = new List<Target>();
            this.Targets = new List<Target>();
        }
    }
}