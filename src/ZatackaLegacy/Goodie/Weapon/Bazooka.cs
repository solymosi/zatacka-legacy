using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zatacka.Goodie.Weapon
{
    class Bazooka : Weapon
    {
       

        public Bazooka()
        {
            Type = Type.Bazooka;
        }
        public override void Enter()
        {
            Unit.Game.Goodie.Bullet BazookaBullet = new Unit.Game.Goodie.Bullet(Game.Arena, new Point(Tools.Random(0, Game.Arena.Size.Width), Tools.Random(0, Game.Arena.Size.Height)), Goodie.Category.Weapon, RandomType<Goodie.Type>());
            //Game.Arena.Add(BazookaBullet);
        }
        public override void Execute()
        {
            
            //Game.Dispatcher.Log.Add("Bazooka-Execute");
        }
        
    }
}