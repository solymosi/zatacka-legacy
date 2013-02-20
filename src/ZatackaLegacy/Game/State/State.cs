using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Zatacka.Game.State
{
    abstract class State : Zatacka.State.State
    {
        public Zatacka.Game.Game Game { get; private set; }

        public State(Zatacka.Game.Game Game)
            : base(Game.Manager)
        {
            this.Game = Game;
        }

        public virtual void Input(Key Button) { }
        public virtual void Input(MouseButton Button) { }
        public virtual void Input(Player.Player Player, Player.Action Action) { }
    }
}
