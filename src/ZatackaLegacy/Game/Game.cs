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

        public Game(Size Size)
        {
            Pool = new Pool(this, Size);
            Log = new Log();
            Pool.AddUnit(Log);
        }

        public void Tick()
        {
            Log.Messages.Add(((((Players[0].Curve.Segments.Count - 1) * Players[0].Curve.SegmentCapacity) + Players[0].Curve.Head.Points.Count) * Players.Count).ToString());
            Update();
        }

        public abstract void Initialize();
        public abstract void Update();

        public void Input(Action Action) { Input(null, Action); }
        public abstract void Input(Player Player, Action Action);
    }
}
