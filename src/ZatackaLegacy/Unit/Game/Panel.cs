using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Zatacka.Unit.Game
{
    class Panel : Canvas.Game
    {
        public Panel(Zatacka.Game.Game Game)
            : base(Game, Game.Arena.Size)
        {
            Background = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0));
        }
    }
}
