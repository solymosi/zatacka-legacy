using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zatacka.Unit.Canvas
{
    class Game : Screen
    {
        public new Zatacka.Game.Game State
        {
            get { return base.State.As<Zatacka.Game.Game>(); }
        }

        public Game(Zatacka.Game.Game Game, Size Size)
            : base(Game, Size) { }
    }
}