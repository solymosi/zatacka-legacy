using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zatacka.Goodie
{
    abstract class Goodie
    {
        public Category Category { get; protected set; }
        public Type Type { get; protected set; }

        public Goodie()
        {
            
        }
    }

    public enum Category
    {
        None,
        Weapon,
        Modifier,
        Defense,
        Evil
    }

    public enum Type
    {
        None,

        Bazooka,
        Shotgun,
        GuidedMissile,

        Juggernaut,
        Skinny,
        Tron,
        Turbo,
        SlooMoo,

        Ghost,
        InstantShield,
        GuardianAngel,

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