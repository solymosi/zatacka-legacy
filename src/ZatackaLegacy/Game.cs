using System;
using System.Collections.Generic;
using System.Text;

namespace ZatackaLegacy
{
    public abstract class Game
    {
        public Options Options;
        public Pool Pool;

        public Game(Options Options, Pool Pool)
        {
            this.Options = Options;
            this.Pool = Pool;
        }

        public abstract void Initialize();
    }
}
