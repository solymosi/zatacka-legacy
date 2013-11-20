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
            double NewX = Location.X + X * 5;
            double NewY = Location.Y + Y * 5;

            Point LocationOfBazookaBullet = new Point(NewX, NewY);


            //Ellenőrizni kell, h a hely, ahová raknánk, a pályán belül van-e
            double UpperBoundry = Player.Game.Arena.Location.Y;
            double LowerBoundry = Player.Game.Arena.Location.Y + Player.Game.Arena.Size.Height;
            double LeftBoundry  = Player.Game.Arena.Location.X;
            double RightBoundry = Player.Game.Arena.Location.X + Player.Game.Arena.Size.Width;


            if (NewX > LeftBoundry && NewX < RightBoundry && NewY > UpperBoundry && NewY < LowerBoundry)
            {
                BazookaBullet = new Unit.Game.Goodie.Bullet(this, Player.Game.Arena, LocationOfBazookaBullet);
                Player.Game.Arena.Add(BazookaBullet);
                BazookaBullet.Colliders.Add(new Zatacka.Unit.Collision.Target(BazookaBullet, new EllipseGeometry(BazookaBullet.Center, BazookaBullet.Size.Width, BazookaBullet.Size.Height)));
            }
            else
            {
                this.Active = false;
                BazookaBullet.Kill();
                Player.Game.Dispatcher.Log.Add("Bazooka pályán kívül termett volna.");
            }
           
            

            base.Enter();
        }
        public override void Execute()
        {

            BazookaBullet = this.BazookaBullet;
            //Player.Game.Dispatcher.Log.Add("Bazooka pályán belül.");

            double X = Math.Sin(Heading.ToRadians()) * Player.Game.MovementSpeed;
            double Y = Math.Cos(Heading.ToRadians()) * Player.Game.MovementSpeed * -1;

            double NewX = BazookaBullet.Center.X + Math.Sin(Heading.ToRadians()) * Player.Game.MovementSpeed;
            double NewY = BazookaBullet.Center.Y + Math.Cos(Heading.ToRadians()) * Player.Game.MovementSpeed * -1;
            
            double UpperBoundry = Player.Game.Arena.Location.Y;
            double LowerBoundry = Player.Game.Arena.Location.Y + Player.Game.Arena.Size.Height;
            double LeftBoundry  = Player.Game.Arena.Location.X;
            double RightBoundry = Player.Game.Arena.Location.X + Player.Game.Arena.Size.Width;

                        
            if (NewX > LeftBoundry && NewX < RightBoundry && NewY > UpperBoundry && NewY < LowerBoundry)
            {
                BazookaBullet.Center = new Point(NewX, NewY);
                BazookaBullet.Colliders.Remove(BazookaBullet.Colliders.Last());
                BazookaBullet.Colliders.Add(new Zatacka.Unit.Collision.Target(BazookaBullet, new EllipseGeometry(BazookaBullet.Center, BazookaBullet.Size.Width, BazookaBullet.Size.Height)));
            }
            else
            {
                BazookaBullet.Colliders.Remove(BazookaBullet.Colliders.Last());
                this.Active = false;
                //BazookaBullet.Colliders.Clear();
                //BazookaBullet.Canvas.Remove(BazookaBullet);
                BazookaBullet.Kill();
                Player.Game.Dispatcher.Log.Add("Bazooka pályán kívül.");
            }
            
        }
    }
}