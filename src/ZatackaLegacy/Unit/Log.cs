using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ZatackaLegacy
{
    public class Log : Unit
    {
        public List<string> Messages = new List<string>();

        public Log()
            : base(new Point(10, 10), Colors.White, 0) { }

        public override void Draw(bool First)
        {
            using (DrawingContext Context = Visual.RenderOpen())
            {
                Context.DrawText(new FormattedText(string.Join("\r\n", Messages.GetRange(Math.Max(Messages.Count - 20, 0), Math.Min(Messages.Count, 20))), System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Consolas"), 10, new SolidColorBrush(Color)), Location);
            }
        }

        public override List<Point> CollisionsWith(Target Target, double Threshold)
        {
            return new List<Point>();
        }
    }
}