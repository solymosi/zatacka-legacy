using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace Zatacka.Player
{
    /// <summary>
    /// Represents individual players during a game.
    /// </summary>
    class Player : Template
    {
        /// <summary>
        /// Contains the default player templates from which new players can be created.
        /// </summary>
        static public Dictionary<int, Template> Templates { get; private set; }

        /// <summary>
        /// Creates and initializes the default player templates.
        /// </summary>
        static Player()
        {
            Template Template = null;
            Templates = new Dictionary<int, Template>();

            Template = new Template("Player 1", Colors.Red);
            Template.Bind(Key.D1, Action.Left);
            Template.Bind(Key.Q, Action.Right);
            Template.Bind(Key.D2, Action.Trigger);
            Templates.Add(1, Template);

            Template = new Template("Player 2", Colors.Yellow);
            Template.Bind(Key.LeftCtrl, Action.Left);
            Template.Bind(Key.LeftAlt, Action.Right);
            Template.Bind(Key.X, Action.Trigger);
            Templates.Add(2, Template);

            Template = new Template("Player 3", Colors.Blue);
            Template.Bind(Key.D4, Action.Left);
            Template.Bind(Key.D5, Action.Right);
            Template.Bind(Key.R, Action.Trigger);
            Templates.Add(3, Template);

            Template = new Template("Player 4", Colors.Gold);
            Template.Bind(Key.M, Action.Left);
            Template.Bind(Key.OemComma, Action.Right);
            Template.Bind(Key.K, Action.Trigger);
            Templates.Add(4, Template);

            Template = new Template("Player 5", Colors.Pink);
            Template.Bind(Key.Left, Action.Left);
            Template.Bind(Key.Down, Action.Right);
            Template.Bind(Key.Up, Action.Trigger);
            Templates.Add(5, Template);

            Template = new Template("Player 6", Colors.Green);
            Template.Bind(Key.Divide, Action.Left);
            Template.Bind(Key.Multiply, Action.Right);
            Template.Bind(Key.Subtract, Action.Trigger);
            Templates.Add(6, Template);

            Template = new Template("Player 7", Colors.Cyan);
            Template.Bind(MouseButton.Left, Action.Left);
            Template.Bind(MouseButton.Right, Action.Right);
            Template.Bind(MouseButton.Middle, Action.Trigger);
            Templates.Add(7, Template);
        }

        /// <summary>
        /// The Game instance this Player belongs to.
        /// </summary>
        public Game.Game Game { get; protected set; }

        /// <summary>
        /// The Curve instance belonging to this Player.
        /// </summary>
        public Unit.Game.Curve.Curve Curve { get; protected set; }

        /// <summary>
        /// The player's score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Contains every Goodie the player has collected.
        /// </summary>
        public List<Goodie.Goodie> Goodies { get; protected set; }

        /// <summary>
        /// Creates a Player instance from a player template.
        /// </summary>
        /// <param name="Game">The Game instance this Player will belong to.</param>
        /// <param name="Template">The player template to create this Player from.</param>
        public Player(Game.Game Game, Template Template)
            : this(Game, Template.Name, Template.Color)
        {
            foreach (Key Button in Template.KeyboardButtons.Keys)
            {
                KeyboardButtons.Add(Button, Template.KeyboardButtons[Button]);
            }

            foreach (MouseButton Button in Template.MouseButtons.Keys)
            {
                MouseButtons.Add(Button, Template.MouseButtons[Button]);
            }
        }

        /// <summary>
        /// Creates a Player instance with the specified parameters.
        /// </summary>
        /// <param name="Game">The Game instance this Player will belong to.</param>
        /// <param name="Name">The name of this Player.</param>
        /// <param name="Color">The color of this Player and its curve.</param>
        public Player(Game.Game Game, string Name, Color Color)
            : base(Name, Color)
        {
            this.Game = Game;
            this.Goodies = new List<Goodie.Goodie>();
        }

        /// <summary>
        /// Checks whether any of the keyboard and mouse buttons assigned to this Player are currently pressed and calls Game.Input with the corresponding Action values.
        /// </summary>
        public void Input()
        {
            foreach (KeyValuePair<Key, Action> Item in KeyboardButtons)
            {
                if (Tools.KeyboardPressed(Item.Key))
                {
                    Game.Input(this, Item.Value);
                }
            }

            foreach (KeyValuePair<MouseButton, Action> Item in MouseButtons)
            {
                if (Tools.MousePressed(Item.Key))
                {
                    Game.Input(this, Item.Value);
                }
            }
        }

        /// <summary>
        /// Creates the Curve of this Player and places it on the game arena.
        /// </summary>
        public void CreateCurve()
        {
            if (Curve != null)
            {
                Game.Arena.Remove(Curve);
            }

            Curve = new Unit.Game.Curve.Curve(Game.Arena, new Point(Tools.Random(0, Game.Arena.Size.Width), Tools.Random(0, Game.Arena.Size.Height)), Tools.Random(0, 359), Color);
            Game.Arena.Add(Curve);
        }
    }

    /// <summary>
    /// Describes an action of a game player.
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// Turn the curve left.
        /// </summary>
        Left,

        /// <summary>
        /// Turn the curve right.
        /// </summary>
        Right,

        /// <summary>
        /// Trigger the effect of the currently active power-up (e.g: fire a weapon).
        /// </summary>
        Trigger
    }
}