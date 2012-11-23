using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;


namespace ZatackaLegacy.Unit
{
    class Goodie : Ellipse
    {
        public ZatackaLegacy.Goodie.Category Category { get; private set; }
        public ZatackaLegacy.Goodie.Type Type { get; private set; }

        public Goodie(Game Game, Point Center, ZatackaLegacy.Goodie.Category Category, ZatackaLegacy.Goodie.Type Ty)
            : base(Game, Center, new Size(Game.GoodieIconRadius * 2, Game.GoodieIconRadius * 2), Brushes.White, null)
        {
            this.Category = Category;
            this.Type = Ty;
        }
    }
}
