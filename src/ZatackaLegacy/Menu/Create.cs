using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Zatacka.Menu
{
    class Create : Menu
    {
        public Unit.Text Title { get; private set; }
        public Unit.Text Subtitle { get; private set; }
        public List<Player.Template> Selected { get; private set; }
        public Dictionary<Player.Template, Unit.Text> Labels { get; private set; }
        public Dictionary<Player.Template, List<Unit.Text>> Buttons { get; private set; }

        public Create(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Title = new Unit.Text(Canvas, "New Game", 72, FontWeights.Bold, FontStyles.Normal, Brushes.White, null, new Point(0, Canvas.Size.Height * 0.15), new Size(Canvas.Size.Width, 0), TextAlignment.Center);
            Canvas.Add(Title);

            Subtitle = new Unit.Text(Canvas, "Select players by pressing their buttons...", 30, new Point(0, Canvas.Size.Height * 0.3), new Size(Canvas.Size.Width, 0), TextAlignment.Center);
            Canvas.Add(Subtitle);

            Selected = new List<Player.Template>();
            Labels = new Dictionary<Player.Template, Unit.Text>();
            Buttons = new Dictionary<Player.Template, List<Unit.Text>>();

            for (int i = 1; i <= 7; i++)
            {
                Player.Template T = Player.Template.Templates[i];

                double Y = Canvas.Size.Height * (0.45 + (i - 1) * 0.07);
                Unit.Shape.Rectangle Color = new Unit.Shape.Rectangle(Canvas, new Rect(Canvas.Size.Width / 2 - 300, Y - 20, 40, 40), new SolidColorBrush(T.Color), null);
                Canvas.Add(Color);

                Unit.Text Text = new Unit.Text(Canvas, T.Name, 30, FontWeights.Bold, FontStyles.Normal, Brushes.Gray, null, new Point(Canvas.Size.Width / 2 - 230, Y - 15 * Unit.Text.DefaultLineHeight), new Size(300, 0));
                Labels[T] = Text;
                Canvas.Add(Text);

                Buttons[T] = new List<Unit.Text>();
                foreach (Player.Action Action in new Player.Action[] { Player.Action.Left, Player.Action.Right, Player.Action.Trigger })
                {
                    string Label = T.KeyboardButtons.Where((KeyValuePair<Key, Player.Action> P) => { return P.Value == Action; }).Select((KeyValuePair<Key, Player.Action> P) => { return P.Key.Label(); }).Concat(T.MouseButtons.Where((KeyValuePair<MouseButton, Player.Action> P) => { return P.Value == Action; }).Select((KeyValuePair<MouseButton, Player.Action> P) => { return P.Key.Label(); })).First();
                    
                    //Buttons[T].Add(
                }
            }
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Enter && Selected.Count >= 2)
            {
                Dispatcher.Game = new Game.Slayer(Dispatcher);
                foreach (Player.Template T in Selected)
                {
                    Dispatcher.Game.Players.Add(new Player.Player(Dispatcher.Game, T));
                }
                Dispatcher.Remove(State.Dispatcher.State.Game);
                Dispatcher.Add(State.Dispatcher.State.Game, Dispatcher.Game);
                Dispatcher.Change(State.Dispatcher.State.Game);
                return;
            }

            if (Button == Key.Escape)
            {
                Dispatcher.Change(State.Dispatcher.State.Main);
                return;
            }

            foreach (Player.Template T in Player.Template.Templates.Values)
            {
                if (T.KeyboardButtons.ContainsKey(Button))
                {
                    if (Selected.Contains(T)) { Selected.Remove(T); }
                    else { Selected.Add(T); }
                }
            }

            Draw();
        }

        public override void Input(MouseButton Button)
        {
            foreach (Player.Template T in Player.Template.Templates.Values)
            {
                if (T.MouseButtons.ContainsKey(Button))
                {
                    if (Selected.Contains(T)) { Selected.Remove(T); }
                    else { Selected.Add(T); }
                }
            }

            Draw();
        }

        private void Draw()
        {
            foreach (Player.Template T in Player.Template.Templates.Values)
            {
                if (Selected.Contains(T)) { Labels[T].Fill = new SolidColorBrush(T.Color); }
                else { Labels[T].Fill = Brushes.Gray; }
            }

            Subtitle.Label = Selected.Count >= 2 ? "Press ENTER to start the game!" : "Select players by pressing their buttons...";
            Subtitle.FontWeight = Selected.Count >= 2 ? FontWeights.Bold : FontWeights.Normal;
        }

        protected override void Update() { }
    }
}