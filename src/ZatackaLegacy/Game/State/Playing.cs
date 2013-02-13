using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Zatacka.Game.State
{
    class Playing : State
    {
        public Playing(Zatacka.Game.Game Game)
            : base(Game)
        {

        }

        public override void Execute()
        {
            foreach (Player P in Game.Players)
            {
                P.Curve.Advance();
            }
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Escape)
            {
                Game.Manager.Change(Zatacka.Game.Game.State.Paused);
            }

            // LOG DEMO
            //Game.Dispatcher.Log.Add(Button.ToString());

            /* TEMP FOR TESTING */
            if (Button == Key.Insert)
            {
                Game.Manager.Change(Zatacka.Game.Game.State.RoundEnd);
            }
            if (Button == Key.PageUp)
            {
                Game.Manager.Change(Zatacka.Game.Game.State.End);
            }
        }

        public override void Input(Player Player, Action Action)
        {
            switch (Action)
            {
                case Action.Left:
                    Player.Curve.Left();
                    break;
                case Action.Right:
                    Player.Curve.Right();
                    break;
                case Action.Trigger:
                    break;
            }
        }
    }
}
