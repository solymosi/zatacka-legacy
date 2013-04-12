using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zatacka.Goodie
{
    abstract class Goodie : State.State
    {
        public Category Category { get; protected set; }
        public Type Type { get; protected set; }
        public Player.Player Player { get; set; }

        public bool Active { get; set; }
        public bool HasIcon { get; set; }

        public Goodie()
        {

        }

        public override void Enter()
        {
            
        }

        public override void Execute()
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

    public enum Type //DG átírtam static-re
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