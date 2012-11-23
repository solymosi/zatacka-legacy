using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Globalization;

namespace Zatacka.Unit
{
    class Log : Unit
    {
        public int DisplayMessages { get; private set; }
        private List<string> Messages { get; set; }

        public Log(Canvas.Canvas Canvas)
            : base(Canvas)
        {
            Messages = new List<string>();
            DisplayMessages = 25;
        }

        public void Add(string Message)
        {
            if (Messages.Count >= DisplayMessages) { Messages.RemoveAt(0); }
            Messages.Add(Message);
            Draw();
        }

        public void Measure(System.Action Action) { Measure(null, Action); }
        public void Measure(string Name, System.Action Action)
        {
            Add((Name == null ? "" : Name + ": ") + Tools.Measure(Action).ToString() + " ms");
        }

        public override void Draw(long Lifetime)
        {
            using (DrawingContext Context = RenderOpen())
            {
                Context.DrawText(new FormattedText(string.Join("\r\n", Messages), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Consolas"), 10, new SolidColorBrush(Colors.White)), new Point(10, 10));
            }
        }
    }
}