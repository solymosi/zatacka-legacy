using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Game.Goodie
{
    class Bullet : Shape.Ellipse
    {
        public static double BulletRadius = 20;

        public Bullet(Canvas.Game Canvas, Point Center)
            : base(Canvas, Center, new Size(BulletRadius, BulletRadius), Brushes.White, null)
        {
            EnableCollisions = true;
            this.Add(new Text(Canvas, "Bazooka", 20, Brushes.LightBlue, null, new Point(Center.X - BulletRadius, Center.Y - BulletRadius), new Size(Size.Width, Size.Height), TextAlignment.Center));
            this.Colliders.Add(new Collision.Target(this, new EllipseGeometry(Center, BulletRadius, BulletRadius)));
        }
    }
}
