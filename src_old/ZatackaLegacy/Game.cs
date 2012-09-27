using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ZatackaLegacy
{
    public abstract class Game
    {
        public float CurveRadius { get { return 3; } }
        public float SteeringSensitivity { get { return 5; } }
        public float MovementSpeed { get { return 3; } }

        public Pool Pool;
        public List<Player> Players;

        public Game(Pool Pool)
        {
            this.Pool = Pool;
            this.Players = new List<Player>();
            Pool.Game = this;
        }

        public void Tick()
        {
            Update();
        }

        public abstract void Initialize();
        public abstract void Update();

        public void Input(Action Action) { Input(null, Action); }
        public abstract void Input(Player Player, Action Action);
    }
}
