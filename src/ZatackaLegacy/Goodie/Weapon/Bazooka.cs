using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Goodie.Weapon
{
    class Bazooka : Weapon
    {
        public Point Location { get; set; }
        public double Heading { get; set; }
        public Unit.Game.Goodie.Bullet BazookaBullet { get; set; }

        public Bazooka()
        {
            Type = Zatacka.Goodie.Type.Bazooka;
        }
        public override void Enter()
        {
            Player.Game.Dispatcher.Log.Add("Bazooka-Enter, Player: " + Player.Name);
            
            Location = Player.Curve.Head;
            Heading = Player.Curve.Heading;

            double X = Math.Sin(Heading.ToRadians()) * Player.Game.MovementSpeed;
            double Y = Math.Cos(Heading.ToRadians()) * Player.Game.MovementSpeed * -1;

            Point LocationOfBazookaBullet = new Point(Location.X + X * 5, Location.Y + Y * 5);

            //Ellenőrizni kell, h a hely, ahová raknánk, a pályán belül van-e

            /*Add(Next);

            if (!Gap && Head.DistanceFrom(Target.Location) >= Game.CurveRadius * 2)
            {
                Add(new Target(this, Next, Game.CurveRadius, Target));
            }
            */
            BazookaBullet = new Unit.Game.Goodie.Bullet(Player.Game.Arena, LocationOfBazookaBullet);
            Player.Game.Arena.Add(BazookaBullet);

            base.Enter();
        }
        public override void Execute()
        {
            BazookaBullet = this.BazookaBullet;
            Player.Game.Dispatcher.Log.Add("Player: " + Player.Name + "PEEEEEEEW!");

            double X = Math.Sin(Heading.ToRadians()) * Player.Game.MovementSpeed;
            double Y = Math.Cos(Heading.ToRadians()) * Player.Game.MovementSpeed * -1;
            
            BazookaBullet.Center = new Point(BazookaBullet.Center.X + X, BazookaBullet.Center.Y + Y);
        }
        
    }
}