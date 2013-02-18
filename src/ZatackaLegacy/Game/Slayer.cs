using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Game
{
    class Slayer : Game
    {
        /* BarnaBalu */
        public int ScoreOtherPlayerDied { get; private set; }
        public int ScoreRoundWin { get; private set; }
        /* -- BarnaBalu */
        public Slayer(Zatacka.State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            /* BarnaBalu */
            ScoreOtherPlayerDied = 1;
            ScoreRoundWin = 2;
            /* -- BarnaBalu */
        }

        protected override void Update()
        {
            
        }
    }
}
