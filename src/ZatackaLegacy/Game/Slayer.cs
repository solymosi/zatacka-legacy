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
        public int ScoreWhenOtherPlayerDie { get; private set; }
        public int ScoreWhenWinTheRound { get; private set; }
        /* -- BarnaBalu */
        public Slayer(Zatacka.State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            /* BarnaBalu */
            ScoreWhenOtherPlayerDie = 1;
            ScoreWhenWinTheRound = 2;
            /* -- BarnaBalu */
        }

        protected override void Update()
        {
            
        }
        /* BarnaBalu
        protected override void Score(Player P)
        {

        }
         * */
        public void GetScoreWhenOtherPlayerDie(Player P)
        {
            P.Score += ScoreWhenOtherPlayerDie;
        }
        public void GetScoreWhenWinTheRound(Player P)
        {
            P.Score += ScoreWhenWinTheRound;
        }

        public bool IsOneOfThePlayerWonTheMatch(List<Player> Players, Player Player)
        {
            foreach (Player P in Players)
            {
            }
            return false;
        }
    }
}
