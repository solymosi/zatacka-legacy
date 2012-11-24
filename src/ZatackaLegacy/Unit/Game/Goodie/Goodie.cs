using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Game.Goodie
{
    /// <summary>
    /// Represents a power-up icon on the screen that can be picked up by the players.
    /// </summary>
    class Goodie : Shape.Ellipse
    {
        /// <summary>
        /// The category of the power-up this icon represents.
        /// </summary>
        public Zatacka.Goodie.Category Category { get; private set; }

        /// <summary>
        /// The type of the power-up the player receives by touching this icon.
        /// </summary>
        public Zatacka.Goodie.Type Type { get; private set; }

        // TODO: Implement and finish commenting goodie icon class.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Canvas"></param>
        /// <param name="Center"></param>
        /// <param name="Category"></param>
        /// <param name="Type"></param>
        public Goodie(Canvas.Game Canvas, Point Center, Zatacka.Goodie.Category Category, Zatacka.Goodie.Type Type)
            : base(Canvas, Center, new Size(Canvas.State.GoodieIconRadius * 2, Canvas.State.GoodieIconRadius * 2), Brushes.White, null)
        {
            this.Category = Category;
            this.Type = Type;
        }
    }
}
