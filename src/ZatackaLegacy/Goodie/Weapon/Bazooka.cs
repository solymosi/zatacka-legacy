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
        public Game.Game G { get; set; }
        public Player.Player P { get; set; }
        public Point Location { get; set; }
        public double Heading { get; set; }
        public Unit.Game.Goodie.Bullet BazookaBullet { get; set; }

        public Bazooka()
        {

        }
        public Bazooka(Game.Game Game, Player.Player Player)
        {
            Type = Type.Bazooka;
            this.G = Game;
            this.P = Player;
        }
        public override void Enter()
        {
            G.Dispatcher.Log.Add("Bazooka-Enter, Player: " + P.Name);
            
            Location = P.Curve.Head;
            Heading = P.Curve.Heading;

            double X = Math.Sin(Heading.ToRadians()) * G.MovementSpeed;
            double Y = Math.Cos(Heading.ToRadians()) * G.MovementSpeed * -1;

            Point LocationOfBazookaBullet = new Point(Location.X + X * 20, Location.Y + Y * 20);

            //Ellenőrizni kell, h a hely, ahová raknánk, a pályán belül van-e

            /*Add(Next);

            if (!Gap && Head.DistanceFrom(Target.Location) >= Game.CurveRadius * 2)
            {
                Add(new Target(this, Next, Game.CurveRadius, Target));
            }
            */
            BazookaBullet = new Unit.Game.Goodie.Bullet(G.Arena, LocationOfBazookaBullet);
            G.Arena.Add(BazookaBullet);
        }
        public override void Execute()
        {
            
            BazookaBullet = this.BazookaBullet;
            

            double NewX = BazookaBullet.Center.X + Math.Sin(Heading.ToRadians()) * G.MovementSpeed;
            double NewY = BazookaBullet.Center.Y + Math.Cos(Heading.ToRadians()) * G.MovementSpeed * -1;



            double UpperBoundry = G.Arena.Location.Y;
            double LowerBoundry = G.Arena.Location.Y + G.Arena.Size.Height;
            double LeftBoundry = G.Arena.Location.X;
            double RightBoundry = G.Arena.Location.X + G.Arena.Size.Width;

            if (NewX > LeftBoundry && NewX < RightBoundry && NewY > UpperBoundry && NewY < LowerBoundry)
            {
                BazookaBullet.Center = new Point(NewX, NewY);
            }
            else
            {
                //Goodie kiiktatása
                G.Dispatcher.Log.Add("Goodie pályán kívül.");
            }
            
        }
        
    }
}