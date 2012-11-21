using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    abstract class Game : StateMachine
    {
        public double GoodieIconRadius { get; protected set; }
        public long Time { get; private set; }
        public double CurveRadius { get; protected set; }
        public double SteeringSensitivity { get; protected set; }
        public double MovementSpeed { get; protected set; }

        public List<Player> Players { get; private set; }

        public Pool Pool { get; protected set; }
        public Log Log { get; private set; }

        public Game(Size Size)
        {
            GoodieIconRadius = 10;
            Time = 0;
            CurveRadius = 3;
            SteeringSensitivity = 5;
            MovementSpeed = 3;

            Pool = new Pool(this, Size);
            Players = new List<Player>();

            Log = new Log(this);
            Pool.AddUnit(Log);
        }

        public override void Execute()
        {
            Time++;
            Pool.CheckCollision();
            Update();
        }

        public abstract void Initialize();
        protected abstract void Update();

        public void Input(Action Action) { Input(null, Action); }
        public abstract void Input(Player Player, Action Action);
    }
}