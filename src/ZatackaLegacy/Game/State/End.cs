using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace Zatacka.Game.State
{
    class End : State
    {
        public Unit.Game.Panel Panel { get; private set; }

        public End(Zatacka.Game.Game Game)
            : base(Game)
        {
            Panel = new Unit.Game.Panel(Game);
            Panel.Add(new Unit.Text(Panel, "GAME OVER", 72, new Point(0,100), new Size(Game.Arena.Size.Width, 0), TextAlignment.Center));
            Panel.Add(new Unit.Text(Panel, "Press END to return to menu.", 24, new Point(50, 200)));
        }

        public override void Enter()
        {
            Game.Arena.Add(Panel);
        }

        public override void Execute() { }

        public override void Input(Key Button)
        {
            if (Button == Key.End)
            {
                Game.Dispatcher.Change(Zatacka.State.Dispatcher.State.Main);
            }
        }
    }
}
