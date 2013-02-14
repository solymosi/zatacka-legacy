using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zatacka.State;

namespace Zatacka.Game.State
{
    class Start : State
    {
        public Start(Zatacka.Game.Game Game)
            : base(Game) { }

        public override void Enter()
        {
            Game.Manager.Change(Game.State.RoundStart);
        }

        public override void Execute() { }
    }
}
