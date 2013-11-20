﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Zatacka.Unit.Game.Goodie
{
    class Bullet : Shape.Ellipse
    {
        public static double BulletRadius = 10;

        public Bullet(Zatacka.Goodie.Goodie Goodie, Canvas.Game Canvas, Point Center)
            : base(Canvas, Center, new Size(BulletRadius, BulletRadius), Brushes.White, null)
        {
            EnableCollisions = true;
            this.Add(new Text(Canvas, "Bazooka", 10, Brushes.LightBlue, null, new Point(Center.X - BulletRadius, Center.Y - BulletRadius), new Size(Size.Width, Size.Height), TextAlignment.Center));
        }

        /// <summary>
        /// Kills this Curve and prevents it from moving or colliding with others.
        /// </summary>
        public void Kill()
        {
            this.Colliders.Clear();
            this.Canvas.Remove(this);
        }
    }
}
