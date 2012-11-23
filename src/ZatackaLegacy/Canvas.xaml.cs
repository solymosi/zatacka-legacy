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

namespace ZatackaLegacy
{
    public partial class Canvas : System.Windows.Controls.Canvas
    {
        public DrawingVisual Visual;

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

        protected override Visual GetVisualChild(int Index)
        {
            if (Visual == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Visual;
        }

        protected override int VisualChildrenCount { get { return Visual == null ? 0 : 1; } }
    }
}