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
            this.Initialize();
        }

        /// <summary>
        /// Creates a Player instance with the specified parameters and keyboard button assignments.
        /// </summary>
        /// <param name="Game">The Game instance this Player will belong to.</param>
        /// <param name="Name">The name of this Player.</param>
        /// <param name="Color">The color of this Player and its curve.</param>
        /// <param name="Left">Button used to turn the curve left.</param>
        /// <param name="Right">Button used to turn the curve right.</param>
        /// <param name="Trigger">Button used to trigger the effect of the currently active power-up (e.g: fire a weapon).</param>
        public Player(Game.Game Game, string Name, Color Color, Key Left, Key Right, Key Trigger)
            : base(Name, Color, Left, Right, Trigger)
        {
            this.Game = Game;
            this.Initialize();
        }

        /// <summary>
        /// Creates a Player instance with the specified parameters and mouse button assignments.
        /// </summary>
        /// <param name="Game">The Game instance this Player will belong to.</param>
        /// <param name="Name">The name of this Player.</param>
        /// <param name="Color">The color of this Player and its curve.</param>
        /// <param name="Left">Button used to turn the curve left.</param>
        /// <param name="Right">Button used to turn the curve right.</param>
        /// <param name="Trigger">Button used to trigger the effect of the currently active power-up (e.g: fire a weapon).</param>
        public Player(Game.Game Game, string Name, Color Color, MouseButton Left, MouseButton Right, MouseButton Trigger)
            : base(Name, Color, Left, Right, Trigger)
        {
            this.Game = Game;
            this.Initialize();
        }

        /// <summary>
        /// Initializes the state of this Player.
        /// </summary>
        private void Initialize()
        {
            Goodies = new List<Goodie.Goodie>();
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