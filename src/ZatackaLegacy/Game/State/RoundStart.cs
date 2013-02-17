using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Game.State
{
    class RoundStart : State
    {
        public Unit.Game.Panel Panel { get; private set; }
        public Unit.Text Countdown { get; private set; }
        public long Time { get; private set; }
        public int CountdownFrequency { get; private set; }

        public RoundStart(Zatacka.Game.Game Game)
            : base(Game)
        {
            Panel = new Unit.Game.Panel(Game);
            Countdown = new Unit.Text(Panel, "", 72, new Point(200, 200));
            Panel.Add(Countdown);
            CountdownFrequency = 25;
        }

        public override void Enter()
        {
            Game.NextRound();
            Game.Arena.Add(Panel);
            Time = 0;
        }

        public override void Exit()
        {
            Game.Arena.Remove(Panel);
        }

        public override void Execute()
        {
            if (Time >= CountdownFrequency * 3)
            {
                Game.Manager.Change(Zatacka.Game.Game.State.Playing);
                return;
            }

            if (Time % CountdownFrequency == 0)
            {
                Countdown.Label = "GET READY... " + (3 - (Time / CountdownFrequency)).ToString();
            }
            Time++;
        }
    }
}
