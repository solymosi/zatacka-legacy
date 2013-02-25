using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace Zatacka.Menu
{
    class Main : Menu
    {
        public Unit.Text Title { get; private set; }
        public List<KeyValuePair<Item, Unit.Text>> Labels { get; private set; }
        public Item Selected { get; private set; }
        public Unit.Shape.Rectangle Highlight { get; private set; }

        public Main(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Title = new Unit.Text(Canvas, "Zatacka Legacy", 72, FontWeights.Bold, FontStyles.Normal, Brushes.White, new Point(0, Canvas.Size.Height * 0.15), new Size(Canvas.Size.Width, 0), TextAlignment.Center);
            Canvas.Add(Title);

            Labels = new List<KeyValuePair<Item, Unit.Text>>();
            Add(Item.NewGame, new Unit.Text(Canvas, "New Game", 36, FontWeights.Bold, FontStyles.Normal, Brushes.White, new Point(0, Canvas.Size.Height * 0.5), new Size(Canvas.Size.Width, 0), TextAlignment.Center));
            Add(Item.Credits, new Unit.Text(Canvas, "Credits", 36, FontWeights.Bold, FontStyles.Normal, Brushes.White, new Point(0, Canvas.Size.Height * 0.6), new Size(Canvas.Size.Width, 0), TextAlignment.Center));
            Add(Item.Exit, new Unit.Text(Canvas, "Exit", 36, FontWeights.Bold, FontStyles.Normal, Brushes.White, new Point(0, Canvas.Size.Height * 0.7), new Size(Canvas.Size.Width, 0), TextAlignment.Center));

            Highlight = new Unit.Shape.Rectangle(Canvas, new Rect(Canvas.Size.Width / 2 - 200, 0, 400, 70), new SolidColorBrush(Color.FromArgb(255, 112, 146, 190)), null);
            Select(Item.Exit);
            Select(Item.Credits);
        }

        protected void Add(Item Item, Unit.Text Label)
        {
            Labels.Add(new KeyValuePair<Main.Item, Unit.Text>(Item, Label));
            Canvas.Add(Label);
        }

        protected void Select(Item Item)
        {
            Unit.Text Label = Labels.First((KeyValuePair<Item, Unit.Text> K) => { return K.Key == Item; }).Value;
            Highlight.Location = new Point(Canvas.Size.Width / 2 - 200, Label.Location.Y + Label.LineHeight * Label.FontSize / 2 - Highlight.Size.Height / 2);
            Selected = Item;

            if (!Canvas.Contains(Highlight))
            {
                Canvas.Add(Highlight, Unit.AbsolutePosition.Bottom);
            }
        }

        protected void SelectPrevious()
        {
            int I = Labels.FindIndex((KeyValuePair<Item, Unit.Text> K) => K.Key == Selected);
            Select(Labels[I == 0 ? Labels.Count - 1 : I - 1].Key);
        }

        protected void SelectNext()
        {
            int I = Labels.FindIndex((KeyValuePair<Item, Unit.Text> K) => K.Key == Selected);
            Select(Labels[(I + 1) % Labels.Count].Key);
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Up)
            {
                SelectPrevious();
            }

            if (Button == Key.Down)
            {
                SelectNext();
            }

            if (Button == Key.Return)
            {
                switch (Selected)
                {
                    case Item.NewGame:
                        Dispatcher.Add(State.Dispatcher.State.Create, new Create(Dispatcher), true);
                        Dispatcher.Change(State.Dispatcher.State.Create);
                        return;
                    case Item.Credits:
                        return;
                    case Item.Exit:
                        Dispatcher.Exit();
                        return;
                }
            }
        }

        protected override void Update() { }

        public enum Item
        {
            NewGame,
            Credits,
            Exit
        }
    }
}
