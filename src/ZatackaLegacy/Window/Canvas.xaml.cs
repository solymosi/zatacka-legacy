using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zatacka.Window
{
    /// <summary>
    /// Hosts and displays a Visual.
    /// </summary>
    public partial class Canvas : System.Windows.Controls.Canvas
    {
        /// <summary>
        /// The hosted Visual.
        /// </summary>
        public DrawingVisual Visual;

        /// <summary>
        /// Assigns the Visual instance to host.
        /// </summary>
        /// <param name="Visual">The Visual to host.</param>
        public void SetVisual(DrawingVisual Visual)
        {
            this.Visual = Visual;
            AddVisualChild(Visual);
            AddLogicalChild(Visual);

            Unloaded += new RoutedEventHandler(delegate
            {
                RemoveVisualChild(Visual);
                RemoveLogicalChild(Visual);
            });
        }

        /// <summary>
        /// Implements a method required by WPF to display the hosted visual.
        /// </summary>
        protected override Visual GetVisualChild(int Index)
        {
            if (Visual == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Visual;
        }

        /// <summary>
        /// Implements a method required by WPF to display the hosted visual.
        /// </summary>
        protected override int VisualChildrenCount { get { return Visual == null ? 0 : 1; } }
    }
}