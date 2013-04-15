﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zatacka.Goodie.Evil
{
    class Evil : Goodie
    {
        public Evil()
        {
            Category = Category.Evil;
        }
    }

    public enum Type
    {
        None,
        Madness,
        RussianRoulette,
        BlackHole,
        BodySwitch,
        Drunken,
        Ninja,
        FortuneWheel,
        SnowWhite,
        FinalDestination,
        Mist,
        Purgation,
        Magneto,
        Understocked
    }
}
