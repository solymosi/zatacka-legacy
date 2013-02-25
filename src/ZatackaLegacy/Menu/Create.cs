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
        public List<Player.Template> Selected { get; private set; }
        public Dictionary<Player.Template, Unit.Text> Labels { get; private set; }
        public Unit.Text PressEnter { get; private set; }

        public Create(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Selected = new List<Player.Template>();
            Labels = new Dictionary<Player.Template, Unit.Text>();

            for (int i = 1; i <= 7; i++)
            {
                Player.Template T = Player.Template.Templates[i];
                Unit.Text Text = new Unit.Text(Canvas, "Player " + i + " - " + string.Join(" ", T.KeyboardButtons.Keys.Select((Key K) => { return K.ToString(); })) + string.Join(" ", T.MouseButtons.Keys.Select((MouseButton M) => { return M.ToString(); })), 48, Brushes.Gray, new Point(200, 200 + (i - 1) * 60));
                Labels[T] = Text;
                Canvas.Add(Text);
            }

            PressEnter = new Unit.Text(Canvas, "Press ENTER to start the game.", 48, FontWeights.Bold, FontStyles.Normal, Brushes.White, new Point(0, Canvas.Size.Height - 80), new Size(Canvas.Size.Width, 0), TextAlignment.Center);
            PressEnter.Opacity = 0;
            Canvas.Add(PressEnter);
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
                Dispatcher.Exit();
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

            PressEnter.Opacity = Selected.Count >= 2 ? 1 : 0;
        }

        protected override void Update() { }
    }
}
