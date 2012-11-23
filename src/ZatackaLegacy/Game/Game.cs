using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace ZatackaLegacy
{
    abstract class Game : Screen
    {
        public double GoodieIconRadius { get; protected set; }
        public double CurveRadius { get; protected set; }
        public double SteeringSensitivity { get; protected set; }
        public double MovementSpeed { get; protected set; }
        public List<Player> Players { get; private set; }
        public Unit.Log Log { get; private set; }

        public Game(Size Size)
            : base(Size)
        {
            GoodieIconRadius = 10;
            Time = 0;
            CurveRadius = 3;
            SteeringSensitivity = 5;
            MovementSpeed = 3;

            Players = new List<Player>();

            Log = new Unit.Log(this);
            Pool.Add(Log);
        }

        public void Input(Action Action)
        {
            Input(null, Action);
        }

        abstract public void Input(Player Player, Action Action);

        public enum State
        {
            Start = 1,
            RoundStart,
            Playing,
            RoundEnd,
            End
        }
    }
}