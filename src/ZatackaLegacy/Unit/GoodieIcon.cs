using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;


namespace ZatackaLegacy
{
   
   class GoodieIcon:Ellipse
    {
        public GoodieCategory category { get; private set; }
        public GoodieType type { get; private set; }
        public GoodieIcon(Game Game,Point Center,GoodieCategory category,GoodieType type):base(Game,Center,new Size(Game.GoodieIconRadius*2,Game.GoodieIconRadius*2),Brushes.White,null)
        {
            this.category = category;
            this.type = type;
        }       

    }
}
