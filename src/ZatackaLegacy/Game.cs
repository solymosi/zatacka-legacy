using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ZatackaLegacy
{
    public abstract class Game
    {
        public const int CurveRadius = 10;

        public Pool Pool;
        public List<Player> Players;

        public Game(Pool Pool)
        {
            this.Pool = Pool;
            this.Players = new List<Player>();
        }

        public abstract void Initialize();
        public abstract void Tick();
        public abstract void Input(Keys Button);
    }
}
