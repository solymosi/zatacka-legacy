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
        public Point LocationOfCurveHead { get; set; }
        public double HeadingOfCurve { get; set; }

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
            
            LocationOfCurveHead = P.Curve.Head;
            HeadingOfCurve = P.Curve.Heading;

            double X = Math.Sin(HeadingOfCurve.ToRadians()) * G.MovementSpeed;
            double Y = Math.Cos(HeadingOfCurve.ToRadians()) * G.MovementSpeed * -1;

            Point LocationOfBazookaBullet = new Point(LocationOfCurveHead.X + X*20, LocationOfCurveHead.Y + Y*20);

            /*Add(Next);

            if (!Gap && Head.DistanceFrom(Target.Location) >= Game.CurveRadius * 2)
            {
                Add(new Target(this, Next, Game.CurveRadius, Target));
            }
            */
            Unit.Game.Goodie.Bullet BazookaBullet = new Unit.Game.Goodie.Bullet(G.Arena, LocationOfBazookaBullet);
            G.Arena.Add(BazookaBullet);
        }
        public override void Execute()
        {
            
            //Game.Dispatcher.Log.Add("Bazooka-Execute");
        }
        
    }
}