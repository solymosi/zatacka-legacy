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
        public Dictionary<Player.Template, Unit.Shape.Rectangle> Squares { get; private set; }
        public Dictionary<Player.Template, Unit.Text> Labels { get; private set; }
        public Dictionary<Player.Template, List<Unit.Unit>> Buttons { get; private set; }

        public Create(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Title = new Unit.Text(Canvas, "New Game", 72, FontWeights.Bold, FontStyles.Normal, Brushes.White, null, new Point(0, Canvas.Size.Height * 0.15), new Size(Canvas.Size.Width, 0), TextAlignment.Center);
            Canvas.Add(Title);

            Subtitle = new Unit.Text(Canvas, "Select players by pressing their buttons...", 30, new Point(0, Canvas.Size.Height * 0.3), new Size(Canvas.Size.Width, 0), TextAlignment.Center);
            Canvas.Add(Subtitle);

            Selected = new List<Player.Template>();
            Squares = new Dictionary<Player.Template, Unit.Shape.Rectangle>();
            Labels = new Dictionary<Player.Template, Unit.Text>();
            Buttons = new Dictionary<Player.Template, List<Unit.Unit>>();

            for (int i = 1; i <= 7; i++)
            {
                Player.Template T = Player.Template.Templates[i];

                double Y = Canvas.Size.Height * (0.45 + (i - 1) * 0.07);
                Unit.Shape.Rectangle Square = new Unit.Shape.Rectangle(Canvas, new Rect(Canvas.Size.Width / 2 - 300, Y - 20, 40, 40), Brushes.Gray, null);
                Squares[T] = Square;
                Canvas.Add(Square);

                Unit.Text Text = new Unit.Text(Canvas, T.Name, 30, FontWeights.Bold, FontStyles.Normal, Brushes.Gray, null, new Point(Canvas.Size.Width / 2 - 230, Y - 15 * Unit.Text.DefaultLineHeight), new Size(300, 0));
                Labels[T] = Text;
                Canvas.Add(Text);

                Buttons[T] = new List<Unit.Unit>();
                double X = Canvas.Size.Width / 2;

                foreach (Player.Action Action in new Player.Action[] { Player.Action.Left, Player.Action.Right, Player.Action.Trigger })
                {
                    string Name = T.KeyboardButtons.Where((KeyValuePair<Key, Player.Action> P) => { return P.Value == Action; }).Select((KeyValuePair<Key, Player.Action> P) => { return P.Key.Label(); }).Concat(T.MouseButtons.Where((KeyValuePair<MouseButton, Player.Action> P) => { return P.Value == Action; }).Select((KeyValuePair<MouseButton, Player.Action> P) => { return P.Key.Label(); })).First();
                    Unit.Text Label = new Unit.Text(Canvas, Name, 20, FontWeights.Bold, FontStyles.Normal, Brushes.White, null, new Point(X + 20, Y - 10 * Unit.Text.DefaultLineHeight));
                    Unit.Shape.Rectangle Button = new Unit.Shape.Rectangle(Canvas, new Rect(Label.ContentBounds.X - 18, Y - 20, Label.ContentBounds.Width + 36, 40), new SolidColorBrush { Color = Colors.Gray, Opacity = 0.5 }, null);
                    Button.Add(Label);
                    Canvas.Add(Button);
                    Buttons[T].Add(Button);
                    X += Button.Size.Width + 20;
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
                bool Select = Selected.Contains(T);
                Brush Fill = new SolidColorBrush(T.Color);

                Squares[T].Fill = Select ? Fill : Brushes.Gray;
                Labels[T].Fill = Select ? Fill : Brushes.Gray;
            }

            Subtitle.Label = Selected.Count >= 2 ? "Press ENTER to start the game!" : "Select players by pressing their buttons...";
            Subtitle.FontWeight = Selected.Count >= 2 ? FontWeights.Bold : FontWeights.Normal;
        }

        protected override void Update() { }
    }
}