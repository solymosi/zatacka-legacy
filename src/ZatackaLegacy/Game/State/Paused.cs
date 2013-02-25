using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace Zatacka.Game.State
{
    class Paused : State
    {
        public Unit.Game.Panel Panel { get; private set; }

        public Paused(Zatacka.Game.Game Game)
            : base(Game)
        {
            Panel = new Unit.Game.Panel(Game);
            Panel.Add(new Unit.Text(Panel, "PAUSED", 72, new Point(50, 100)));
            Panel.Add(new Unit.Text(Panel, "Press ESC to continue or END to end this game.", 24, new Point(50, 200)));
        }

        public override void Enter()
        {
            Game.Arena.Add(Panel);
        }

        public override void Exit()
        {
            Game.Arena.Remove(Panel);
        }

        public override void Execute() { }

        public override void Input(Key Button)
        {
            if (Button == Key.Escape)
            {
                Game.Manager.Change(Game.State.Playing);
            }

            if (Button == Key.End)
            {
                Game.Dispatcher.Change(Zatacka.State.Dispatcher.State.Main);
            }
        }
    }
}
