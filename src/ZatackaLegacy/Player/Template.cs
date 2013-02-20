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
