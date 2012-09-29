using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    public abstract class Game
    {
        public double CurveRadius = 3;
        public double SteeringSensitivity = 5;
        public double MovementSpeed = 3;

        public Pool Pool;
        public Log Log;
        public List<Player> Players = new List<Player>();
        public bool Running = false;

        public Game(Size Size)
        {
            Pool = new Pool(this, Size);
            Log = new Log();
            Pool.AddUnit(Log);
        }

        public void Tick()
        {
            if (!Running) { return; }
            Pool.CheckCollision();
            Update();
        }

        public abstract void Initialize();
        public abstract void Update();

        public void Input(Action Action) { Input(null, Action); }
        public abstract void Input(Player Player, Action Action);
    }
}