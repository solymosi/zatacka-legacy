using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Globalization;

namespace Zatacka.Unit
{
    /// <summary>
    /// Stores and displays a fixed number of log messages.
    /// </summary>
    class Log : Unit
    {
        /// <summary>
        /// Specifies the number of messages to store and display.
        /// </summary>
        public int DisplayMessages { get; private set; }

        /// <summary>
        /// Contains the log messages.
        /// </summary>
        private List<string> Messages { get; set; }

        /// <summary>
        /// Specifies whether new messages have been added since the log was last rendered.
        /// </summary>
        private bool Changed { get; set; }

        /// <summary>
        /// Creates the Log and sets the number of stored log messages.
        /// </summary>
        /// <param name="Canvas">The Canvas this Log is displayed on.</param>
        public Log(Canvas.Canvas Canvas)
            : base(Canvas)
        {
            Messages = new List<string>();
            DisplayMessages = 25;
        }

        /// <summary>
        /// Adds a message to the Log.
        /// </summary>
        /// <param name="Message">The message to add.</param>
        public void Add(string Message)
        {
            if (Messages.Count >= DisplayMessages)
            {
                Messages.RemoveAt(0);
            }

            Messages.Add(Message);
            Changed = true;
        }

        /// <summary>
        /// Executes and measures the specified System.Action using Tools.Measure and displays its run time in the Log.
        /// </summary>
        /// <param name="Action">The System.Action to measure. Possible usage: new System.Action( delegate { ... } )</param>
        public void Measure(System.Action Action) { Measure(null, Action); }

        /// <summary>
        /// Executes and measures the specified System.Action using Tools.Measure and displays its run time along with a custom name in the Log.
        /// </summary>
        /// <param name="Name">The name of this measurement.</param>
        /// <param name="Action">The System.Action to measure. Possible usage: new System.Action( delegate { ... } )</param>
        public void Measure(string Name, System.Action Action)
        {
            Add((Name == null ? "" : Name + ": ") + Tools.Measure(Action).ToString() + " ms");
        }

        /// <summary>
        /// Renders the Log on the screen.
        /// </summary>
        protected override void Update()
        {
            if (Changed)
            {
                using (DrawingContext Context = RenderOpen())
                {
                    Context.DrawText(new FormattedText(string.Join("\r\n", Messages), CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Consolas"), 10, Brushes.White), new Point(10, 10));
                }

                Changed = false;
            }
        }
    }
}