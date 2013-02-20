﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace Zatacka
{
    /// <summary>
    /// Represents individual players during a game.
    /// </summary>
    class Player
    {
        /// <summary>
        /// The Game instance this Player belongs to.
        /// </summary>
        public Game.Game Game { get; private set; }

        /// <summary>
        /// The Curve instance belonging to this Player.
        /// </summary>
        public Unit.Game.Curve.Curve Curve { get; private set; }

        /// <summary>
        /// The color of this Player and its curve.
        /// </summary>
        public Color Color { get; private set; }

        /// <summary>
        /// Contains the keyboard buttons assigned to this Player and the actions they perform.
        /// </summary>
        public Dictionary<Key, Action> Buttons { get; private set; }

        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The player's score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Contains every Goodie the player has collected.
        /// </summary>
        public List<Goodie.Goodie> Goodies { get; private set; }

        /// <summary>
        /// Creates a Player instance with the specified parameters. Also creates the player's Curve and adds it to the game's canvas.
        /// </summary>
        /// <param name="Game">The Game instance this Player will belong to.</param>
        /// <param name="Color">The color of this Player and its curve.</param>
        public Player(Game.Game Game,string Name,Color Color)
        {
            this.Game = Game;
            this.Color = Color;
            this.Name = Name;
            this.Buttons = new Dictionary<Key, Action>();
            this.Goodies = new List<Goodie.Goodie>();
        }

        /// <summary>
        /// Assigns a keyboard button to this Player and specified the action it performs.
        /// </summary>
        /// <param name="Button">The keyboard button to assign.</param>
        /// <param name="Action">The assigned action.</param>
        public void Bind(Key Button, Action Action)
        {
            Buttons.Add(Button, Action);
        }

        /// <summary>
        /// Checks whether any of the buttons assigned to this Player are currently pressed and calls Game.Input with the corresponding Action values.
        /// </summary>
        public void Input()
        {
            foreach (KeyValuePair<Key, Action> Item in Buttons)
            {
                if (Keyboard.IsKeyDown(Item.Key))
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