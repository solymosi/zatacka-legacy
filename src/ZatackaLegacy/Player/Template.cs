using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Zatacka.Player
{
    /// <summary>
    /// Represents a player template from which actual players are created.
    /// </summary>
    class Template
    {
        /// <summary>
        /// Contains the default player templates from which new players can be created.
        /// </summary>
        static public Dictionary<int, Template> Templates { get; private set; }

        /// <summary>
        /// Creates and initializes the default player templates.
        /// </summary>
        static Template()
        {
            Templates = new Dictionary<int, Template>();
            Templates.Add(1, new Template("Player 1", Colors.Red, Key.D1, Key.Q, Key.D2));
            Templates.Add(2, new Template("Player 2", Colors.Yellow, Key.LeftCtrl, Key.LeftAlt, Key.X));
            Templates.Add(3, new Template("Player 3", Colors.Blue, Key.D4, Key.D5, Key.R));
            Templates.Add(4, new Template("Player 4", Colors.Orange, Key.M, Key.OemComma, Key.K));
            Templates.Add(5, new Template("Player 5", Colors.Pink, Key.Left, Key.Down, Key.Up));
            Templates.Add(6, new Template("Player 6", Colors.Green, Key.Divide, Key.Multiply, Key.Subtract));
            Templates.Add(7, new Template("Player 7", Colors.Cyan, MouseButton.Left, MouseButton.Right, MouseButton.Middle));
        }

        /// <summary>
        /// The color of this Player and its curve.
        /// </summary>
        public Color Color { get; protected set; }

        /// <summary>
        /// Contains the keyboard buttons assigned to this Player and the actions they perform.
        /// </summary>
        public Dictionary<Key, Action> KeyboardButtons { get; protected set; }

        /// <summary>
        /// Contains the mouse buttons assigned to this Player and the actions they perform.
        /// </summary>
        public Dictionary<MouseButton, Action> MouseButtons { get; protected set; }

        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Creates a player template using the specified parameters.
        /// </summary>
        /// <param name="Name">Default name of the player created from this Template.</param>
        /// <param name="Color">Color of the player created from this Template.</param>
        public Template(string Name, Color Color)
        {
            this.Name = Name;
            this.Color = Color;
            this.KeyboardButtons = new Dictionary<Key, Action>();
            this.MouseButtons = new Dictionary<MouseButton, Action>();
        }

        /// <summary>
        /// Creates a player template using the specified parameters and keyboard button assignments.
        /// </summary>
        /// <param name="Name">Default name of the player created from this Template.</param>
        /// <param name="Color">Color of the player created from this Template.</param>
        /// <param name="Left">Button used to turn the curve left.</param>
        /// <param name="Right">Button used to turn the curve right.</param>
        /// <param name="Trigger">Button used to trigger the effect of the currently active power-up (e.g: fire a weapon).</param>
        public Template(string Name, Color Color, Key Left, Key Right, Key Trigger)
            : this(Name, Color)
        {
            Bind(Left, Action.Left);
            Bind(Right, Action.Right);
            Bind(Trigger, Action.Trigger);
        }

        /// <summary>
        /// Creates a player template using the specified parameters and mouse button assignments.
        /// </summary>
        /// <param name="Name">Default name of the player created from this Template.</param>
        /// <param name="Color">Color of the player created from this Template.</param>
        /// <param name="Left">Button used to turn the curve left.</param>
        /// <param name="Right">Button used to turn the curve right.</param>
        /// <param name="Trigger">Button used to trigger the effect of the currently active power-up (e.g: fire a weapon).</param>
        public Template(string Name, Color Color, MouseButton Left, MouseButton Right, MouseButton Trigger)
            : this(Name, Color)
        {
            Bind(Left, Action.Left);
            Bind(Right, Action.Right);
            Bind(Trigger, Action.Trigger);
        }

        /// <summary>
        /// Assigns a keyboard button to this Player and specified the action it performs.
        /// </summary>
        /// <param name="Button">The keyboard button to assign.</param>
        /// <param name="Action">The assigned action.</param>
        public void Bind(Key Button, Action Action)
        {
            KeyboardButtons.Add(Button, Action);
        }

        /// <summary>
        /// Assigns a mouse button to this Player and specified the action it performs.
        /// </summary>
        /// <param name="Button">The mouse button to assign.</param>
        /// <param name="Action">The assigned action.</param>
        public void Bind(MouseButton Button, Action Action)
        {
            MouseButtons.Add(Button, Action);
        }
    }
}
