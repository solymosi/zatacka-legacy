using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZatackaLegacy.Goodie
{
    abstract class Goodie
    {
        public Goodie()
        {
            
        }
    }

    public enum Category
    {
        Weapon,
        Modifier,
        Defense,
        Evil
    }

    public enum Type
    {
        Bazooka,
        Shotgun,
        Juggernaut,
        Gravity
    }
}