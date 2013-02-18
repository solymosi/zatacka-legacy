﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Zatacka.Menu
{
    class Menu : State.Screen
    {

        /*List<Brush> PlayerColors = new List<Brush>();*/
        List<string> Actions = new List<string>();
        List<Unit.Text> Textes = new List<Unit.Text>();
        List<Unit.Shape.Rectangle> Rectangles = new List<Unit.Shape.Rectangle>();

        public Menu(State.Dispatcher Dispatcher)
            : base(Dispatcher)
        {
            Canvas.Background = new SolidColorBrush(Colors.DarkRed);

            /*PlayerColors.Add(Brushes.Red); 
            PlayerColors.Add(Brushes.Green);
            PlayerColors.Add(Brushes.Yellow);
            PlayerColors.Add(Brushes.Blue);
            PlayerColors.Add(Brushes.Cyan);
            PlayerColors.Add(Brushes.Pink);*/

            Actions.Add("2 1 Q");
            Actions.Add("K M ,");
            Actions.Add("Down Left Up");
            Actions.Add("C Y X");
            Actions.Add("R 4 5");
            Actions.Add("+ 6 9");

            /*Canvas.Add(new Unit.Text(
                Canvas,
                "This is the MENU.\r\nPress ENTER to switch to GAME state.\r\nPress ESC to quit.",
                48,
                FontWeights.Bold,
                FontStyles.Normal,
                Brushes.LightYellow,
                new Point(0, 100),
                new Size(Canvas.Size.Width, 0),
                TextAlignment.Center
                ));*/

            int startPos = 200;
            int fontSize = 48;

            for (int i = 1; i <7 ; i++) 
            {
                Unit.Text TextTmp = new Unit.Text(Canvas, "Player" + i + "  " + Actions[i-1], fontSize, FontWeights.Normal, FontStyles.Normal, Brushes.Gray, new Point(startPos, startPos / 2 + i * fontSize), new Size(0, 0));
                //Unit.Shape.Rectangle RectTmp = new Unit.Shape.Rectangle(Canvas, new Rect(startPos - 50, startPos / 2 +  + i * fontSize, 20, 20), PlayerColors[i - 1], null);
                Textes.Add(TextTmp);
                //Rectangles.Add(RectTmp);
                Canvas.Add(TextTmp);
                //Canvas.Add(RectTmp);
            }
        }

        public override void Input(Key Button)
        {
            if (Button == Key.Enter)
            {
                Dispatcher.Change(State.Dispatcher.State.Game);

                /*Player seven = new Player(, Colors.Orange);
                seven.Buttons.Add(Key.D1, Action.Left);
                seven.Buttons.Add(Key.Q, Action.Right);
                seven.Buttons.Add(Key.D2, Action.Trigger);
                //this[State.Game].As<Game.Slayer>().Players.Add(seven);*/

            }

            if (Button == Key.Escape)
            {
                Dispatcher.Exit();
            }

            switch (Button) 
            {
                case Key.D2:
                    //Textes[0].FontWeight = Textes[0].FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
                    Textes[0].Fill = Textes[0].Fill == Brushes.Gray ? Brushes.Red : Brushes.Gray;
                    break;
                case Key.K:
                    //Textes[1].FontWeight = Textes[1].FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
                    Textes[1].Fill = Textes[1].Fill == Brushes.Gray ? Brushes.Green : Brushes.Gray;
                    break;
                case Key.Down:
                    //Textes[2].FontWeight = Textes[2].FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
                    Textes[2].Fill = Textes[2].Fill == Brushes.Gray ? Brushes.Yellow : Brushes.Gray;
                    break;
                case Key.C:
                    //Textes[3].FontWeight = Textes[3].FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
                    Textes[3].Fill = Textes[3].Fill == Brushes.Gray ? Brushes.Blue : Brushes.Gray;
                    break;
                case Key.R:
                    //Textes[4].FontWeight = Textes[4].FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
                    Textes[4].Fill = Textes[4].Fill == Brushes.Gray ? Brushes.Cyan : Brushes.Gray;
                    break;
                case Key.Add:
                    //Textes[5].FontWeight = Textes[5].FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
                    Textes[5].Fill = Textes[5].Fill == Brushes.Gray ? Brushes.Pink : Brushes.Gray;
                    break;
            }
        }

        protected override void Update()
        {
            
        }
    }
}