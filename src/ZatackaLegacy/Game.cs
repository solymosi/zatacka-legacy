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
        public double CurveRadius { get { return 3; } }
        public double SteeringSensitivity { get { return 5; } }
        public double MovementSpeed { get { return 3; } }

        public Pool Pool;
        public List<Player> Players = new List<Player>();
        public List<string> Log = new List<string>();

        public Game(Pool Pool)
        {
            this.Pool = Pool;
            Pool.Game = this;
        }

        public void Tick()
        {
            Update();
        }

        public void Render(DrawingContext Context)
        {
            Pool.Render(Context);
            Log.Add("Testing..." + Tools.Random(0, 1000).ToString());
            Context.DrawText(new FormattedText(string.Join("\r\n", Log.GetRange(Math.Max(Log.Count - 20, 0), Math.Min(Log.Count, 20))), System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Consolas"), 10, Brushes.White), new Point(10, 10));
        }

        public abstract void Initialize();
        public abstract void Update();

        public void Input(Action Action) { Input(null, Action); }
        public abstract void Input(Player Player, Action Action);
    }
}
